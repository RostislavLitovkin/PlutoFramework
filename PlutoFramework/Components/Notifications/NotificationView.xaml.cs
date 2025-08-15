using PlutoFramework.Components.Messaging;

namespace PlutoFramework.Components.Notifications;

public partial class NotificationView : ContentView
{
	public NotificationView()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.Navigation.PushAsync(new MessagingOverviewPage());
    }
}