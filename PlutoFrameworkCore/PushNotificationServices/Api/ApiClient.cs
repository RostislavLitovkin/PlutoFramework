using Plugin.Firebase.CloudMessaging;
using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core;

namespace PlutoFrameworkCore.PushNotificationServices.Api;

public static class ApiClient
{
    #if ANDROID
    private static readonly string? Platform = "android";
    #elif IOS
    private static readonly string? Platform = "ios";
    #else
    private static readonly string? Platform = null;
    #endif
    
    private static readonly HttpClient SharedClient  = new () {
        BaseAddress=new Uri(Constants.PushNotifications.API_URL)
    };

    public static async Task RegisterDeviceAsync()
    {
        if (Platform == null) return;
        
        var deviceUUID = ""; // TODO

        var nonce = await NonceEndpoint.GetNonceAsync(SharedClient, new NonceRetrievalData {
            DeviceUUID = deviceUUID
        });

        var attestation = ""; // TODO

        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(SharedClient, new DeviceRegistrationData {
            DeviceUUID = deviceUUID,
            Attestation = attestation,
            Platform = Platform
        });

        // TODO: save token pair to secure storage
    }

    public static async Task RefreshAccessTokenAsync()
    {
        if (Platform == null) return;
        
        TokenPair tokenPair = new ()
        {
            Access = "", Refresh = ""
        }; // TODO: retrieve keys from storage
        
        await AuthTokenPairEndpoint.RefreshAccessTokenAsync(SharedClient, tokenPair);
        
        // TODO: save token pair to secure storage
    }

    public static async Task UpdateFCMTokenAsync()
    {
        if (Platform == null) return;
        
        var currentToken = await FCMTokenService.GetTokenAsync();

        if (currentToken == null) throw new FCMException("Couldn't retrieve current FCM token");
        
        await FCMTokenEndpoint.UpdateTokenAsync(SharedClient, new FCMTokenUpdateData
        {
            FCMToken = currentToken
        });
    }
}