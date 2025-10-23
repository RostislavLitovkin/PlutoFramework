using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Platforms.iOS;

public class AppAttestService : IAttestationService
{
    public Task<string> GetAttestationTokenAsync(string nonce)
    {
        throw new NotImplementedException(); // TODO
    }
}