using Plugin.Firebase.CloudMessaging;
using Microsoft.Extensions.DependencyInjection;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public static class PushNotificationRegistrar
{
    public static void RegisterPushNotificationServices(IServiceCollection services)
    {

        CrossFirebaseCloudMessaging.Current.TokenChanged += (sender, eventArgs) =>
        {
            _ = DeviceRegisterService.UpdateFCMTokenAsync();
        };

        services.AddSingleton(CrossFirebaseCloudMessaging.Current);
    }
}
