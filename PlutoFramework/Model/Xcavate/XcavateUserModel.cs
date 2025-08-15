using XcavatePaseo.NetApi.Generated.Model.pallet_xcavate_whitelist.pallet;

namespace PlutoFramework.Model.Xcavate
{
    public enum UserRoleEnum
    {
        // Has to be here due to Data binding
        None,

        Developer,
        Investor,
        LettingAgent,
        Lawyer
    }

    public static class UserRoleEnumExtensions
    {
        public static Role ToWhitelistRole(this UserRoleEnum role)
        {
            return role switch
            {
                UserRoleEnum.Developer => Role.RealEstateDeveloper,
                UserRoleEnum.Investor => Role.RealEstateInvestor,
                UserRoleEnum.LettingAgent => Role.LettingAgent,
                UserRoleEnum.Lawyer => Role.Lawyer
            };
        }
    }
    public record DeveloperStats
    {
        public required int ActiveListedProperties { get; set; }
        public required int PropertyTokensSold { get; set; }
        public required int TotalSales { get; set; }
        public required int AverageSaleTime { get; set; }
    }
    public record XcavateUser
    {
        public required ImageSource ProfilePicture { get; set; }
        public required ImageSource ProfileBackground { get; set; }
        public required UserRoleEnum Role { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; 
        public required DateTime? AccountCreatedAt { get; set; }
        public DeveloperStats? DeveloperStats { get; set; }
        public uint? Id { get; set; } = null;
    }

    public enum CompanyUserStatusEnum
    {
        // Has to be here due to Data binding
        None,

        Invited,
        Active
    }
    public record XcavateCompanyUser : XcavateUser
    {
        public required CompanyUserStatusEnum CompanyUserStatus { get; set; }
        public required DateTime? AddedAt { get; set; }
        public string AddedAtText => !AddedAt.HasValue ? "Unknown" : $"{AddedAt.Value.ToString("MMMM")} / {AddedAt.Value.ToString("dd")} / {AddedAt.Value.ToString("yyyy")}";
        public required uint[] CompanyIds { get; set; }
        public required VerificationEnum Verification { get; set; }
    }
    public class XcavateUserModel
    {
        public static async Task<XcavateUser> GetMockUserAsync()
        {
            await Task.FromResult(0);

            return new XcavateUser
            {
                FirstName = "Richard",
                LastName = "Grey",
                AccountCreatedAt = new DateTime(2023, 5, 1),
                Role = UserRoleEnum.Developer,
                Email = "Richard120@gmail.com",
                PhoneNumber = "07766544445",
                ProfilePicture = ImageSource.FromResource(""),
                ProfileBackground = ImageSource.FromResource("")
            };
        }
    }
}
