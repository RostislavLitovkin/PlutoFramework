using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Account;

public partial class CreateAccountPopupModel : ObservableObject, IPopup, ISetToDefault
{
  [ObservableProperty]
  private bool isVisible = false;

  [ObservableProperty]
  private ButtonStateEnum continueButtonState = ButtonStateEnum.Disabled;

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

    // Your continue command
  }
}
