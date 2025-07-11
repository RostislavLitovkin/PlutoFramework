using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using WebSocketSharp;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class CreateMnemonicsViewModel : MnemonicsPageViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TitleIsVisible))]
        private string title = "Your wallet has been created!";

        public bool TitleIsVisible => !Title.IsNullOrEmpty();

        public required Func<Task> Navigation;

        [ObservableProperty]
        private string address = "Loading";

        [RelayCommand]
        public async Task ContinueToNextPageAsync()
        {
            await KeysModel.GenerateNewAccountAsync(
                Mnemonics,
                null
            );

            await Navigation.Invoke();
        }
    }
}
