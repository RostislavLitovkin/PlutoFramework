using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Kilt;
using PlutoFrameworkCore.Keys;

namespace PlutoFramework.Components.Keys
{
    public partial class DidKeyDetailPageViewModel : BaseDetailPageViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Mnemonics))]
        private DidKey? unlockedKey;

        public string Mnemonics => UnlockedKey?.Mnemonics ?? "No mnemonics";

        [ObservableProperty]
        private DidVerificationEnum didVerification = DidVerificationEnum.Light;

        [RelayCommand]
        public Task GoToDidExplanationPageAsync() => Shell.Current.Navigation.PushAsync(new DidExplanationPage());
    }
}
