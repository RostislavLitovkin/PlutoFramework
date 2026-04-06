using System.Security.Cryptography;
using DeviceCheck;
using Foundation;
using Microsoft.AspNetCore.WebUtilities;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Platforms.iOS;

public class AppAttestService (IPushNotificationsSecureStorage secureStorage) : IAttestationService
{
    private readonly DCAppAttestService attestService = DCAppAttestService.SharedService;
    
    public async Task<AttestationProof> GetAttestationAsync(string nonce)
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
        
        NSData? attestation;

        try
        {
            attestation = await attestService.AttestKeyAsync(keyId, hashData);

            if (attestation == null)
                throw new InvalidOperationException("Attestation returned null.");
        }
        catch
        {
            await secureStorage.SaveDeviceIdAsync(string.Empty);

            keyId = await GenerateAndStoreNewKeyAsync();

            attestation = await attestService.AttestKeyAsync(keyId, hashData);

            if (attestation == null)
                throw new InvalidOperationException("Failed to generate App Attest attestation after regeneration.");
        }
        return new AttestationProof (
            await GetDeviceIdAsync(),
            attestation.GetBase64EncodedString(NSDataBase64EncodingOptions.None)
            );
    }

    public async Task<AttestationProof> GetAssertionAsync(string nonce)
    {
        var clientDataHash = SHA256.HashData(WebEncoders.Base64UrlDecode(nonce));
        var hashData = NSData.FromArray(clientDataHash);

        var keyId = await secureStorage.GetDeviceIdAsync();

        if (string.IsNullOrEmpty(keyId))
            throw new InvalidOperationException("No attested key available. Full re-attestation required.");
        
        var assertion = await attestService.GenerateAssertionAsync(keyId, hashData)
                    ?? throw new InvalidOperationException("Assertion returned null.");

        return new AttestationProof (
            await GetDeviceIdAsync(),
            assertion.GetBase64EncodedString(NSDataBase64EncodingOptions.None)
            );
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