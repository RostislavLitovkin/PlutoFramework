using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class MnemonicsViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Hidden))]
        private bool mnemonicsIsVisble = false;

        public bool Hidden => !MnemonicsIsVisble;

        [RelayCommand]
        public void HideUnhide()
        {
            MnemonicsIsVisble = !MnemonicsIsVisble;
        }
    }
}
