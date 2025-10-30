using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;

public record FCMTokenUpdateData
{
    [JsonPropertyName("fcm_token")]
    public required string FCMToken { get; set; }
}

public abstract class FCMTokenEndpoint : IApiEndpoint
{
    public static string EndpointPath => "/api/fcm/token-update/";

    public static async Task UpdateTokenAsync(HttpClient httpClient, FCMTokenUpdateData input)
    {
        StringContent jsonContent = new(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
        
        (await httpClient.PostAsync(EndpointPath, jsonContent)).EnsureSuccessStatusCode();
    }
}