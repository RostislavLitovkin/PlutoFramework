using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.ViewModel;

namespace PlutoFramework.Components.Kilt
{
    public partial class DidManagementViewModel : MnemonicsViewModel
    {
        [ObservableProperty]
        private string did = "";

        [ObservableProperty]
        private DidVerificationEnum didVerification = DidVerificationEnum.Light;

        [RelayCommand]
        public Task GoToDidExplanationPageAsync() => Application.Current.MainPage.Navigation.PushAsync(new DidExplanationPage());

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
