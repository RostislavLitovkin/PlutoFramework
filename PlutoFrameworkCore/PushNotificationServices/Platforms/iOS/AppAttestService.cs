using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Platforms.iOS;

public class AppAttestService : IAttestationService
{
    public Task GetAttestationTokenAsync()
    {
        throw new NotImplementedException(); // TODO
    }
}