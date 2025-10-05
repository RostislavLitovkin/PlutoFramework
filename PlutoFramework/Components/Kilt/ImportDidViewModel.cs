
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Kilt
{
    public partial class ImportDidViewModel : ObservableObject
    {
        [ObservableProperty]
        private string mnemonics = "";

        public required Func<Task> Navigation;

        [RelayCommand]
        public async Task ContinueToNextPageAsync()
        {
            await Model.KeysModel.GenerateNewAccountAsync(
                Mnemonics,
                accountVariant: "kilt1"
            );

            await Navigation.Invoke();
        }
    }
}
