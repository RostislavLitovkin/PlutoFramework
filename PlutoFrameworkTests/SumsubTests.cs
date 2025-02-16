using PlutoFramework.Model.Sumsub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFrameworkTests
{
    internal class SumsubTests
    {
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
            string applicantId = SumsubModel.CreateApplicant(externalUserId, levelName).Result;

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
                },
                totalInSeconds = 600,
                UserId = $"USER_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}",
                LevelName = "csharp-verification-test"
            };

            var result = await SumsubModel.GenerateWebSDKAccessTokenAsync(applicant, CancellationToken.None);

            Console.WriteLine("Access token Result: " + result);
        }
    }
}
