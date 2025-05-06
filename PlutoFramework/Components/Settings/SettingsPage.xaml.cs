using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Components.XcavateProperty;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.View;

namespace PlutoFramework.Components.Settings;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = new SettingsViewModel();
    }

    async void OnPredefinedLayoutsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Navigation.PushAsync(new PredefinedLayoutsPage());
    }

    async void OnLogOutClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        // Authenticate before logging out
        var account = await Model.KeysModel.GetAccountAsync();

        if (account is null)
        {
            return;
        }

        KeysModel.RemoveAccount();
        KeysModel.RemoveAccount("kilt1");

        Preferences.Remove(PreferencesModel.BIOMETRICS_ENABLED);
        Preferences.Remove(PreferencesModel.SHOW_WELCOME_SCREEN);

        await SQLiteModel.DeleteAllDatabasesAsync();

        Application.Current.MainPage = new OnboardingShell();
    }
    async void OnDeveloperSettingsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Navigation.PushAsync(new DeveloperSettingsPage());
    }

    async void OnXcavateProfileClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var userInfo = await XcavateUserDatabase.GetUserInformationAsync();

        if (userInfo is null)
        {
            return;
        }

        var viewModel = new UserProfileViewModel
        {
            CanEdit = true,
            User = userInfo,
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
    private async void OnXcavateCompanyClicked(object sender, TappedEventArgs e)
    {
        var viewModel = new CompanyViewModel();
        viewModel.Company = await XcavateCompanyModel.GetMockCompanyAsync();

        await Navigation.PushAsync(new CompanyPage(viewModel));

    }

    private async void OnPropertyClicked(object sender, TappedEventArgs e)
    {
        /*var viewModel = new PropertyDetailViewModel
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
        await Navigation.PushAsync(new PropertyDetailPage(viewModel));*/
    }

    async void OnShowMnemonicsClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        try
        {
            var secret = await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync();

            await Navigation.PushAsync(new MnemonicsPage(secret));
        }
        catch
        {
            // Failed to authenticate
        }
    }

    async void OnManageKiltDidClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (!Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY + "kilt1"))
        {
            await Navigation.PushAsync(new NoDidPage(new NoDidViewModel()));

            return;
        }

        try
        {
            var secret = await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync(accountVariant: "kilt1");

            await Navigation.PushAsync(new DidManagementPage(secret));
        }
        catch
        {
            // Failed to authenticate
        }
    }

    private async void OnCreateNewPropertyClicked(object sender, TappedEventArgs e)
    {
        /*var property = await XcavatePropertyDatabase.GetPropertyAsync() ?? new UniqueryPlus.Metadata.XcavateMetadata
        {
            Images = [],
            PropertyName = ""
        };

        await Navigation.PushAsync(new ModifyPropertyPage(property));*/
    }
}