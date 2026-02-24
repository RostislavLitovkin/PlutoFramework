using UIKit;
using UserNotifications;

namespace PlutoFramework.Platforms.iOS;

public static class NotificationPermission
{
    public static async Task<bool> RequestAsync()
    {
        var (approved, err) = await UNUserNotificationCenter.Current.RequestAuthorizationAsync(
            UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound);
        
        if (approved)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(
                UIApplication.SharedApplication.RegisterForRemoteNotifications
            );
        }
        
        return approved;
    }
}