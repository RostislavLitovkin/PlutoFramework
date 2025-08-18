using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace PlutoFramework.Model.Faucet;

public record FaucetInput
{
    [JsonPropertyName("destinationAddress")]
    public required string DestinationAddress { get; set; }
    [JsonPropertyName("websocketUrl")]
    public required string WebsocketUrl { get; set; }
}
public class FaucetApiModel
{
    public static async Task<HttpStatusCode> PostRequestAsync(string wsUrl, string dstAddr)
    {
        const string url = Constants.PlutoExpress.PLUTO_EXPRESS_API_URL;
        // const string url = "http://localhost:8000";

        var client = new HttpClient();
        using var content = JsonContent.Create(new FaucetInput {
            DestinationAddress = dstAddr,
            WebsocketUrl = wsUrl
        });
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        using HttpResponseMessage response = await client.PostAsync($"{url}/faucet", content);
        
        // Console.WriteLine(response);
        return response.StatusCode;
    }
}

