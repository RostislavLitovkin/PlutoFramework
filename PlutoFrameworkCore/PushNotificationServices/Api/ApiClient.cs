using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;

namespace PlutoFrameworkCore.PushNotificationServices.Api;

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
        Console.WriteLine($"[PlutoNotifications] Got nonce: {nonce}");

        var attestation = await new AttestationTokenService(Platform.AttestationService).GetTokenAsync(nonce);
        Console.WriteLine($"[PlutoNotifications] Got attestation: {attestation}");

        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(SharedClient, new DeviceRegistrationData {
            DeviceUUID = deviceUUID,
            Attestation = attestation,
            Platform = Platform.Current.ToStringValue()
        });
        Console.WriteLine($"[PlutoNotifications] Got JWT pair: {tokenPair.Access} {tokenPair.Refresh}");

        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(tokenPair);
    }

    public static async Task RefreshAccessTokenRequestAsync(TokenPair tokenPair)
    {
        if (Platform.Current == PlatformType.Other) return;
        
        var newTokenPair = await AuthTokenPairEndpoint.RefreshAccessTokenAsync(SharedClient, tokenPair);
        
        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(newTokenPair);
    }

    public static async Task UpdateFCMTokenRequestAsync(string newFCMToken)
    {
        if (Platform.Current == PlatformType.Other) return;
        
        await FCMTokenEndpoint.UpdateTokenAsync(SharedClient, new FCMTokenUpdateData
        {
            FCMToken = newFCMToken
        });
    }
}