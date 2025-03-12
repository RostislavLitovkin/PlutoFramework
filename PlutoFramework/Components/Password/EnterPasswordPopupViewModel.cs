using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Password
{
    public partial class EnterPasswordPopupViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private bool isVisible = false;

        [ObservableProperty]
        private string password = "";

        [ObservableProperty]
        private bool errorIsVisible = false;

        /// <summary>
        /// returns null if the user decided to cancel
        /// </summary>
        public TaskCompletionSource<string?> EnteredPassword = new();

        public EnterPasswordPopupViewModel()
        {
            SetToDefault();
        }

        [RelayCommand]
        public void Enter()
        {
            EnteredPassword.SetResult(Password);
        }

        [RelayCommand]
        public void Cancel()
        {
            EnteredPassword.SetResult(null);

            SetToDefault();
        }

        public void SetToDefault()
        {
            Password = "";
            IsVisible = false;
            ErrorIsVisible = false;
            EnteredPassword = new ();
        }
    }
}
