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

            Console.WriteLine($"Tx hex: {Utils.Bytes2HexString(method.Encode()).ToLower()}");

            var requestBody = new RequestBody
            {
                TxHex = "0x21020440006a71ccfefecd08ceb822b6de84df0a7c48b5dcde5119c19515173ae9e33dc766c68fe1b9a33c61070d4803f250932ec9ecf69e22440d3b151c7df1bd8517ef1e000000000150a12f6bde83f7688dfda7c31fc8407acc6e7e0ffd86ffbde794e49a3f0c7732613a83a2f114a50348e649175551e2cc2f724766335c9ae3764947da75b9fe86",
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
