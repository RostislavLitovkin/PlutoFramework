using System.Security.Cryptography;
using System.Text;
using DeviceCheck;
using Foundation;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Platforms.iOS;

public class AppAttestService (IPushNotificationsSecureStorage secureStorage) : IAttestationService
{
    private readonly DCAppAttestService attestService = DCAppAttestService.SharedService;
    
    public async Task<string> GetAttestationAsync(string nonce)
    {
        if (!DCAppAttestService.SharedService.Supported)
            throw new NotSupportedException("App Attest is not supported on this device.");

        var keyId = await GetDeviceIdAsync();
        if (string.IsNullOrEmpty(keyId))
        {
            keyId = await attestService.GenerateKeyAsync();
            await secureStorage.SaveDeviceIdAsync(keyId);
        }
        
        var clientDataHash = SHA256.HashData(Encoding.UTF8.GetBytes(nonce));
        var hashData = NSData.FromArray(clientDataHash);

        var attestation = await attestService.AttestKeyAsync(keyId, hashData);
        if (attestation == null)
            throw new InvalidOperationException("Failed to generate App Attest attestation.");

        return attestation.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
    }

    public async Task<string?> GetAssertionAsync(string nonce)
    {
        var keyId = await GetDeviceIdAsync();
        if (string.IsNullOrEmpty(keyId))
            throw new InvalidOperationException("No App Attest key exists for this device.");

        var service = DCAppAttestService.SharedService;

        var clientDataHash = SHA256.HashData(Encoding.UTF8.GetBytes(nonce));
        var hashData = NSData.FromArray(clientDataHash);

        var assertion = await service.GenerateAssertionAsync(keyId, hashData);
        if (assertion == null)
            throw new InvalidOperationException("Failed to generate App Attest assertion.");

        return assertion.GetBase64EncodedString(NSDataBase64EncodingOptions.None);
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
}