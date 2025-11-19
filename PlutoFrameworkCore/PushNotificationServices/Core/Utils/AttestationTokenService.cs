using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public class AttestationTokenService (IAttestationService service)
{
    public async Task<string> GetTokenAsync(string nonce)
    {
        return await service.GetAttestationTokenAsync(nonce);
    }
}