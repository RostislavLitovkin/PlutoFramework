using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Keys
{
    public partial class CanNotRecoverKeyPopupViewModel : ObservableObject, IPopup, ISetToDefault
    {
        public Func<Task> ProceedFunc = () => Task.FromResult(0);

        [ObservableProperty]
        private bool isVisible = false;

        [ObservableProperty]
        private ButtonStateEnum continueButtonState = ButtonStateEnum.Enabled;

        public void SetToDefault()
        {
            IsVisible = false;

            ProceedFunc = () => Task.FromResult(0);
        }

        [RelayCommand]
        public void Cancel() => SetToDefault();

        [RelayCommand]
        public Task ContinueAsync()
        {
            return ProceedFunc.Invoke();

            SetToDefault();
        }
    }
}
