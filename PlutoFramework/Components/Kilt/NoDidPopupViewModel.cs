using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Kilt
{
    public partial class NoDidPopupViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private bool isVisible = false;

        public void SetToDefault()
        {
            IsVisible = false;
        }

        [RelayCommand]
        public void Cancel() => SetToDefault();

        [RelayCommand]
        public async Task CreateDIDAsync()
        {
            SetToDefault();

            await Model.KeysModel.GenerateNewAccountAsync(accountVariant: "kilt1");

            await NavigationModel.NavigateAfterAccountCreation.Invoke();
        }

        [RelayCommand]
        public async Task ImportDIDAsync()
        {
            SetToDefault();

            await Shell.Current.Navigation.PushAsync(
                new ImportDidPage()
            );
        }
    }
}
