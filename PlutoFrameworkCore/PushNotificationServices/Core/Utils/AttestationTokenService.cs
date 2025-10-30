using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using UniqueryPlus.OpalSubquery;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public class AttestationTokenService (IAttestationService service)
{
    public async Task<string> GetTokenAsync(string nonce)
    {
        return await service.GetAttestationTokenAsync(nonce);
    }
}