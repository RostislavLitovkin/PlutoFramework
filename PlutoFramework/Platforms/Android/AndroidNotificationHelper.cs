using Android.App;
using Android.Content;
using AndroidX.Core.App;
using AndroidX.Core.Graphics.Drawable;

namespace PlutoFramework.Platforms.Android
{

    /// <summary>
    /// Source: https://www.youtube.com/watch?v=Q_renpfnbk4
    /// </summary>
    public class AndroidNotificationHelper
    {
        public static int AppIcon { get; set; } /* CommunityToolkit.Maui.Core.Resource.Drawable.resourceappicon */

        public static Type MainActivityType { get; set; } /* typeof(MainActivity); */

        private static string foregroundChannelId = "96062"; // Random id

        private static readonly Context context = global::Android.App.Application.Context;
        public Notification GetNotification(
            string title,
            string description
              
        )
        {
            var intent = new Intent(context, MainActivityType);
            intent.AddFlags(ActivityFlags.SingleTop);
            intent.PutExtra(title, description);

            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.Immutable | PendingIntentFlags.UpdateCurrent);

            var notificationBuilder = new NotificationCompat.Builder(context, foregroundChannelId)
                .SetContentTitle(title)
                .SetContentText(description)
                .SetSmallIcon(AppIcon)
                .SetContentIntent(pendingIntent)
                .SetOngoing(true);

            NotificationChannel notificationChannel = new NotificationChannel(foregroundChannelId, "PlutoFramework", NotificationImportance.High);
            notificationChannel.Importance = NotificationImportance.High;
            notificationChannel.EnableLights(true);
            notificationChannel.EnableVibration(true);
            notificationChannel.SetShowBadge(true);
            notificationChannel.SetVibrationPattern([100, 200, 300]);


            NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            notificationBuilder.SetChannelId(foregroundChannelId);
            notificationManager.CreateNotificationChannel(notificationChannel);

            return notificationBuilder.Build();
        }
    }
}
