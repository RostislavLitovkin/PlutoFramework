using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlutoFramework.Model.Sumsub
{
    public record ApplicantIdentifiers
    {
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("phone")]
        public required string Phone { get; set; }
    }
    public record Applicant
    {
        [JsonPropertyName("applicantIdentifiers")]
        public required ApplicantIdentifiers ApplicantIdentifiers { get; set; }
        [JsonPropertyName("ttlInSecs")]
        public required uint totalInSeconds { get; set; }
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }
        [JsonPropertyName("levelName")]
        public required string LevelName { get; set; }
    }

    public record AccessTokenResponse
    {
        [JsonPropertyName("token")]
        public required string Token { get; set; }
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }

    }
    public class SumsubModel
    {
        // The description of the authorization method is available here: https://docs.sumsub.com/reference/authentication
        private static readonly string SUMSUB_SECRET_KEY = "1SiTD0DH50SB71Qlk2Omp07LGD0Dtk4M"; // Example: Hej2ch71kG2kTd1iIUDZFNsO5C1lh5Gq - Please don't forget to change when switching to production
        private static readonly string SUMSUB_APP_TOKEN = "sbx:3OcGQFD4j812xUoAhPBvOew3.02kIimwmfz6aj34wAcRVX6hrMVn6kjZm";  // Example: sbx:uY0CgwELmgUAEyl4hNWxLngb.0WSeQeiYny4WEqmAALEAiK2qTC96fBad - Please don't forget to change when switching to production
        private static readonly string SUMSUB_TEST_BASE_URL = "https://api.sumsub.com";

        /// <summary>
        /// https://docs.sumsub.com/docs/get-started-with-web-sdk#generate-sdk-access-token
        /// </summary>
        /// <returns>access token</returns>
        public static async Task<string?> GenerateWebSDKAccessTokenAsync(Applicant applicant, CancellationToken token)
        {
            Console.WriteLine("Creating Access Token...");

            var requestBody = new HttpRequestMessage(HttpMethod.Post, SUMSUB_TEST_BASE_URL)
            {
                Content = new StringContent(JsonSerializer.Serialize(applicant), Encoding.UTF8, "application/json")
            };

            var response = await SendPost("/resources/accessTokens/sdk", requestBody);

            Console.WriteLine(ContentToString(response.Content));

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var accessToken = JsonSerializer.Deserialize<AccessTokenResponse>(ContentToString(response.Content));

            return accessToken?.Token;
        }

        // https://docs.sumsub.com/reference/get-applicant-review-status
        public static async Task<string> CreateApplicant(string externalUserId, string levelName)
        {
            Console.WriteLine("Creating an applicant...");

            var body = new
            {
                externalUserId = externalUserId
            };

            // Create the request body
            var requestBody = new HttpRequestMessage(HttpMethod.Post, SUMSUB_TEST_BASE_URL)
            {
                Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
            };

            // Get the response
            var response = await SendPost($"/resources/applicants?levelName={levelName}", requestBody);

            Console.WriteLine(ContentToString(response.Content));
            /*var applicant = JsonConvert.DeserializeObject<Applicant>(ContentToString(response.Content));

            Console.WriteLine(response.IsSuccessStatusCode
                ? $"The applicant was successfully created: {applicant.id}"
                : $"ERROR: {ContentToString(response.Content)}");

            return applicant;*/

            Console.WriteLine(response.IsSuccessStatusCode
               ? $"The applicant was successfully created:"
               : $"ERROR: {ContentToString(response.Content)}");

            return "Good";
        }

        // https://docs.sumsub.com/reference/add-id-documents
        public static async Task<HttpResponseMessage> AddDocument(string applicantId)
        {
            Console.WriteLine("Adding document to the applicant...");

            // metadata object
            var metaData = new
            {
                idDocType = "PASSPORT",
                country = "GBR"
            };

            using (var formContent = new MultipartFormDataContent())
            {
                // Add metadata json object
                formContent.Add(new StringContent(JsonSerializer.Serialize(metaData)), "\"metadata\"");

                // Add binary content
                var binaryImage = File.ReadAllBytes("../../resources/sumsub-logo.png");
                formContent.Add(new StreamContent(new MemoryStream(binaryImage)), "content", "sumsub-logo.png");

                // Request body
                var requestBody = new HttpRequestMessage(HttpMethod.Post, SUMSUB_TEST_BASE_URL)
                {
                    Content = formContent
                };

                var response = await SendPost($"/resources/applicants/{applicantId}/info/idDoc", requestBody);

                Console.WriteLine(response.IsSuccessStatusCode
                    ? $"Document was successfully added"
                    : $"ERROR: {ContentToString(response.Content)}");

                return response;
            }
        }

        // https://docs.sumsub.com/reference/get-applicant-verification-steps-status
        public static async Task<HttpResponseMessage> GetApplicantStatus(string applicantId)
        {
            Console.WriteLine("Getting the applicant status...");

            var response = await SendGet($"/resources/applicants/{applicantId}/requiredIdDocsStatus");
            return response;
        }

        public static async Task<HttpResponseMessage> GetAccessToken(string applicantId, string levelName)
        {
            var response = await SendPost($"/resources/accessTokens?userId={applicantId}&levelName={levelName}", new HttpRequestMessage());
            return response;
        }

        private static async Task<HttpResponseMessage> SendPost(string url, HttpRequestMessage requestBody)
        {

            var ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var signature = CreateSignature(ts, HttpMethod.Post, url, RequestBodyToBytes(requestBody));

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new HttpClient
            {
                BaseAddress = new Uri(SUMSUB_TEST_BASE_URL)
            };
            client.DefaultRequestHeaders.Add("X-App-Token", SUMSUB_APP_TOKEN);
            client.DefaultRequestHeaders.Add("X-App-Access-Sig", signature);
            client.DefaultRequestHeaders.Add("X-App-Access-Ts", ts.ToString());

            var response = await client.PostAsync(url, requestBody.Content);

            if (!response.IsSuccessStatusCode)
            {
                // https://docs.sumsub.com/reference/review-api-health
                // If an unsuccessful answer is received, please log the value of the "correlationId" parameter.
                // Then perhaps you should throw the exception. (depends on the logic of your code)
            }

            // debug
            //var debugInfo = response.Content.ReadAsStringAsync().Result;
            return response;
        }

        private static async Task<HttpResponseMessage> SendGet(string url)
        {
            long ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new HttpClient
            {
                BaseAddress = new Uri(SUMSUB_TEST_BASE_URL)
            };
            client.DefaultRequestHeaders.Add("X-App-Token", SUMSUB_APP_TOKEN);
            client.DefaultRequestHeaders.Add("X-App-Access-Sig", CreateSignature(ts, HttpMethod.Get, url, null));
            client.DefaultRequestHeaders.Add("X-App-Access-Ts", ts.ToString());

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                // https://docs.sumsub.com/reference/review-api-health
                // If an unsuccessful answer is received, please log the value of the "correlationId" parameter.
                // Then perhaps you should throw the exception. (depends on the logic of your code)
            }

            return response;
        }

        private static string CreateSignature(long ts, HttpMethod httpMethod, string path, byte[] body)
        {
            Console.WriteLine("Creating a signature for the request...");

            var hmac256 = new HMACSHA256(Encoding.ASCII.GetBytes(SUMSUB_SECRET_KEY));

            byte[] byteArray = Encoding.ASCII.GetBytes(ts + httpMethod.Method + path);

            if (body != null)
            {
                // concat arrays: add body to byteArray
                var s = new MemoryStream();
                s.Write(byteArray, 0, byteArray.Length);
                s.Write(body, 0, body.Length);
                byteArray = s.ToArray();
            }

            var result = hmac256.ComputeHash(
                new MemoryStream(byteArray)).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);

            return result;
        }

        public static string ContentToString(HttpContent httpContent)
        {
            return httpContent == null ? "" : httpContent.ReadAsStringAsync().Result;
        }

        private static byte[] RequestBodyToBytes(HttpRequestMessage requestBody)
        {
            return requestBody.Content == null ?
                new byte[] { } : requestBody.Content.ReadAsByteArrayAsync().Result;
        }
    }
}
