using Plugin.Firebase.CloudMessaging;
using Microsoft.Extensions.DependencyInjection;
using PlutoFramework.Model;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public static class PushNotificationRegistrar
{
    public static void RegisterPushNotificationServices(IServiceCollection services)
    {

        CrossFirebaseCloudMessaging.Current.TokenChanged += (sender, token) =>
        {
            Console.WriteLine($"[PlutoNotifications] New FCM token: {token}");
            _ = DeviceRegisterService.UpdateFCMTokenAsync();
        };

        services.AddSingleton(CrossFirebaseCloudMessaging.Current);
    }
}
