using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Components.XCavate
{
    public partial class CompanyViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CompanyName))]
        [NotifyPropertyChangedFor(nameof(RegistrationNumber))]
        [NotifyPropertyChangedFor(nameof(PhoneNumber))]
        [NotifyPropertyChangedFor(nameof(Email))]
        [NotifyPropertyChangedFor(nameof(Website))]
        [NotifyPropertyChangedFor(nameof(Address))]
        [NotifyPropertyChangedFor(nameof(AssociatedMembershipNumber))]
        [NotifyPropertyChangedFor(nameof(PassportOrDriversLicenseVerified))]
        private XCavateCompany company;
        public string CompanyName => Company.CompanyName;
        public string RegistrationNumber => Company.RegistrationNumber;
        public string PhoneNumber => Company.PhoneNumber;
        public string Email => Company.Email;
        public string Website => Company.Website;
        public string Address => Company.Address;
        public string AssociatedMembershipNumber => Company.AssociatedMembershipNumber;
        public VerificationEnum PassportOrDriversLicenseVerified => Company.PassportOrDriversLicense.VerificationStatus;

        [RelayCommand]
        public async Task EditAsync() => await Application.Current.MainPage.Navigation.PushAsync(new ModifyCompanyPage(
            new ModifyCompanyViewModel
            {
                Title = "Modify company",
                CompanyName = Company.CompanyName,
                RegistrationNumber = Company.RegistrationNumber,
                PhoneNumber = Company.PhoneNumber,
                Email = Company.Email,
                Website = Company.Website,
                Address = Company.Address,
                AssociatedMembershipNumber = Company.AssociatedMembershipNumber,
            }));

        [RelayCommand]
        public async Task ViewDocumentAsync()
        {
            await Task.FromResult(0);
        }
    }
}
