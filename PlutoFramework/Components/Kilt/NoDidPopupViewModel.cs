using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Kilt
{
    public partial class NoDidPopupViewModel : ObservableObject, IPopup, ISetToDefault
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
        public void Cancel() => SetToDefault();

        [RelayCommand]
        public async Task CreateDIDAsync()
        {
            SetToDefault();

            await Model.KeysModel.GenerateNewAccountAsync(null, accountVariant: "kilt1");

            // TODO
            /*await Application.Current.MainPage.Navigation.PushAsync(
                new UserTypeSelectionPage()
            );*/
        }

        [RelayCommand]
        public async Task ImportDIDAsync()
        {
            SetToDefault();

            await Application.Current.MainPage.Navigation.PushAsync(
                new ImportDidPage(
                    new ImportDidViewModel
                    {
                        Navigation = () =>
                        {
                            // TODO
                            //NoDidModel.DidNavigateToNextPageAsync

                            return Task.FromResult(0);
                        }
                        // #PyramidCode
                    }
                )
            );
        }
    }
}
