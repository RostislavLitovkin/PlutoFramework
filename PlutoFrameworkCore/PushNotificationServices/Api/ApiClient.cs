using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
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

        var nonce = await NonceEndpoint.GetNonceAsync(SharedClient);
        Console.WriteLine($"[PlutoNotifications] Got nonce: {nonce}");
        
        string? attestation = null;
        try
        {
            attestation = await Platform.AttestationService.GetAttestationAsync(nonce);
        }
        catch (Exception e)
        {
            Console.WriteLine($"[PlutoNotifications] Attestation failed");
            Console.WriteLine($"[PlutoNotifications] Error: {e.Message}");
        }
        Console.WriteLine($"[PlutoNotifications] Got attestation: {attestation}");
        
        var assertion = await Platform.AttestationService.GetAssertionAsync(nonce);
        Console.WriteLine($"[PlutoNotifications] Got assertion: {assertion}");
        
        var deviceId = await Platform.AttestationService.GetDeviceIdAsync();
        Console.WriteLine($"[PlutoNotifications] Got device id: {deviceId}");
        

        var tokenPair = await AuthTokenPairEndpoint.GetTokenPairAsync(SharedClient, new DeviceRegistrationData {
            Nonce = nonce,
            DeviceId = deviceId,
            Attestation = attestation,
            Assertion = assertion,
            Platform = Platform.Current.ToStringValue()
        });
        Console.WriteLine($"[PlutoNotifications] Got JWT pair: {tokenPair.Access} {tokenPair.Refresh}");

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

    public static async Task UpdateFcmTokenRequestAsync(string newFcmToken)
    {
        if (Platform.Current == PlatformType.Other) return;

        try
        {
            await FcmTokenEndpoint.UpdateTokenAsync(SharedClient, new FcmTokenUpdateData
            {
                FcmToken = newFcmToken
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