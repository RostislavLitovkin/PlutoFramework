using PlutoFrameworkCore.PushNotificationServices.Api;
using PlutoFrameworkCore.PushNotificationServices.Core.Background;
using PlutoFrameworkCore.PushNotificationServices.Core.Misc;
# if ANDROID
using PlutoFramework.Platforms.Android.Attestation;
# elif IOS
using PlutoFrameworkCore.PushNotificationServices.Platforms.iOS;
# endif

namespace PlutoFramework.Model.DeviceSecureStorage;

using NotificationsPlatform = PlutoFrameworkCore.PushNotificationServices.Core.Misc.Platform;

public static class PushNotificationsAppInitializer
{
    private const string RegistrationKey = "device_registered";

    public static async Task InitializeAsync(string apiUrl)
    {
        ApiClient.SetBaseUrl(apiUrl);
        Console.WriteLine($"[PlutoNotifications] API URL set: {apiUrl}");
        
        # if ANDROID
        NotificationsPlatform.Current = PlatformType.Android;
        NotificationsPlatform.AttestationService = new PlayIntegrityService();
        # elif IOS
        NotificationsPlatform.Current = PlatformType.iOS;
        NotificationsPlatform.AttestationService = new AppAttestService();
        # endif
        Console.WriteLine($"[PlutoNotifications] Platform type set: {NotificationsPlatform.Current.ToStringValue()}");
        
        var alreadyRegistered = Preferences.Get(RegistrationKey, false);
        Console.WriteLine($"[PlutoNotifications] Device registered: {alreadyRegistered}");
        
        if (alreadyRegistered) return;

        JobQueue.Enqueue(JobQueue.DeviceRegisterJobKey);
        await JobQueue.SaveQueueAsync();

        Preferences.Set(RegistrationKey, true);

        var bgService = new BackgroundJobService();
        await bgService.RunQueuedJobsAsync();
    }
}