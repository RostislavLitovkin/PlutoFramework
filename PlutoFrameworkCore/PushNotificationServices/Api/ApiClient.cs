using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;

namespace PlutoFrameworkCore.PushNotificationServices.Api;

public class UnauthorizedException(string message) : HttpRequestException(message);

public static class ApiClient
{
    private static HttpClient? _sharedClient;
    private static HttpClient SharedClient
    {
        get => _sharedClient ??  throw new InvalidOperationException("Set ApiClient.BaseUrl before using ApiClient.");
        set => _sharedClient = value;
    }

    public static void SetBaseUrl(string url)
    {
        SharedClient = new HttpClient
        {
            BaseAddress = new Uri(url ?? throw new InvalidOperationException(
                    "Base URL is not specified. Call SetBaseUrl before using ApiClient."))
        };
    }
    
    public static async Task RegisterDeviceRequestAsync(string deviceUUID)
    {
        if (Platform.Current == PlatformType.Other) return;

        var nonce = await NonceEndpoint.GetNonceAsync(SharedClient, new NonceRetrievalData {
            DeviceUUID = deviceUUID,
            Platform = Platform.Current.ToStringValue()
        });

        var attestation = await new AttestationTokenService(Platform.AttestationService).GetTokenAsync(nonce);

        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(SharedClient, new DeviceRegistrationData {
            DeviceUUID = deviceUUID,
            Attestation = attestation,
            Platform = Platform.Current.ToStringValue()
        });
        //Console.WriteLine($"[PlutoNotifications] Got JWT pair: {tokenPair.Access} {tokenPair.Refresh}");

        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(tokenPair);
        SharedClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenPair.Access);
    }

    public static async Task RefreshAccessTokenRequestAsync(TokenPair tokenPair)
    {
        Console.WriteLine($"[PlutoNotifications] Refreshing access token ...");
        if (Platform.Current == PlatformType.Other) return;

        try
        {
            var newTokenPair = await AuthTokenPairEndpoint.RefreshAccessTokenAsync(SharedClient, tokenPair);
            
            await SecureStorageManager.Storage.SaveAuthTokenPairAsync(newTokenPair);
            SharedClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", newTokenPair.Access);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[PlutoNotifications] Access token refresh failed");
            return;
        }
        
        Console.WriteLine($"[PlutoNotifications] Access token refreshed");
    }

    public static async Task UpdateFCMTokenRequestAsync(string newFCMToken)
    {
        if (Platform.Current == PlatformType.Other) return;

        try
        {
            await FCMTokenEndpoint.UpdateTokenAsync(SharedClient, new FCMTokenUpdateData
            {
                FCMToken = newFCMToken
            });
        }
        catch (UnauthorizedException)
        {
            var tokenPair = await SecureStorageManager.Storage.GetAuthTokenPairAsync();

            if (tokenPair == null) await SecureStorageManager.Storage.SaveIsRegisteredAsync(false);
            else
            {
                await RefreshAccessTokenRequestAsync(tokenPair);
            }
        }
    }
}