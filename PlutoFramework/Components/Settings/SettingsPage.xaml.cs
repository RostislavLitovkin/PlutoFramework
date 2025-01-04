using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.Components.XCavate;
using PlutoFramework.Model.XCavate;
using PlutoFramework.View;

namespace PlutoFramework.Components.Settings;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();
	}

    async void OnPredefinedLayoutsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Navigation.PushAsync(new PredefinedLayoutsPage());
    }

    async void OnLogOutClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Preferences.Remove("publicKey");
        SecureStorage.Default.Remove("privateKey");
        SecureStorage.Default.Remove("mnemonics");
        SecureStorage.Default.Remove("password");
        Preferences.Remove("biometricsEnabled");

        // Delete Local SQLite databases

        Application.Current.MainPage = new SetupPasswordPage();
    }

    async void OnDeveloperSettingsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Navigation.PushAsync(new DeveloperSettingsPage());
    }

    async void OnXCavateProfileClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var viewModel = new UserProfileViewModel();

        await Navigation.PushAsync(new UserProfilePage(viewModel));

        viewModel.User = await XCavateUserModel.GetMockUserAsync();
    }

    async void OnShowMnemonicsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if ((await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync()).IsSome(out (string, bool) secretValues))
        {
            await Navigation.PushAsync(new MnemonicsPage(secretValues));
        }
    }
}