using Android.Gms.Extensions;
using Android.Gms.Tasks;
using Xamarin.Google.Android.Play.Core.Integrity;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFramework.Platforms.Android.Attestation;

public class PlayIntegrityService : IAttestationService
{
    public async Task<string> GetAttestationTokenAsync(string nonce)
    {
        var context = global::Android.App.Application.Context;
        var integrityManager = IntegrityManagerFactory.Create(context);
        var builder = IntegrityTokenRequest.InvokeBuilder();
        
        if (builder is null)
            throw new InvalidOperationException("Invalid Play Integrity response type.");
        
        var request = builder
            .SetNonce(nonce)!
            .Build();

        var objResponse = await integrityManager.RequestIntegrityToken(request)!;
        
        if (objResponse is not IntegrityTokenResponse response)
            throw new InvalidOperationException("Invalid Play Integrity response type.");

        return response.Token()!;
    }
}