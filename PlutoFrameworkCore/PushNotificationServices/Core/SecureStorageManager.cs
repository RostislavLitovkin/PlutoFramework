using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Core;

public static class SecureStorageManager
{
    private static IPushNotificationsSecureStorage? _storage { get; set; }
    
    public static IPushNotificationsSecureStorage Storage
    {
        get => _storage ?? throw new InvalidOperationException(
            "SecureStorage has not been initialized. Call SecureStorageManager.Storage = ... first.");
        set => _storage = value;
    }
}