namespace PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

public interface IAttestationService
{
    Task<string> GetAttestationTokenAsync(string nonce);
}