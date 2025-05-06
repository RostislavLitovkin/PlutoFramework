using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class UserTypeSelectionViewModel : ObservableObject
    {
        [RelayCommand]
        public void SelectDeveloper()
        {
            var modifyUserProfileViewModel = DependencyService.Get<ModifyUserProfilePopupViewModel>();
            modifyUserProfileViewModel.IsVisible = true;
        }
    }
}
