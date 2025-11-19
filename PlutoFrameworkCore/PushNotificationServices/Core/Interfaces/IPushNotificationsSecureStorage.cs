using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

public interface IPushNotificationsSecureStorage
{
    public Task SaveUUIDAsync(string uuid);
    public Task<string?> GetUUIDAsync();
    public Task SaveAuthTokenPairAsync(TokenPair tokenPair);
    public Task<TokenPair?> GetAuthTokenPairAsync();
    public Task SaveIsRegisteredAsync(bool registered);
    public Task<bool?> GetIsRegisteredAsync();
    public Task SaveFCMTokenExpiredAsync(bool expired);
    public Task<bool?> GetFCMTokenExpiredAsync();
}