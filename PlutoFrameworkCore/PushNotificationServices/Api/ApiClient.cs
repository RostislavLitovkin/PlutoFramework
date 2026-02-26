using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;

namespace PlutoFrameworkCore.PushNotificationServices.Api;

public class UnauthorizedException(string message) : HttpRequestException(message);

public static class ApiClient
{
    private static HttpClient? sharedClient;
    private static HttpClient SharedClient
    {
        get => sharedClient ?? throw new InvalidOperationException("Call SetBaseUrl before using ApiClient.");
        set => sharedClient = value;
    }

    public static void SetBaseUrl(string url)
    {
        SharedClient = new HttpClient
        {
            BaseAddress = new Uri(url)
        };
    }
    
    public static async Task RegisterDeviceRequestAsync()
    {
        if (Platform.Current == PlatformType.Other) return;
        
        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(
            SharedClient,
            await GetDeviceRegistrationDataAsync()
            );
        Console.WriteLine($"[PlutoNotifications] Got JWT pair: {tokenPair.Access} {tokenPair.Refresh}");

        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(tokenPair);
        SharedClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenPair.Access);
    }

    public static async Task<bool> RefreshAccessTokenRequestAsync(TokenPair tokenPair)
    {
        Console.WriteLine("[PlutoNotifications] Refreshing access token ...");
        if (Platform.Current == PlatformType.Other) return false;

        TokenPair newTokenPair;
        try
        {
            newTokenPair = await AuthTokenPairEndpoint.RefreshAccessTokenAsync(SharedClient, tokenPair);
        }
        catch
        {
            Console.WriteLine("[PlutoNotifications] Access token refresh failed");
            return false;
        }
        
        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(newTokenPair);
        SharedClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", newTokenPair.Access);
        
        Console.WriteLine("[PlutoNotifications] Access token refreshed");
        return true;
    }

    public static async Task UpdateFcmTokenRequestAsync(string newFcmToken)
    {
        if (Platform.Current == PlatformType.Other) return;

        await RequestWithAuthAsync(async () =>
            await FcmTokenEndpoint.UpdateTokenAsync(
                SharedClient,
                new FcmTokenUpdateData
                {
                    FcmToken = newFcmToken
                })
        );

    }
    
    public static async Task<T> RequestWithAuthAsync<T>(Func<Task<T>> apiCall)
    {
        try
        {
            return await apiCall();
        }
        catch (UnauthorizedException)
        {
            var tokenPair = await SecureStorageManager.Storage.GetAuthTokenPairAsync();
            if (tokenPair == null)
            {
                await SecureStorageManager.Storage.SaveIsRegisteredAsync(false);
                throw;
            }

            if (await RefreshAccessTokenRequestAsync(tokenPair) || await DeviceRegisterService.RegisterDeviceAsync())
                return await apiCall();

            throw;
        }
    }
    
    public static async Task RequestWithAuthAsync(Func<Task> apiCall)
    {
        try
        {
            await apiCall();
        }
        catch (UnauthorizedException)
        {
            var tokenPair = await SecureStorageManager.Storage.GetAuthTokenPairAsync();
            if (tokenPair == null)
            {
                Console.WriteLine("[PlutoNotifications] No tokens stored, marking device as unregistered.");
                await SecureStorageManager.Storage.SaveIsRegisteredAsync(false);
                throw;
            }

            if (!await RefreshAccessTokenRequestAsync(tokenPair) && !await DeviceRegisterService.RegisterDeviceAsync())
                throw;

            await apiCall();
        }
    }
    
    private static async Task<DeviceRegistrationData> GetDeviceRegistrationDataAsync()
    {
        var nonce = await NonceEndpoint.GetNonceAsync(SharedClient);
        var isFirstRegister = !(await SecureStorageManager.Storage.GetIsRegisteredAsync() ?? false);

        AttestationProof proof;
        if (Platform.Current == PlatformType.Android || (Platform.Current == PlatformType.iOS && isFirstRegister))
        {
            proof = await Platform.AttestationService.GetAttestationAsync(nonce);
            return new DeviceRegistrationData
            {
                Nonce = nonce,
                Attestation = proof.Proof,
                DeviceId = proof.DeviceId,
                Platform = Platform.Current.ToStringValue()
            };
        }
        
        proof = await Platform.AttestationService.GetAssertionAsync(nonce);
        return new DeviceRegistrationData
        {
            Nonce = nonce,
            Assertion = proof.Proof,
            DeviceId = proof.DeviceId,
            Platform = Platform.Current.ToStringValue()
        };
    }
}