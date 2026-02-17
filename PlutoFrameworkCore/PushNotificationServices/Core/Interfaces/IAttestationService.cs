namespace PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

public interface IAttestationService
{
    Task<string> GetAttestationAsync(string nonce);
    Task<string?> GetAssertionAsync(string nonce);
    
    Task<string> GetDeviceIdAsync();
}