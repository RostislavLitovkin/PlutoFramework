namespace PlutoFrameworkCore.PushNotificationServices.Core.Background;

public static class BackgroundJobService
{
    public static async Task RunQueuedJobsAsync()
    {
        Console.WriteLine($"[PlutoNotifications] Checking background job queue ...");
        while (JobQueue.Count > 0)
        {
            var t = JobQueue.Peek()!.Type switch
            {
                JobQueue.DeviceRegisterJobKey => DeviceRegisterService.RegisterDeviceAsync(true),
                JobQueue.UpdateFCMTokenKey => DeviceRegisterService.UpdateFCMTokenAsync(true),
                _ => throw new Exception("Case not covered"),
            };
            Console.WriteLine($"[PlutoNotifications] Background job started: {JobQueue.Peek()!.Type}");

            if (!await t) break;
        }
    }
}