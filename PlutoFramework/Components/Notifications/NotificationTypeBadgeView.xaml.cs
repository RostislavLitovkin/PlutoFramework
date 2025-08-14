namespace PlutoFramework.Components.Notifications;

public partial class NotificationTypeBadgeView : ContentView
{
    public static readonly BindableProperty NotificationTypeProperty = BindableProperty.Create(
        nameof(NotificationType), typeof(NotificationType), typeof(NotificationTypeBadgeView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NotificationTypeBadgeView)bindable;

            control.label.Text = ((NotificationType)newValue).ToString();

            switch ((NotificationType)newValue)
            {
                case NotificationType.Announcement:
                    control.border.BackgroundColor = Color.FromArgb("#1A888888");
                    break;
                case NotificationType.System:
                    control.border.BackgroundColor = Color.FromArgb("#1A888888");
                    break;
                default:
                    control.border.BackgroundColor = Color.FromArgb("#1A888888");
                    break;
            }
        });
    public NotificationTypeBadgeView()
	{
		InitializeComponent();
	}

    public NotificationType NotificationType
    {
        get => (NotificationType)GetValue(NotificationTypeProperty);
        set => SetValue(NotificationTypeProperty, value);
    }
}