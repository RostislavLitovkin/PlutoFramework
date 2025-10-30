using PlutoFrameworkCore.PushNotificationServices.Api;
using PlutoFrameworkCore.PushNotificationServices.Core.Background;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;
using PlutoFrameworkCore.PushNotificationServices.Core.Utils;

namespace PlutoFrameworkCore.PushNotificationServices.Core;

public static class DeviceRegisterService
{
    public static async Task<bool> RegisterDeviceAsync(bool alreadyInQueue = false)
    {
        Console.WriteLine($"[PlutoNotifications] Trying to register device ...");
        if (!alreadyInQueue)
        {
            // queue the job in case of interrupting the app process
            JobQueue.Enqueue(JobQueue.DeviceRegisterJobKey);
            await JobQueue.SaveQueueAsync();
        }

        try
        {
            await RetryHelper.RunWithRetryAsync(async () =>
                await ApiClient.RegisterDeviceRequestAsync(await UUIDService.GetInstallationUUIDAsync())
            );
        }
        catch (Exception e)
        {
            Console.WriteLine($"[PlutoNotifications] Device registration failed ...");
            return false; // leave the job queued
        }

        JobQueue.Dequeue();
        JobQueue.Enqueue(JobQueue.UpdateFCMTokenKey);
        await JobQueue.SaveQueueAsync();
        
        Console.WriteLine($"[PlutoNotifications] Device has been registered ...");
        return true;
    }

    public static async Task<bool> UpdateFCMTokenAsync(bool alreadyInQueue = false)
    {
        Console.WriteLine($"[PlutoNotifications] Trying to update FCM token ...");
        if (!alreadyInQueue)
        {
            JobQueue.Enqueue(JobQueue.UpdateFCMTokenKey);
            await JobQueue.SaveQueueAsync();
        }

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
        
        JobQueue.Dequeue();
        await JobQueue.SaveQueueAsync();
        
        Console.WriteLine($"[PlutoNotifications] Token has been updated  ...");
        return true;
    }
}