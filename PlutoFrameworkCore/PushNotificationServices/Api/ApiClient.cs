using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;

namespace PlutoFrameworkCore.PushNotificationServices.Api;

public static class ApiClient
{
    private static string? _baseUrl;

    public static void SetBaseUrl(string url)
    {
        _baseUrl = url ?? throw new ArgumentNullException(nameof(url));
    }

    private static readonly HttpClient SharedClient = new()
    {
        BaseAddress = new Uri(_baseUrl ?? throw new InvalidOperationException(
            "API base URL not set. Call ApiClient.SetBaseUrl(...) before using ApiClient."))
    };
    
    public static async Task RegisterDeviceRequestAsync(string deviceUUID)
    {
        if (Platform.Current == PlatformType.Other) return;

        var nonce = await NonceEndpoint.GetNonceAsync(SharedClient, new NonceRetrievalData {
            DeviceUUID = deviceUUID
        });

        var attestation = await new AttestationTokenService(Platform.AttestationService).GetTokenAsync(nonce);

        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(SharedClient, new DeviceRegistrationData {
            DeviceUUID = deviceUUID,
            Attestation = attestation,
            Platform = Platform.Current.ToStringValue()
        });

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