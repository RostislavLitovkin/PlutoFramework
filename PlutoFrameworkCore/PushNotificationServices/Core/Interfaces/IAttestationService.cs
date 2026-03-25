namespace PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

public interface IAttestationService
{
    Task GetAttestationTokenAsync();
}