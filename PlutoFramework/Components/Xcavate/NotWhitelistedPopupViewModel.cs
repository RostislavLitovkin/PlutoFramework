using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Xcavate
{
    public partial class NotWhitelistedPopupViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private bool isVisible = false;

        [ObservableProperty]
        private ButtonStateEnum continueButtonState = ButtonStateEnum.Enabled;

        public void SetToDefault()
        {
            IsVisible = false;
        }

        [RelayCommand]
        public void Continue()
        {
            SetToDefault();
        }
    }
}
