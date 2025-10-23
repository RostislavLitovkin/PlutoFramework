namespace PlutoFrameworkCore.PushNotificationServices.Core;

public static class UUIDService
{
    public static async Task<string> GetInstallationUUIDAsync()
    {
        var uuid = await SecureStorageManager.Storage.GetUUIDAsync() ?? 
                   await GenerateInstallationUUIDAsync();
        
        return uuid;
    }

    private static async Task<string> GenerateInstallationUUIDAsync()
    {
        var uuid = Guid.NewGuid().ToString();
        
        await SecureStorageManager.Storage.SaveUUIDAsync(uuid);
        
        return uuid;
    }
}