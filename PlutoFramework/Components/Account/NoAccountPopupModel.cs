using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Account;

public partial class NoAccountPopupModel : ObservableObject, IPopup, ISetToDefault
{
    [ObservableProperty]
    private bool isVisible = false;

    public void SetToDefault()
    {
        IsVisible = false;

        // Set more things to default
    }

    [RelayCommand]
    public void Cancel() => SetToDefault();

    [RelayCommand]
    public async Task CreateAccountAsync()
    {
        SetToDefault();

        // Your command
    }

    [RelayCommand]
    public async Task ImportAccountAsync()
    {
        SetToDefault();

        // Your command
    }
}
