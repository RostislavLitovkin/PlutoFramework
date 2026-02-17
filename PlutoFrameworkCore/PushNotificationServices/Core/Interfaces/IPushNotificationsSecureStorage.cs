using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

public interface IPushNotificationsSecureStorage
{
    public Task SaveDeviceIdAsync(string uuid);
    public Task<string?> GetDeviceIdAsync();
    public Task SaveAuthTokenPairAsync(TokenPair tokenPair);
    public Task<TokenPair?> GetAuthTokenPairAsync();
    public Task SaveIsRegisteredAsync(bool registered);
    public Task<bool?> GetIsRegisteredAsync();
    public Task SaveFcmTokenExpiredAsync(bool expired);
    public Task<bool?> GetFcmTokenExpiredAsync();
}