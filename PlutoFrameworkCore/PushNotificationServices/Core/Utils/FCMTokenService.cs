using Plugin.Firebase.CloudMessaging;

namespace PlutoFrameworkCore.PushNotificationServices.Core.Utils;

public static class FCMTokenService
{
    public static async Task<string?> GetTokenAsync()
    {
        try
        {
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
            
            Console.WriteLine($"FCM Token: {token}");
            
            return token;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[PlutoFramework] Error fetching FCM token: {ex.Message}");
            return null;
        }
    }
}