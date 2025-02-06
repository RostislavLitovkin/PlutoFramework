using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class UserProfileViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool canEdit;

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
        private XcavateUser user = new XcavateUser
        {
            FirstName = "",
            LastName = "",
            ProfileBackground = null,
            ProfilePicture = null,
            Role = UserRoleEnum.None,
            Email = "",
            PhoneNumber = "",
            AccountCreatedAt = null,
            DeveloperStats = null,
        };
        public string FullName => User.FullName;
        public ImageSource ProfilePicture => User.ProfilePicture;
        public ImageSource ProfileBackground => User.ProfileBackground;
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

        [RelayCommand]
        public Task EditAsync() => Application.Current.MainPage.Navigation.PushAsync(new ModifyUserProfilePage(
            new ModifyUserProfileViewModel
            {
                Title = "Modify personal profile",
                ProfilePicture = XcavateFileModel.GetSavedProfilePicture(),
                ProfileBackground = XcavateFileModel.GetSavedProfileBackground(),
                FirstName = User.FirstName,
                LastName = User.LastName,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
            }));
    }
}
