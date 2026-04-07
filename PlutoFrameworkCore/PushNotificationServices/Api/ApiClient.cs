using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;

namespace PlutoFrameworkCore.PushNotificationServices.Api;

public class UnauthorizedException(string message) : HttpRequestException(message);

public static class ApiClient
{
    private static HttpClient? publicClient;
    private static HttpClient? authenticatedClient;
    private static HttpClient PublicClient
    {
        get => publicClient ?? throw new InvalidOperationException("Call SetBaseUrl before using ApiClient.");
        set => publicClient = value;
    }
    private static HttpClient AuthenticatedClient
    {
        get => authenticatedClient ?? throw new InvalidOperationException("Call SetBaseUrl before using ApiClient.");
        set => authenticatedClient = value;
    }

    public static void SetBaseUrl(string url)
    {
        PublicClient = new HttpClient
        {
            BaseAddress = new Uri(url)
        };
        AuthenticatedClient = new HttpClient
        {
            BaseAddress = new Uri(url)
        };
    }
    
    public static async Task RegisterDeviceRequestAsync()
    {
        if (Platform.Current == PlatformType.Other) return;
        
        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(
            PublicClient,
            await GetDeviceRegistrationDataAsync()
            );
        Console.WriteLine("[PlutoNotifications] Got JWT pair");

        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(tokenPair);
    }

    public static async Task<bool> RefreshAccessTokenRequestAsync(TokenPair tokenPair)
    {
        Console.WriteLine("[PlutoNotifications] Refreshing access token ...");
        if (Platform.Current == PlatformType.Other) return false;

        TokenPair newTokenPair;
        try
        {
            newTokenPair = await AuthTokenPairEndpoint.RefreshAccessTokenAsync(PublicClient, tokenPair);
        }
        catch
        {
            Console.WriteLine("[PlutoNotifications] Access token refresh failed");
            return false;
        }
        
        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(newTokenPair);
        
        Console.WriteLine("[PlutoNotifications] Access token refreshed");
        return true;
    }

    public static async Task UpdateFcmTokenRequestAsync(string newFcmToken)
    {
        if (Platform.Current == PlatformType.Other) return;

        await RequestWithAuthAsync(async () =>
            await FcmTokenEndpoint.UpdateTokenAsync(
                AuthenticatedClient,
                new FcmTokenUpdateData
                {
                    FcmToken = newFcmToken
                })
        );

    }
    
    public static async Task<T> RequestWithAuthAsync<T>(Func<Task<T>> apiCall)
    {
        if (!await SetAuthHeaderAsync()) throw new UnauthorizedException("Not authorized");
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
        if (!await SetAuthHeaderAsync()) throw new UnauthorizedException("Not authorized");
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
        var nonce = await NonceEndpoint.GetNonceAsync(PublicClient);
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

    private static async Task<bool> SetAuthHeaderAsync()
    {
        var tokenPair = await SecureStorageManager.Storage.GetAuthTokenPairAsync();
        if (tokenPair == null) return false;
        
        AuthenticatedClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenPair.Access);
        
        return true;
    }
}