using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;

namespace PlutoFrameworkCore.PushNotificationServices.Api;

public class ApiClient (Platform platform)
{
    private static readonly HttpClient SharedClient = new () {
        BaseAddress=new Uri(Constants.PushNotifications.API_URL)
    };

    public async Task RegisterDeviceAsync(string deviceUUID, IAttestationService attestationService)
    {
        if (platform == Platform.Other) return;

        var nonce = await NonceEndpoint.GetNonceAsync(SharedClient, new NonceRetrievalData {
            DeviceUUID = deviceUUID
        });

        var attestation = await new AttestationTokenService(attestationService).GetTokenAsync(nonce);

        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(SharedClient, new DeviceRegistrationData {
            DeviceUUID = deviceUUID,
            Attestation = attestation,
            Platform = platform.ToStringValue()
        });

        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(tokenPair);
    }

    public async Task RefreshAccessTokenAsync(TokenPair tokenPair)
    {
        if (platform == Platform.Other) return;
        
        var newTokenPair = await AuthTokenPairEndpoint.RefreshAccessTokenAsync(SharedClient, tokenPair);
        
        await SecureStorageManager.Storage.SaveAuthTokenPairAsync(newTokenPair);
    }

    public async Task UpdateFCMTokenAsync(string newFCMToken)
    {
        if (platform == Platform.Other) return;
        
        await FCMTokenEndpoint.UpdateTokenAsync(SharedClient, new FCMTokenUpdateData
        {
            FCMToken = newFCMToken
        });
    }
}