using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class CreateMnemonicsViewModel : MnemonicsPageViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TitleIsVisible))]
        private string title = "Your wallet has been created!";

        public bool TitleIsVisible => !string.IsNullOrEmpty(Title);

        public required Func<Task> Navigation;

        [ObservableProperty]
        private string address = "Loading";

        [RelayCommand]
        public async Task ContinueToNextPageAsync()
        {
            await KeysModel.SaveSr25519KeyAsync(
                Mnemonics
            );

            await Navigation.Invoke();
        }
    }
}
