using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;

namespace PlutoFramework.ViewModel
{
    public partial class EnterMnemonicsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mnemonics = "";

        [ObservableProperty]
        private string privateKey = "";

        [ObservableProperty]
        private bool usePrivateKeyIsVisible = Preferences.Get(PreferencesModel.SETTINGS_ALLOW_PRIVATE_KEY, false);
    }
}
