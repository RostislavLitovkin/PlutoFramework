using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Components.XCavate
{
    public partial class UserProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        [NotifyPropertyChangedFor(nameof(ProfilePicture))]
        [NotifyPropertyChangedFor(nameof(ProfileBackground))]
        [NotifyPropertyChangedFor(nameof(AccountCreatedAtText))]
        [NotifyPropertyChangedFor(nameof(UserRole))]
        [NotifyPropertyChangedFor(nameof(DeveloperStatsIsVisible))]
        [NotifyPropertyChangedFor(nameof(ActiveListedProperties))]
        [NotifyPropertyChangedFor(nameof(PropertyTokensSold))]
        [NotifyPropertyChangedFor(nameof(TotalSales))]
        [NotifyPropertyChangedFor(nameof(AverageSaleTime))]
        [NotifyPropertyChangedFor(nameof(FirstName))]
        [NotifyPropertyChangedFor(nameof(LastName))]
        [NotifyPropertyChangedFor(nameof(Email))]
        [NotifyPropertyChangedFor(nameof(PhoneNumber))]
        private XCavateUser user = new XCavateUser
        {
            FirstName = "",
            LastName = "",
            ProfilePicture = null,
            ProfileBackground = null,
            AccountCreatedAt = null,
            Role = UserRoleEnum.None,
            Email = "",
            PhoneNumber = "",
            DeveloperStats = null,
        };
        public string FullName => $"{User.FirstName} {User.LastName}";
        public string ProfilePicture => User.ProfilePicture ?? "xcavate.png";
        public string ProfileBackground => User.ProfileBackground ?? "whitebackground.png";
        public string AccountCreatedAtText => User.AccountCreatedAt is null ? "" : $"Account created {User.AccountCreatedAt?.ToString("MMMM")}, {User.AccountCreatedAt?.Year}";
        public UserRoleEnum UserRole => User.Role;
        public bool DeveloperStatsIsVisible => User.Role == UserRoleEnum.Developer;
        public string ActiveListedProperties => User.DeveloperStats?.ActiveListedProperties.ToString() ?? "0";
        public string PropertyTokensSold => User.DeveloperStats?.PropertyTokensSold.ToString() ?? "0";
        public string TotalSales => User.DeveloperStats?.TotalSales.ToString() ?? "0";
        public string AverageSaleTime => User.DeveloperStats?.AverageSaleTime.ToString() ?? "0";
        public string FirstName => User.FirstName;
        public string LastName => User.LastName;
        public string Email => User.Email;
        public string PhoneNumber => User.PhoneNumber;
    }
}
