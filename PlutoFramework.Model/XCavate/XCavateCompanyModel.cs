using UniqueryPlus;

namespace PlutoFramework.Model.Xcavate
{
    public enum VerificationEnum
    {
        // Has to be here due to binding
        None,

        Pending,
        Verified,
        Rejected
    }
    public record PassportOrDriversLicense
    {
        public required VerificationEnum VerificationStatus { get; set; }
        public required string? FrontSideImageUrl { get; set; }
        public required string? BackSideImageUrl { get; set; }


    }
    public record XcavateCompany
    {
        public uint? CompanyId { get; set; } = null;
        public required string CompanyName { get; set; }
        public required string RegistrationNumber { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Website { get; set; }
        public required string AssociatedMembershipNumber { get; set; }
        public required PassportOrDriversLicense PassportOrDriversLicense { get; set; }
    }
    public class XcavateCompanyModel
    {
        public static async Task<XcavateCompany> GetMockCompanyAsync()
        {
            await Task.FromResult(0);
            return new XcavateCompany
            {
                CompanyId = 1,
                CompanyName = "PrimeStone Developments",
                RegistrationNumber = "PRD - 2024 - 987654",
                PhoneNumber = "+44 7700 900123",
                Email = "info@primestone-developments.com",
                Address = "PrimesStone Developments, 123 Kensington High Street, London W8 5SA United Kingdom",
                Website = "www.primestone-developments.com",
                AssociatedMembershipNumber = "PMD-2024-00123",
                PassportOrDriversLicense = new PassportOrDriversLicense
                {
                    VerificationStatus = VerificationEnum.Verified,
                    FrontSideImageUrl = null,
                    BackSideImageUrl = null
                }
            };
        }

        public static IAsyncEnumerable<XcavateCompanyUser> GetMockCompanyUsersAsync(
            uint companyId,
            uint limit = 25
        )
        {
            return RecursionHelper.ToIAsyncEnumerableAsync<uint?, XcavateCompanyUser>(
                (lastId, token) => GetMockCompanyUsersAsync(companyId, lastId, limit, token),
                limit
                );
        }

        public static async Task<RecursiveReturn<uint?, XcavateCompanyUser>> GetMockCompanyUsersAsync(
             uint companyId,
             uint? lastId,
            uint limit,
            CancellationToken token)
        {
            await Task.FromResult(0);

            if (lastId != null)
            {
                return new RecursiveReturn<uint?, XcavateCompanyUser>
                {
                    Items = [],
                    LastKey = lastId,
                };
            }

            Console.WriteLine("Returning 2");

            return new RecursiveReturn<uint?, XcavateCompanyUser>
            {
                Items = [
                    new XcavateCompanyUser
                    {
                        FirstName = "Richard",
                        LastName = "Grey",
                        AccountCreatedAt = new DateTime(2023, 5, 1),
                        AddedAt = new DateTime(2023, 5, 1),
                        Role = UserRoleEnum.Developer,
                        Email = "Richard120@gmail.com",
                        PhoneNumber = "07766544445",
                        CompanyIds = [1],
                        Id = 1,
                        CompanyUserStatus = CompanyUserStatusEnum.Active,
                        Verification = VerificationEnum.Verified,
                        ProfilePicture = ImageSource.FromUri(new Uri("https://static1.thegamerimages.com/wordpress/wp-content/uploads/2022/02/pjimage-(71)-2.jpg")),
                        ProfileBackground = ImageSource.FromUri(new Uri("https://www.pixelstalk.net/wp-content/uploads/images6/Free-download-Xenoblade-Chronicles-2-Wallpaper-HD.jpg")),
                    },
                    new XcavateCompanyUser
                    {
                        FirstName = "Richard2",
                        LastName = "Grey",
                        AccountCreatedAt = new DateTime(2023, 5, 1),
                        AddedAt = null,
                        Role = UserRoleEnum.Developer,
                        Email = "Richard120@gmail.com",
                        PhoneNumber = "07766544445",
                        CompanyUserStatus = CompanyUserStatusEnum.Invited,
                        CompanyIds = [1],
                        Id = 2,
                        Verification = VerificationEnum.Pending,
                        ProfilePicture = ImageSource.FromFile(""),
                        ProfileBackground = ImageSource.FromFile(""),
                    }
                ],
                LastKey = 2,
            };
        }
    }
}
