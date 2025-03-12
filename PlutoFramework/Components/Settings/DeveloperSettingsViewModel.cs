using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.View;

namespace PlutoFramework.Components.Settings
{
    public partial class DeveloperSettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool displayNetworks = Preferences.Get(PreferencesModel.SETTINGS_DISPLAY_NETWORKS, true);

        [RelayCommand]
        public void ToggleDislayNetworks()
        {
            DisplayNetworks = !DisplayNetworks;

            Preferences.Set(PreferencesModel.SETTINGS_DISPLAY_NETWORKS, DisplayNetworks);

            MainPage.NetworksView.IsVisible = DisplayNetworks;
        }

        [ObservableProperty]
        private bool allowPrivateKey = Preferences.Get(PreferencesModel.SETTINGS_ALLOW_PRIVATE_KEY, false);

        [RelayCommand]
        public void ToggleAllowPrivateKey()
        {
            AllowPrivateKey = !AllowPrivateKey;

            Preferences.Set(PreferencesModel.SETTINGS_ALLOW_PRIVATE_KEY, AllowPrivateKey);
        }
    }
}
