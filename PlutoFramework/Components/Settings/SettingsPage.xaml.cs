using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.Components.XCavate;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
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

        var userInfo = await XCavateUserDatabase.GetUserInformationAsync();
        viewModel.User = userInfo ?? await XCavateUserModel.GetMockUserAsync();

        viewModel.ProfilePicture = XCavateFileModel.GetSavedProfilePicture();

        viewModel.ProfileBackground = XCavateFileModel.GetSavedProfileBackground();

        // Clean temporary files
        string tempProfileBackgroundPath = Path.Combine(FileSystem.Current.AppDataDirectory, "temporaryprofilebackground");

        if (File.Exists(tempProfileBackgroundPath))
        {
            File.Delete(tempProfileBackgroundPath);
        }

        string tempProfilePicturePath = Path.Combine(FileSystem.Current.AppDataDirectory, "temporaryprofilepicture");

        if (File.Exists(tempProfilePicturePath))
        {
            File.Delete(tempProfilePicturePath);
        }

        await Navigation.PushAsync(new UserProfilePage(viewModel));
    }

    async void OnShowMnemonicsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if ((await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync()).IsSome(out (string, bool) secretValues))
        {
            await Navigation.PushAsync(new MnemonicsPage(secretValues));
        }
    }
}