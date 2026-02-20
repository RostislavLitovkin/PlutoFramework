using System.Security.Cryptography;
using System.Text;
using DeviceCheck;
using Foundation;
using Microsoft.AspNetCore.WebUtilities;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Platforms.iOS;

public class AppAttestService (IPushNotificationsSecureStorage secureStorage) : IAttestationService
{
    private readonly DCAppAttestService attestService = DCAppAttestService.SharedService;
    
    public async Task<string> GetAttestationAsync(string nonce)
    {
        if (!attestService.Supported)
            throw new NotSupportedException("App Attest is not supported on this device.");

        var clientDataHash = SHA256.HashData(WebEncoders.Base64UrlDecode(nonce));
        var hashData = NSData.FromArray(clientDataHash);

        var keyId = await secureStorage.GetDeviceIdAsync();

        if (string.IsNullOrEmpty(keyId))
        {
            keyId = await GenerateAndStoreNewKeyAsync();
        }

        try
        {
            var attestation = await attestService.AttestKeyAsync(keyId, hashData);
            await Console.Out.WriteLineAsync($"[PlutoNotifications] Attestation using device id (1): {keyId}");

            if (attestation == null)
                throw new InvalidOperationException("Attestation returned null.");

            return attestation.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
        }
        catch
        {
            await secureStorage.SaveDeviceIdAsync(string.Empty);

            keyId = await GenerateAndStoreNewKeyAsync();

            var attestation = await attestService.AttestKeyAsync(keyId, hashData);
            await Console.Out.WriteLineAsync($"[PlutoNotifications] Attestation using device id (2): {keyId}");

            if (attestation == null)
                throw new InvalidOperationException("Failed to generate App Attest attestation after regeneration.");

            return attestation.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
        }
    }

    public async Task<string?> GetAssertionAsync(string nonce)
    {
        var clientDataHash = SHA256.HashData(WebEncoders.Base64UrlDecode(nonce));
        var hashData = NSData.FromArray(clientDataHash);

        var keyId = await secureStorage.GetDeviceIdAsync();

        if (string.IsNullOrEmpty(keyId))
            keyId = await GenerateAndStoreNewKeyAsync();

        try
        {
            var assertion = await attestService.GenerateAssertionAsync(keyId, hashData);

            if (assertion == null)
                throw new InvalidOperationException("Assertion returned null.");

            return assertion.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
        }
        catch
        {
            await secureStorage.SaveDeviceIdAsync(string.Empty);

            keyId = await GenerateAndStoreNewKeyAsync();

            var assertion = await attestService.GenerateAssertionAsync(keyId, hashData);

            if (assertion == null)
                throw new InvalidOperationException("Failed to generate assertion after regeneration.");

            return assertion.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
        }
    }

    public async Task<string> GetDeviceIdAsync()
    {
        var keyId = await secureStorage.GetDeviceIdAsync();
        
        if (!string.IsNullOrEmpty(keyId))
            return keyId;
        
        keyId = await attestService.GenerateKeyAsync();
        await secureStorage.SaveDeviceIdAsync(keyId);
        
        return keyId;
    }
    
    private async Task<string> GenerateAndStoreNewKeyAsync()
    {
        var newKeyId = await attestService.GenerateKeyAsync();

        if (string.IsNullOrEmpty(newKeyId))
            throw new InvalidOperationException("Failed to generate App Attest key.");

        await secureStorage.SaveDeviceIdAsync(newKeyId);

        return newKeyId;
    }
}