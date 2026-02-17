using Android.Gms.Extensions;
using Xamarin.Google.Android.Play.Core.Integrity;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFramework.Platforms.Android.Attestation;

public class PlayIntegrityService (IPushNotificationsSecureStorage secureStorage) : IAttestationService
{
    public async Task<string> GetAttestationAsync(string nonce)
    {
        var context = global::Android.App.Application.Context;
        var integrityManager = IntegrityManagerFactory.Create(context);
        var builder = IntegrityTokenRequest.InvokeBuilder();

        if (builder is null)
            throw new InvalidOperationException("Invalid Play Integrity response type.");

        var request = builder.SetNonce(nonce)!.Build();
        var objResponse = await integrityManager.RequestIntegrityToken(request)!;

        if (objResponse is not IntegrityTokenResponse response)
            throw new InvalidOperationException("Invalid Play Integrity response type.");

        return response.Token()!;
    }

    public Task<string?> GetAssertionAsync(string nonce)
    {
        // Android does not use assertion
        return Task.FromResult<string?>(null);
    }

    public async Task<string> GetDeviceIdAsync()
    {
        var deviceId = await secureStorage.GetDeviceIdAsync();
        
        if (!string.IsNullOrEmpty(deviceId))
            return deviceId;
        
        deviceId = Guid.NewGuid().ToString();
        await secureStorage.SaveDeviceIdAsync(deviceId);
        
        return deviceId;
    }
}