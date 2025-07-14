using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Components.Password;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Account;

public partial class NoAccountPopupViewModel : ObservableObject, IPopup, ISetToDefault
{
    // TODO: Temporary fix
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Func<Task> AfterCreateAccountNavigation { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

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

        await Model.KeysModel.GenerateNewAccountAsync(accountVariant: "");

        await Model.KeysModel.GenerateNewAccountAsync(accountVariant: "kilt1");

        await AfterCreateAccountNavigation.Invoke();
    }

    [RelayCommand]
    public async Task ImportAccountAsync()
    {
        SetToDefault();

        await Application.Current.MainPage.Navigation.PushAsync(new SetupPasswordPage()
        {
            Navigation = () => Application.Current.MainPage.Navigation.PushAsync(
               new EnterMnemonicsPage(
                   new EnterMnemonicsViewModel
                   {
                       Navigation = () => Shell.Current.Navigation.PopToRootAsync()
                   }
               )
            )
        });
    }
}
