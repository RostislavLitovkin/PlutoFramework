using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;

public record UserIdUpdateData
{
    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }
}

public abstract class UserIdEndpoint : IApiEndpoint
{
    public static string EndpointPath => "/api/user/uid-update/";

    public static async Task UpdateUidAsync(HttpClient httpClient, UserIdUpdateData input)
    {
        StringContent jsonContent = new(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");

        var res = await httpClient.PostAsync(EndpointPath, jsonContent);
        if (res.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new PlutoFrameworkCore.PushNotificationServices.Api.UnauthorizedException(res.ReasonPhrase ?? "");
        }
        res.EnsureSuccessStatusCode();
    }
}
