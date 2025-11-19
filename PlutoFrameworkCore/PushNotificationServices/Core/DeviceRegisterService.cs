using PlutoFrameworkCore.PushNotificationServices.Api;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;

namespace PlutoFrameworkCore.PushNotificationServices.Core;

public static class DeviceRegisterService
{
    public static async Task<bool> RegisterDeviceAsync()
    {
        if (await SecureStorageManager.Storage.GetIsRegisteredAsync() ?? false)
        {
            Console.WriteLine($"[PlutoNotifications] Device is already registered, skipping ...");
            return true;
        }
        Console.WriteLine($"[PlutoNotifications] Trying to register device ...");

        try
        {
            await RetryHelper.RunWithRetryAsync(async () =>
                await ApiClient.RegisterDeviceRequestAsync(await UUIDService.GetInstallationUUIDAsync())
            );
        }
        catch (Exception e)
        {
            Console.WriteLine($"[PlutoNotifications] Device registration failed ...");
            return false;
        }

        await SecureStorageManager.Storage.SaveIsRegisteredAsync(true);
        Console.WriteLine($"[PlutoNotifications] Device has been registered ...");
        return true;
    }

    public static async Task<bool> UpdateFCMTokenAsync()
    {
        if (!(await SecureStorageManager.Storage.GetFCMTokenExpiredAsync() ?? true))
        {
            Console.WriteLine($"[PlutoNotifications] FCM token is up-to-date, skipping ...");
            return true;
        }
        Console.WriteLine($"[PlutoNotifications] Trying to update FCM token ...");

        try
        {
            await RetryHelper.RunWithRetryAsync(async () =>
                await ApiClient.UpdateFCMTokenRequestAsync(
                    (await FCMTokenService.GetTokenAsync())!
                )
            );
        }
        catch (Exception e)
        {
            Console.WriteLine($"[PlutoNotifications] Token update failed ...");
            return false;
        }
        
        await SecureStorageManager.Storage.SaveFCMTokenExpiredAsync(false);
        Console.WriteLine($"[PlutoNotifications] Token has been updated  ...");
        return true;
    }
}