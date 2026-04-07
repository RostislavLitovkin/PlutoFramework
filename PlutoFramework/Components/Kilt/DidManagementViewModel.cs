using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Kilt
{
    public partial class DidManagementViewModel : MnemonicsPageViewModel
    {
        [ObservableProperty]
        private string did = "";

        [ObservableProperty]
        private DidVerificationEnum didVerification = (DidVerificationEnum)Enum.Parse(typeof(DidVerificationEnum), Preferences.Get(PreferencesModel.DID_VERIFICATION + "kilt1", DidVerificationEnum.Light.ToString()));

        [RelayCommand]
        public Task GoToDidExplanationPageAsync() => NavigationModel.PushAsync(new DidExplanationPage());

        [RelayCommand]
        public async Task DeleteDIDAsync()
        {
            var token = CancellationToken.None;

            var secret = await Model.KeysModel.GetMnemonicsOrPrivateKeyAsync(accountVariant: "kilt1");

            if (secret == null)
            {
                return;
            }

            KeysModel.RemoveAccount(accountVariant: "kilt1");
        }
    }
}
