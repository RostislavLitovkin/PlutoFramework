using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Platforms.Android;

public class PlayIntegrityService : IAttestationService
{
    public Task GetAttestationTokenAsync()
    {
        throw new NotImplementedException(); // TODO
    }
}