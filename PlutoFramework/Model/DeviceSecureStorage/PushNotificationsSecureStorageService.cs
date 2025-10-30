using System.Collections;
using System.Text.Json;
using PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;
using PlutoFrameworkCore.PushNotificationServices.Core.Background;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFramework.Model.DeviceSecureStorage;

public class PushNotificationsSecureStorageService : IPushNotificationsSecureStorage
{
    private const string KeyUuid = "installation_uuid";
    private const string KeyAuthTokenPair = "auth_token_pair";
    private const string KeyJobQueue = "job_queue";
    
    public async Task SaveUUIDAsync(string uuid)
    {
        await SecureStorage.Default.SetAsync(KeyUuid, uuid);
    }
    
    public async Task<string?> GetUUIDAsync()
    {
        try
        {
            return await SecureStorage.Default.GetAsync(KeyUuid);
        }
        catch
        {
            return null;
        }
    }

    public async Task SaveAuthTokenPairAsync(TokenPair pair)
    {
        var json = JsonSerializer.Serialize(pair);
        await SecureStorage.Default.SetAsync(KeyAuthTokenPair, json);
    }
    
    public async Task<TokenPair?> GetAuthTokenPairAsync()
    {
        try
        {
            var json = await SecureStorage.Default.GetAsync(KeyAuthTokenPair);
            return json == null ? null : JsonSerializer.Deserialize<TokenPair>(json);
        }
        catch
        {
            return null;
        }
    }
    
    public async Task SaveJobQueueAsync(Queue<BackgroundJob> pair)
    {
        var json = JsonSerializer.Serialize(pair);
        await SecureStorage.Default.SetAsync(KeyJobQueue, json);
    }
    
    public async Task<Queue<BackgroundJob>?> GetJobQueueAsync()
    {
        try
        {
            var json = await SecureStorage.Default.GetAsync(KeyAuthTokenPair);
            return json == null ? null : JsonSerializer.Deserialize<Queue<BackgroundJob>>(json);
        }
        catch
        {
            return null;
        }
    }
}