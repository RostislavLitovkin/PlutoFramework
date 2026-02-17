using PlutoFramework.Model.DeviceSecureStorage;
using PlutoFrameworkCore.PushNotificationServices.Api;
using PlutoFrameworkCore.PushNotificationServices.Core;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;
# if ANDROID
using PlutoFramework.Platforms.Android.Attestation;
# elif IOS
using PlutoFrameworkCore.PushNotificationServices.Platforms.iOS;
# endif

namespace PlutoFramework.Model.Initializers;

using NotificationsPlatform = PlutoFrameworkCore.PushNotificationServices.Core.Misc.Platform;

public static class PushNotificationsAppInitializer
{
    public static void Initialize(string apiUrl)
    {
        _ = InitializeAsync(apiUrl);
    }

    private static async Task InitializeAsync(string apiUrl)
    {
        Console.WriteLine($"[PlutoNotifications] Trying to start notification services ...");
        ApiClient.SetBaseUrl(apiUrl);
        Console.WriteLine($"[PlutoNotifications] API URL set: {apiUrl}");
        
        SecureStorageManager.Storage = new PushNotificationsSecureStorageService();

        # if ANDROID
        NotificationsPlatform.Current = PlatformType.Android;
        NotificationsPlatform.AttestationService = new PlayIntegrityService(SecureStorageManager.Storage);
        # elif IOS
        NotificationsPlatform.Current = PlatformType.iOS;
        NotificationsPlatform.AttestationService = new AppAttestService(SecureStorageManager.Storage);
        # endif
        Console.WriteLine($"[PlutoNotifications] Platform type set: {NotificationsPlatform.Current.ToStringValue()}");
        
        if (await DeviceRegisterService.RegisterDeviceAsync())
        {
            await DeviceRegisterService.UpdateFcmTokenAsync();
        }
        
        Console.WriteLine($"[PlutoNotifications] Background jobs processed.");
    }
}