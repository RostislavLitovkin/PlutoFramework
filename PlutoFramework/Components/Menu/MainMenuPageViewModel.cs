
using XcavatePaseo.NetApi.Generated;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Menu
{
    public partial class MainMenuPageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [NotifyPropertyChangedFor(nameof(UserRole))]
        private XcavateUser? user;

        public string FullName => User is not null ? $"{User.FirstName} {User.LastName}" : "None";

        public UserRoleEnum UserRole => User is not null ? User.Role : UserRoleEnum.None;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private VerificationEnum verification = VerificationEnum.Loading;
        
        public MainMenuPageViewModel()
        {
            address = Preferences.Get(PreferencesModel.PUBLIC_KEY, "None");

            _ = LoadUserAsync();

            _ = LoadVerificationAsync();
        }

        private async Task LoadUserAsync()
        {
            User = await XcavateUserDatabase.GetUserInformationAsync();
        }

        private async Task LoadVerificationAsync()
        {
            if (!Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY))
            {
                Verification = VerificationEnum.None;
            }

            var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(EndpointEnum.XcavatePaseo, CancellationToken.None);

            var verification = await WhitelistModel.IsWhitelistedAsync((SubstrateClientExt)client.SubstrateClient, PreferencesModel.PUBLIC_KEY, CancellationToken.None);

            Verification = verification;
        }

        [RelayCommand]
        public Task OpenSettingsAsync() => NavigationModel.NavigateToSettingsPageAsync();

        [RelayCommand]
        public Task OpenQrScannerAsync() => NavigationModel.NavigateToQrScannerPageAsync();

        [RelayCommand]
        public Task OpenUserAsync() => NavigationModel.NavigateToUserPageAsync();

        [RelayCommand]
        public Task WalletActionAsync() => NavigationModel.NavigateToBalancesPageAsync();

        [RelayCommand]
        public Task SecurityActionAsync()
        {
            return Task.FromResult(0);
        }

        [RelayCommand]
        public Task KYCActionAsync()
        {
            return Task.FromResult(0);
        }

        [RelayCommand]
        public Task SupportActionAsync()
        {
            return Task.FromResult(0);
        }
    }
}
