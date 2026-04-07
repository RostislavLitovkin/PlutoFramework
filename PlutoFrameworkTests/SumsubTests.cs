using PlutoFramework.Model.Sumsub;

namespace PlutoFrameworkTests
{
    internal class SumsubTests
    {

        private static readonly string SUMSUB_SECRET_KEY = "1SiTD0DH50SB71Qlk2Omp07LGD0Dtk4M"; // Example: Hej2ch71kG2kTd1iIUDZFNsO5C1lh5Gq - Please don't forget to change when switching to production
        private static readonly string SUMSUB_APP_TOKEN = "sbx:3OcGQFD4j812xUoAhPBvOew3.02kIimwmfz6aj34wAcRVX6hrMVn6kjZm";  // Example: sbx:uY0CgwELmgUAEyl4hNWxLngb.0WSeQeiYny4WEqmAALEAiK2qTC96fBad - Please don't forget to change when switching to production

        [Test]
        public void CreateApplicantTest()
        {
            // The description of the flow can be found here: https://docs.sumsub.com/reference/get-started-with-api

            // Such actions are presented below:
            // 1) Creating an applicant
            // 2) Adding a document to the applicant
            // 3) Getting applicant status
            // 4) Getting access token

            // Create an applicant
            string externalUserId = $"USER_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            string levelName = "csharp-verification-test";
            string applicantId = SumsubModel.CreateApplicant(externalUserId, levelName, SUMSUB_SECRET_KEY, SUMSUB_APP_TOKEN).Result;

            // Add a document to the applicant
            /*var addDocumentResult = SumsubModel.AddDocument(applicantId).Result;
            Console.WriteLine("Add Document Result: " + SumsubModel.ContentToString(addDocumentResult.Content));

            // Get Applicant Status
            var getApplicantResult = SumsubModel.GetApplicantStatus(applicantId).Result;
            Console.WriteLine("Applicant status (json string): " + SumsubModel.ContentToString(getApplicantResult.Content));

            // Get access token
            var accessTokenResult = SumsubModel.GetAccessToken(externalUserId, levelName).Result;
            Console.WriteLine("Access token Result: " + SumsubModel.ContentToString(accessTokenResult.Content));

           */
        }

        [Test]
        public async Task CreateAccessTokenAsync()
        {
            var applicant = new Applicant { 
                ApplicantIdentifiers = new ApplicantIdentifiers {
                    Email = "ahojky email",
                    Phone = "ahojky phone",
                    ExternalUserId = "",
                },
                totalInSeconds = 600,
                UserId = $"15CHtW16fJaradrt3TUrSMBygqFuMfwqXWRGRBE3M14Pt2EF",
                LevelName = "csharp-verification-investor"
            };

            var result = await SumsubModel.GenerateWebSDKAccessTokenAsync(applicant, SUMSUB_SECRET_KEY, SUMSUB_APP_TOKEN, CancellationToken.None);

            Console.WriteLine("Access token Result: " + result);
        }
        [Test]
        [TestCase("USER_1739731212")] // Verified user
        [TestCase("USER_1739728710")] // Unverified user
        [TestCase("USER_NONE")] // None existant user user
        [TestCase("15CHtW16fJaradrt3TUrSMBygqFuMfwqXWRGRBE3M14Pt2EF")]
        public async Task GetApplicantDataAsync(string externalUserId)
        {
            CancellationToken token = CancellationToken.None;

            var result = await SumsubModel.GetApplicantDataAsync(externalUserId, SUMSUB_SECRET_KEY, SUMSUB_APP_TOKEN, token);
        }
    }
}
