namespace PlutoFramework.Model.XCavate
{
    public enum UserRoleEnum
    {
        // Has to be here due to Data binding
        None,

        Developer,
        Investor,
        LettingAgent
    }
    public record DeveloperStats
    {
        public required int ActiveListedProperties { get; set; }
        public required int PropertyTokensSold { get; set; }
        public required int TotalSales { get; set; }
        public required int AverageSaleTime { get; set; }
    }
    public record XCavateUser
    {
        public required UserRoleEnum Role { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime? AccountCreatedAt { get; set; }
        public DeveloperStats? DeveloperStats { get; set; }
    }
    public class XCavateUserModel
    {
        public static async Task<XCavateUser> GetMockUserAsync()
        {
            await Task.FromResult(0);

            return new XCavateUser
            {
                FirstName = "Richard",
                LastName = "Grey",
                AccountCreatedAt = new DateTime(2023, 5, 1),
                Role = UserRoleEnum.Developer,
                Email = "Richard120@gmail.com",
                PhoneNumber = "07766544445"
            };
        }
    }
}
