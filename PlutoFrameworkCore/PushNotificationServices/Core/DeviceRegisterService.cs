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
            return false; // leave the job queued
        }

        JobQueue.Dequeue();
        JobQueue.Enqueue(JobQueue.UpdateFCMTokenKey);
        await JobQueue.SaveQueueAsync();
        
        return true;
    }

    public static async Task<bool> UpdateFCMTokenAsync(bool alreadyInQueue = false)
    {
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
            return false;
        }
        
        JobQueue.Dequeue();
        await JobQueue.SaveQueueAsync();
        
        return true;
    }
}