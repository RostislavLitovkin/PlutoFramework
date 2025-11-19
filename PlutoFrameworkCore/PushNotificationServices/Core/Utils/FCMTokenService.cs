using Plugin.Firebase.CloudMessaging;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public static class FCMTokenService
{
    public static async Task<string?> GetTokenAsync()
    {
        try
        {
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
            
            return token;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PlutoNotifications] Couldn't fetch FCM token");
            return null;
        }
    }
}