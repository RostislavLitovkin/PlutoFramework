using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Xcavate;
using PlutoFramework.Model;
using PlutoFramework.View;
using PlutoFramework.ViewModel;

namespace PlutoFramework.Components.Account;

public partial class NoAccountPopupModel : ObservableObject, IPopup, ISetToDefault
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
    public async Task CreateAccountAsync()
    {
        SetToDefault();

        await Model.KeysModel.GenerateNewAccountAsync(null, accountVariant: "");

        await Model.KeysModel.GenerateNewAccountAsync(null, accountVariant: "kilt1");

        await Application.Current.MainPage.Navigation.PushAsync(
            new UserTypeSelectionPage()
        );
    }

    [RelayCommand]
    public async Task ImportAccountAsync()
    {
        SetToDefault();

        await Application.Current.MainPage.Navigation.PushAsync(
            new EnterMnemonicsPage(
                new EnterMnemonicsViewModel
                {
                    Navigation = () => Application.Current.MainPage.Navigation.PushAsync(
                        new NoDidPage(
                            new NoDidViewModel
                            {
                                Navigation = NoDidModel.DidNavigateToNextPageAsync
                                // #PyramidCode
                            }
                        )
                    )
                }
            )
        );
    }
}
