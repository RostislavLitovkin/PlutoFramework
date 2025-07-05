using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;
namespace PlutoFramework.Components.Settings
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool hasAccount;
        public SettingsViewModel()
        {
            hasAccount = KeysModel.HasSubstrateKey();
        }
    }
}
