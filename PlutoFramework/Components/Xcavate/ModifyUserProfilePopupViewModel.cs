using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Xcavate
{
    public partial class ModifyUserProfilePopupViewModel : ModifyUserProfileViewModel, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private bool isVisible = false;

        public void SetToDefault()
        {
            IsVisible = false;

            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";
        }
    }
}
