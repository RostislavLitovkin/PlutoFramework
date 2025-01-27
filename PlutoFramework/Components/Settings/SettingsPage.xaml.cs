using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.Components.XCavate;
using PlutoFramework.Components.XcavateProperty;
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
        var userInfo = await XCavateUserDatabase.GetUserInformationAsync();

        var viewModel = new UserProfileViewModel
        {
            CanEdit = true,
            User = userInfo ?? await XCavateUserModel.GetMockUserAsync(),
        };

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
    private async void OnXCavateCompanyClicked(object sender, TappedEventArgs e)
    {
        var viewModel = new CompanyViewModel();
        viewModel.Company = await XCavateCompanyModel.GetMockCompanyAsync();

        await Navigation.PushAsync(new CompanyPage(viewModel));

    }

    private async void OnPropertyClicked(object sender, TappedEventArgs e)
    {
        var viewModel = new PropertyDetailViewModel
        {
            AreaPricesPercentage = 0.7,

            RentalDemandPercentage = 0.3,

            CompanyName = "Gade homes",

            CompanyImage = "xcavate.png",

            LocationName = "Herford, Hertfordshire UK",

            PropertyName = "Plot 1 - Plea Wharf",

            ListingPrice = "£200,000",
            Apy = "5%",
            Tokens = 15,
            MaxTokens = 100,
            PropertyType = "Appartment / Flat",

            PropertyDescription = "XCAV is the native token of the Xcavate ecosystem and has several utilities. XCAV will be used in on-chain governance, allowing holders to decide on protocol changes and parameters (such as the protocol fee). This also gives holders the power to allocate funds from the treasury to further the growth and development of the network. The treasury will get an initial allocation of XCAV tokens (see below) and acquire further inflows by collecting protocol fees",

            Blocks = "10",
            Bedrooms = "3",
            Bathrooms = "2",
            Type = "Appartment",
            LocationShortName = "Herford UK",

            UsdtPricePerToken = 2300.0,

            RentalIncome = "£1,000 pcm",

            Images = [
                "https://www.nintendo.com/eu/media/images/assets/nintendo_switch_games/xenobladechroniclesxdefinitiveedition/nswitch_xenobladechroniclesxdefinitiveedition/XenobladeChroniclesXDefinitiveEdition_27.png",
                "https://www.nintendo.com/eu/media/images/assets/nintendo_switch_games/xenobladechroniclesxdefinitiveedition/nswitch_xenobladechroniclesxdefinitiveedition/XenobladeChroniclesXDefinitiveEdition_GP_19.png",
                "xcavatergb.png",
            ]
        };
        await Navigation.PushAsync(new PropertyDetailPage(viewModel));
    }

    async void OnShowMnemonicsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if ((await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync()).IsSome(out (string, bool) secretValues))
        {
            await Navigation.PushAsync(new MnemonicsPage(secretValues));
        }
    }
}