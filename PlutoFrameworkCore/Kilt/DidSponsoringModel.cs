using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using System.Text.Json.Serialization;

namespace PlutoFrameworkCore
{
    
    public class DidSponsoringModel
    {
        private record RequestBody
        {
            [JsonPropertyName("txHex")]
            public required string TxHex { get; init; }
        }

        private const string API_URL = "https://gr4wnsrwnk.execute-api.eu-west-1.amazonaws.com/prod";

        public static async Task<bool> SponsorDidTxAsync(Method method, CancellationToken token)
        {
            using var httpClient = new HttpClient();

            var requestBody = new RequestBody
            {
                TxHex = Utils.Bytes2HexString(method.Encode()).ToLower(),
            };

            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{API_URL}/api/v1/extrinsics/submit-sponsored-did", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to sponsor DID. Status Code: {response.StatusCode}, Response: {responseContent}");

                return false;
            }

            return true;
        }
    }
}
