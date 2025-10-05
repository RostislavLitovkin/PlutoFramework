using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Sumsub
{
    public partial class NoKYCPopupViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private bool isVisible = false;

        [ObservableProperty]
        private ButtonStateEnum continueButtonState = ButtonStateEnum.Enabled;

        public void SetToDefault()
        {
            IsVisible = false;

            // Set more things to default
        }

        [RelayCommand]
        public void Cancel() => SetToDefault();

        [RelayCommand]
        public async Task ContinueAsync()
        {
            SetToDefault();

            await NavigationModel.NavigateToKYC.Invoke();
        }
    }
}
