using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Nft;
using PlutoFramework.Model.Xcavate;
using PlutoFrameworkCore.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class CompanyViewModel : BaseListViewModel<uint, XcavateCompanyUser>
    {
        public override string Title => "Company page";

        private IAsyncEnumerator<XcavateCompanyUser> userEnumerator = null;

        public override async Task LoadMoreAsync(CancellationToken token)
        {
            if (Loading)
            {
                return;
            }

            if (userEnumerator == null)
            {
                return;
            }

            Loading = true;

            try
            {
                for (uint i = 0; i < LIMIT; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    if (userEnumerator != null && await userEnumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var user = userEnumerator.Current;

                        Console.WriteLine("User name: " + user.FullName);

                        if (user.Id is not null && !ItemsDict.ContainsKey(user.Id.Value))
                        {
                            ItemsDict.Add(user.Id.Value, user);

                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                Console.WriteLine("User name: " + user.FullName + "   " + user.Id);

                                Items.Add(user);
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nft owned list error: ");
                Console.WriteLine(ex);
            }

            Loading = false;

        }

        public override async Task InitialLoadAsync(CancellationToken token)
        {
            Console.WriteLine($"Initial load: Company id {Company?.CompanyId}");

            if (Company?.CompanyId is null)
            {
                return;
            }

            var asyncEnumerable = XcavateCompanyModel.GetMockCompanyUsersAsync(Company.CompanyId.Value, 25);
            userEnumerator = asyncEnumerable.GetAsyncEnumerator(token);

            await LoadMoreAsync(token);

            Console.WriteLine("Initial load ended");
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CompanyName))]
        [NotifyPropertyChangedFor(nameof(RegistrationNumber))]
        [NotifyPropertyChangedFor(nameof(PhoneNumber))]
        [NotifyPropertyChangedFor(nameof(Email))]
        [NotifyPropertyChangedFor(nameof(Website))]
        [NotifyPropertyChangedFor(nameof(Address))]
        [NotifyPropertyChangedFor(nameof(AssociatedMembershipNumber))]
        [NotifyPropertyChangedFor(nameof(PassportOrDriversLicenseVerified))]
        private XcavateCompany company;
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
