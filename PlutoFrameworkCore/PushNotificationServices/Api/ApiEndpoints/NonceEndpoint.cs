using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;

public record NonceRetrievalData
{
    [JsonPropertyName("device_uuid")]
    public required string DeviceUUID { get; set; }
}

public abstract class NonceEndpoint: IApiEndpoint
{
    public static string EndpointPath => "/nonce";
    
    private record NonceObject
    {
        public required string Nonce { get; init; }
    }
    
    public static async Task<string> GetNonceAsync(HttpClient httpClient, NonceRetrievalData input)
    {
        StringContent jsonContent = new(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
        
        var response = (await httpClient.PostAsync(EndpointPath, jsonContent)).EnsureSuccessStatusCode();
        
        var nonceObj = await response.Content.ReadFromJsonAsync<NonceObject>();
        
        if (nonceObj == null) throw new HttpRequestException();
        
        return nonceObj.Nonce;
    }
}