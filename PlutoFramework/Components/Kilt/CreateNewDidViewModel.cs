using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Model;
using WebSocketSharp;

namespace PlutoFramework.Components.Kilt
{
    public partial class CreateNewDidViewModel : MnemonicsPageViewModel
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
            await KeysModel.SaveDidKeyAsync(
                this.Mnemonics
            );

            await Navigation.Invoke();
        }
    }
}
