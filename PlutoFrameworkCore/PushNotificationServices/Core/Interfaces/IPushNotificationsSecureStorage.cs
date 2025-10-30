using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core.Background;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

public interface IPushNotificationsSecureStorage
{
    public Task SaveUUIDAsync(string uuid);
    public Task<string?> GetUUIDAsync();
    public Task SaveAuthTokenPairAsync(TokenPair tokenPair);
    public Task<TokenPair?> GetAuthTokenPairAsync();
    public Task SaveJobQueueAsync(Queue<BackgroundJob> jobQueue);
    public Task<Queue<BackgroundJob>?> GetJobQueueAsync();
}