namespace PlutoFrameworkCore.PushNotificationServices.Core.Background;

public class BackgroundJobService ()
{
    public async Task RunQueuedJobsAsync()
    {
        while (JobQueue.Count > 0)
        {
            var t = JobQueue.Peek()!.Type switch
            {
                JobQueue.DeviceRegisterJobKey => DeviceRegisterService.RegisterDeviceAsync(true),
                JobQueue.UpdateFCMTokenKey => DeviceRegisterService.UpdateFCMTokenAsync(true),
                _ => throw new Exception("Case not covered"),
            };

            if (!await t) break;
        }
    }
}