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

        [JsonPropertyName("externalUserId")]
        public required string ExternalUserId { get; set; }
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
        private static readonly string SUMSUB_BASE_URL = "https://api.sumsub.com";


        /// <summary>
        /// https://docs.sumsub.com/docs/get-started-with-web-sdk#generate-sdk-access-token
        /// </summary>
        /// <param name="applicant">Applicant data (</param>
        /// <param name="secretKey"></param>
        /// <param name="appToken"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<string?> GenerateWebSDKAccessTokenAsync(
            Applicant applicant,
            string secretKey,
            string appToken,
            CancellationToken token)
        {
            var requestBody = new HttpRequestMessage(HttpMethod.Post, SUMSUB_BASE_URL)
            {
                Content = new StringContent(JsonSerializer.Serialize(applicant), Encoding.UTF8, "application/json")
            };

            var response = await SendPostAsync("/resources/accessTokens/sdk", requestBody, secretKey, appToken);
            
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var accessToken = JsonSerializer.Deserialize<AccessTokenResponse>(ContentToString(response.Content));

            return accessToken?.Token;
        }

        /// <summary>
        /// https://docs.sumsub.com/reference/get-applicant-data
        /// </summary>
        /// <param name="address">Wallet address</param>
        /// <returns>Applicant data</returns>
        public static async Task<SumsubApplicant?> GetApplicantDataAsync(string address, string secretKey, string appToken, CancellationToken token)
        {
            var response = await SendGetAsync($"/resources/applicants/{address}/one", secretKey, appToken, token);

            Console.WriteLine(ContentToString(response.Content));

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var applicant = JsonSerializer.Deserialize<SumsubApplicant>(ContentToString(response.Content));

            return applicant;
        }

        public static async Task<bool?> GetApplicantVerificationStatusAsync(string address, string secretKey, string appToken, CancellationToken token)
        {
            // TODO

            return null;
        }


        // https://docs.sumsub.com/reference/get-applicant-review-status
        public static async Task<string> CreateApplicant(string externalUserId, string levelName, string secretKey, string appToken)
        {
            Console.WriteLine("Creating an applicant...");

            var body = new
            {
                externalUserId = externalUserId
            };

            // Create the request body
            var requestBody = new HttpRequestMessage(HttpMethod.Post, SUMSUB_BASE_URL)
            {
                Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
            };

            // Get the response
            var response = await SendPostAsync($"/resources/applicants?levelName={levelName}", requestBody, secretKey, appToken);

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
        public static async Task<HttpResponseMessage> AddDocumentAsync(string applicantId, string secretKey, string appToken)
        {
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
                var requestBody = new HttpRequestMessage(HttpMethod.Post, SUMSUB_BASE_URL)
                {
                    Content = formContent
                };

                var response = await SendPostAsync($"/resources/applicants/{applicantId}/info/idDoc", requestBody, secretKey, appToken);

                Console.WriteLine(response.IsSuccessStatusCode
                    ? $"Document was successfully added"
                    : $"ERROR: {ContentToString(response.Content)}");

                return response;
            }
        }

        // https://docs.sumsub.com/reference/get-applicant-verification-steps-status
        public static async Task<HttpResponseMessage> GetApplicantStatus(string applicantId, string secretKey, string appToken, CancellationToken token)
        {
            Console.WriteLine("Getting the applicant status...");

            var response = await SendGetAsync($"/resources/applicants/{applicantId}/requiredIdDocsStatus", secretKey, appToken, token);
            return response;
        }

        public static async Task<HttpResponseMessage> GetAccessToken(string applicantId, string levelName, string secretKey, string appToken)
        {
            var response = await SendPostAsync($"/resources/accessTokens?userId={applicantId}&levelName={levelName}", new HttpRequestMessage(), secretKey, appToken);
            return response;
        }

        private static async Task<HttpResponseMessage> SendPostAsync(string url, HttpRequestMessage requestBody, string secretKey, string appToken)
        {

            var ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var signature = CreateSignature(ts, HttpMethod.Post, url, RequestBodyToBytes(requestBody), secretKey);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new HttpClient
            {
                BaseAddress = new Uri(SUMSUB_BASE_URL)
            };
            client.DefaultRequestHeaders.Add("X-App-Token", appToken);
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

        private static async Task<HttpResponseMessage> SendGetAsync(string url, string secretKey, string appToken, CancellationToken token)
        {
            long ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            var client = new HttpClient
            {
                BaseAddress = new Uri(SUMSUB_BASE_URL)
            };
            client.DefaultRequestHeaders.Add("X-App-Token", appToken);
            client.DefaultRequestHeaders.Add("X-App-Access-Sig", CreateSignature(ts, HttpMethod.Get, url, null, secretKey));
            client.DefaultRequestHeaders.Add("X-App-Access-Ts", ts.ToString());

            var response = await client.GetAsync(url, token);

            if (!response.IsSuccessStatusCode)
            {
                // https://docs.sumsub.com/reference/review-api-health
                // If an unsuccessful answer is received, please log the value of the "correlationId" parameter.
                // Then perhaps you should throw the exception. (depends on the logic of your code)
            }

            return response;
        }

        private static string CreateSignature(long ts, HttpMethod httpMethod, string path, byte[] body, string secretKey)
        {
            Console.WriteLine("Creating a signature for the request...");

            var hmac256 = new HMACSHA256(Encoding.ASCII.GetBytes(secretKey));

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
