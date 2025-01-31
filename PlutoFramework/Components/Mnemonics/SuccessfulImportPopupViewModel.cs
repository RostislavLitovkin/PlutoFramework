using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Mnemonics
{
    public partial class SuccessfulImportPopupViewModel : ObservableObject, IPopup
    {
        [ObservableProperty]
        private bool isVisible = false;

        [RelayCommand]
        public void Dismiss()
        {
            IsVisible = false;
        }
    }
}
