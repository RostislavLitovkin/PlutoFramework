using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Components.Password;
using PlutoFramework.Model;
using PlutoFrameworkCore;

namespace PlutoFramework.Components.Account;

public partial class NoAccountPopupViewModel : ObservableObject, IPopup, ISetToDefault
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
    public Task CreateAccountAsync() => Application.Current.MainPage.Navigation.PushAsync(new SetupPasswordPage()
        {
            Navigation = CreateAccountNavigationAsync
        });
    

    public async Task CreateAccountNavigationAsync()
    {
        SetToDefault();

        await PlutoConfigurationModel.GenerateNewAccountAsync();

        await NavigationModel.NavigateAfterAccountCreation.Invoke();
    }

    [RelayCommand]
    public async Task ImportAccountAsync()
    {
        SetToDefault();

        await Shell.Current.Navigation.PushAsync(new SetupPasswordPage()
        {
            Navigation = () => Shell.Current.Navigation.PushAsync(
               new EnterMnemonicsPage(
                   new EnterMnemonicsViewModel
                   {
                       Navigation = () => Shell.Current.Navigation.PushAsync(
                           new NoDidPage()
                       )
                   }
               )
            )
        });
    }
}
