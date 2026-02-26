namespace PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

public record AttestationProof(string DeviceId, string? Proof);

public interface IAttestationService
{
    Task<AttestationProof> GetAttestationAsync(string nonce);
    Task<AttestationProof> GetAssertionAsync(string nonce);
    
    Task<string> GetDeviceIdAsync();
}