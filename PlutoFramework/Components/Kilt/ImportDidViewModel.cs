
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Keys;
using PlutoFramework.Model;
using PlutoFrameworkCore;

namespace PlutoFramework.Components.Kilt
{
    public partial class ImportDidViewModel : ObservableObject
    {
        public Func<Task> Navigation = NavigationModel.NavigateAfterAccountCreation;

        [ObservableProperty]
        private bool incorrectMnemonicsEntered = false;

        [ObservableProperty]
        private string mnemonics = "";

        [RelayCommand]
        public async Task ContinueToNextPageAsync()
        {
            try
            {
                await Model.KeysModel.SaveDidKeyAsync(
                    Mnemonics
                );

                await Navigation.Invoke();

            }
            catch
            {
                IncorrectMnemonicsEntered = true;
            }
        }

        [RelayCommand]
        public void ForgotKey()
        {
            var popupViewModel = DependencyService.Get<CanNotRecoverKeyPopupViewModel>();

            popupViewModel.ProceedFunc = GenerateNewDidAsync;

            popupViewModel.IsVisible = true;
        }

        public async Task GenerateNewDidAsync()
        {
            await Model.KeysModel.GenerateNewDidAsync();

            await Navigation.Invoke();
        }
    }
}
