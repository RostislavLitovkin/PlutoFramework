using PlutoFrameworkCore.PushNotificationServices.Core.Utils;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Background;

public static class JobQueue
{
    public const string DeviceRegisterJobKey = "RegisterDevice";
    public const string UpdateFCMTokenKey = "UpdateFCMToken";
    
    private static Queue<BackgroundJob> _q = new ();

    public static async Task LoadQueueAsync()
    {
        _q = await SecureStorageManager.Storage.GetJobQueueAsync() ?? new Queue<BackgroundJob>();
    }

    public static async Task SaveQueueAsync()
    {
        await SecureStorageManager.Storage.SaveJobQueueAsync(_q);
    }

    public static void Enqueue(string type, string payload = "")
    {
        _q.Enqueue(new BackgroundJob { Type = type, Payload = payload });
    }

    public static BackgroundJob? Dequeue()
    {
        if (_q.Count == 0) return null;
        return _q.Dequeue();
    }

    public static BackgroundJob? Peek()
    {
        if (_q.Count == 0) return null;
        return _q.Peek();
    }

    public static int Count => _q.Count;
}