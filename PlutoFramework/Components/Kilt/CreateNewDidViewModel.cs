using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.ViewModel;
using WebSocketSharp;

namespace PlutoFramework.Components.Kilt
{
    public partial class CreateNewDidViewModel : MnemonicsViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TitleIsVisible))]
        private string title = "Your DID has been created!";

        public bool TitleIsVisible => !Title.IsNullOrEmpty();

        [ObservableProperty]
        private string did = "Loading";

        public required Func<Task> Navigation;

        [RelayCommand]
        public async Task ContinueToNextPageAsync()
        {
            await KeysModel.GenerateNewAccountAsync(
                Mnemonics,
                null,
                accountVariant: "kilt1"
            );

            await Navigation.Invoke();
        }
    }
}
