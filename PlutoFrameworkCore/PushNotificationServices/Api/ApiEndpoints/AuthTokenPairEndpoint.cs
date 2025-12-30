using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;

public record TokenPair
{
    public required string Access { get; set; }
    public required string Refresh { get; set; }
}

public record DeviceRegistrationData
{
    [JsonPropertyName("device_uuid")]
    public required string DeviceUUID { get; set; }

    [JsonPropertyName("attestation")]
    public required string Attestation { get; set; }

    [JsonPropertyName("platform")]
    public required string Platform { get; set; }
}

public abstract class AuthTokenPairEndpoint: IApiEndpoint
{
    public static string EndpointPath => "/api/token";
    public static readonly string RefreshEndpointPath = EndpointPath + "/refresh";
    
    private record AccessTokenObject
    {
        public required string Access { get; set; }
    }

    public static async Task<TokenPair> GetTokenPairAsync(HttpClient httpClient, DeviceRegistrationData input)
    {
        StringContent jsonContent = new(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
        
        var response = (await httpClient.PostAsync(EndpointPath, jsonContent)).EnsureSuccessStatusCode();
        
        var tokens = await response.Content.ReadFromJsonAsync<TokenPair>();
        
        if (tokens == null) throw new HttpRequestException();
        
        return tokens;
    }

    public static async Task<TokenPair> RefreshAccessTokenAsync(HttpClient httpClient, TokenPair tokenPair)
    {
        StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                refresh =  tokenPair.Refresh
            }),
            Encoding.UTF8,
            "application/json");
        
        var response = (await httpClient.PostAsync(RefreshEndpointPath, jsonContent)).EnsureSuccessStatusCode();
        
        var accessTokenObj = await response.Content.ReadFromJsonAsync<AccessTokenObject>();
        
        if (accessTokenObj == null) throw new HttpRequestException();
        
        tokenPair.Access = accessTokenObj.Access;
        
        return tokenPair;
    }
}