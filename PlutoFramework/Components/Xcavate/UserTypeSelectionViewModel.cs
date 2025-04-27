using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class UserTypeSelectionViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task SelectDeveloperAsync() => await Application.Current.MainPage.Navigation.PushAsync(
            new ModifyUserProfilePage(
                new ModifyUserProfileViewModel
                {
                    UserRole = UserRoleEnum.Developer,
                    ContinueLayoutIsVisible = true,
                }
            )
        );
    }
}
