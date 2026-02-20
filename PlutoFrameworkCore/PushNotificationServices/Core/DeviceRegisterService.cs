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
                await ApiClient.RegisterDeviceRequestAsync()
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

    public static async Task<bool> UpdateFcmTokenAsync()
    {
        if (!(await SecureStorageManager.Storage.GetIsRegisteredAsync() ?? false))
        {
            Console.WriteLine($"[PlutoNotifications] Device is not registered, cannot update FCM token");
            return false;
        }
        if (!(await SecureStorageManager.Storage.GetFcmTokenExpiredAsync() ?? true))
        {
            Console.WriteLine($"[PlutoNotifications] FCM token is up-to-date, skipping ...");
            return true;
        }
        Console.WriteLine($"[PlutoNotifications] Trying to update FCM token ...");

        try
        {
            await RetryHelper.RunWithRetryAsync(async () =>
                await ApiClient.UpdateFcmTokenRequestAsync(
                    (await FcmTokenService.GetTokenAsync())!
                )
            );
        }
        catch (Exception e)
        {
            Console.WriteLine($"[PlutoNotifications] Token update failed ...");
            return false;
        }
        
        await SecureStorageManager.Storage.SaveFcmTokenExpiredAsync(false);
        Console.WriteLine($"[PlutoNotifications] Token has been updated  ...");
        return true;
    }
}