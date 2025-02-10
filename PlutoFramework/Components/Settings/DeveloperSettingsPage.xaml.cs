using PlutoFramework.Components.CustomLayouts;

namespace PlutoFramework.Components.Settings;

public partial class DeveloperSettingsPage : ContentPage
{
	public DeveloperSettingsPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = new DeveloperSettingsViewModel();
    }

    private async void OnCreateCustomLayoutsClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CustomLayoutsPage());
    }
}