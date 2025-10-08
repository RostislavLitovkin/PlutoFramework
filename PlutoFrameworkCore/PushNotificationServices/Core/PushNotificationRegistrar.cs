using Plugin.Firebase.CloudMessaging;
using Microsoft.Extensions.DependencyInjection;

namespace PlutoFrameworkCore.PushNotificationServices.Core;

public static class PushNotificationRegistrar
{
    public static void RegisterPushNotificationServices(IServiceCollection services)
    {

        CrossFirebaseCloudMessaging.Current.TokenChanged += (_, token) =>
        {
            Console.WriteLine($"[PlutoFramework] FCM token updated: {token}");
            // TODO: await DeviceRegisterService.RegisterOrUpdateTokenAsync(token);
        };

        services.AddSingleton(CrossFirebaseCloudMessaging.Current);
    }
}
