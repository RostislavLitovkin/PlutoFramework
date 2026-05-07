using PlutoFramework.Model.DeviceSecureStorage;
using PlutoFrameworkCore.PushNotificationServices.Api;
using PlutoFrameworkCore.PushNotificationServices.Core;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;
# if ANDROID
using Firebase;
using PlutoFramework.Platforms.Android;
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
        await SecureStorageManager.Storage.EnsurePerInstallIsolationAsync();

        Console.WriteLine($"[PlutoNotifications] Trying to request notification permission ...");
#if ANDROID
        try
        {
            await Permissions.RequestAsync<NotificationPermission>();
        }
        catch (PermissionException e)
        {
            Console.WriteLine($"[PlutoNotifications] Permission exception: {e.Message}");
        }

        NotificationsPlatform.Current = PlatformType.Android;
        NotificationsPlatform.AttestationService = new PlayIntegrityService(SecureStorageManager.Storage);
#elif IOS
        Firebase.Core.App.Configure();
        await Platforms.iOS.NotificationPermission.RequestAsync();

        NotificationsPlatform.Current = PlatformType.iOS;
        NotificationsPlatform.AttestationService = new AppAttestService(SecureStorageManager.Storage);
#endif
        Console.WriteLine($"[PlutoNotifications] Platform type set: {NotificationsPlatform.Current.ToStringValue()}");

        var isRegistered = await SecureStorageManager.Storage.GetIsRegisteredAsync() ?? false;

        if (isRegistered || await DeviceRegisterService.RegisterDeviceAsync())
            await DeviceRegisterService.UpdateFcmTokenAsync();

        var hasAddress = KeysModel.HasSubstrateKey();
        var isUserIdUpdated = await SecureStorageManager.Storage.GetIsUserIdUpdatedAsync() ?? false;
        if (!isUserIdUpdated && hasAddress)
            await DeviceRegisterService.UpdateUserIdAsync(KeysModel.GetSubstrateKey());
        
        Console.WriteLine($"[PlutoNotifications] Background jobs processed.");
    }
}