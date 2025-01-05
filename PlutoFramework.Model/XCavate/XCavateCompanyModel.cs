
namespace PlutoFramework.Model.XCavate
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
    public record XCavateCompany
    {
        public required string CompanyName { get; set; }
        public required string RegistrationNumber { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Website { get; set; }
        public required string AssociatedMembershipNumber { get; set; }
        public required PassportOrDriversLicense PassportOrDriversLicense { get; set; }
    }
    public class XCavateCompanyModel
    {
        public static async Task<XCavateCompany> GetMockCompanyAsync()
        {
            await Task.FromResult(0);
            return new XCavateCompany
            {
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
    }
}
