using Plugin.Firebase.CloudMessaging;
using Microsoft.Extensions.DependencyInjection;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public static class PushNotificationRegistrar
{
    public static void RegisterPushNotificationServices(IServiceCollection services)
    {
        CrossFirebaseCloudMessaging.Current.TokenChanged += (sender, eventArgs) =>
        {
            _ = HandleTokenChangedAsync();
        };

        services.AddSingleton(CrossFirebaseCloudMessaging.Current);
    }
    
    private static async Task HandleTokenChangedAsync()
    {
        try
        {
            await SecureStorageManager.Storage.SaveFcmTokenExpiredAsync(true);
            await DeviceRegisterService.UpdateFcmTokenAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"[PlutoNotifications] TokenChanged handler failed: {e}");
        }
    }
}
