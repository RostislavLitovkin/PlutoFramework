
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Kilt
{
    public partial class ImportDidViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mnemonics = "";

        [RelayCommand]
        public async Task ContinueToNextPageAsync()
        {
            await Model.KeysModel.GenerateNewAccountAsync(
                Mnemonics,
                accountVariant: "kilt1"
            );

            await NavigationModel.NavigateAfterAccountCreation.Invoke();
        }
    }
}
