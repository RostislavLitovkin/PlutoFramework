namespace PlutoFramework.Components.Messaging;

public partial class MessagingOverviewPage : ContentPage
{
	public MessagingOverviewPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();
	}
}