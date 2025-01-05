

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Model;

namespace PlutoFramework.Components.XCavate
{
    public partial class ModifyCompanyViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string companyName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string registrationNumber;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string phoneNumber;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string email;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string website;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string address;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SaveButtonState))]
        private string associatedMembershipNumber;

        //[ObservableProperty]
        //private PassportOrDriversLicense passportOrDriversLicense;

        public ButtonStateEnum SaveButtonState => CompanyName != "" && RegistrationNumber != "" && PhoneNumber != "" && FormModel.IsValidEmail(Email) && Website != "" && Address != "" && AssociatedMembershipNumber != "" ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

        [RelayCommand]
        public async Task SaveAsync()
        {
            // Save

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        public Task CancelAsync() => Application.Current.MainPage.Navigation.PopAsync();

    }
}
