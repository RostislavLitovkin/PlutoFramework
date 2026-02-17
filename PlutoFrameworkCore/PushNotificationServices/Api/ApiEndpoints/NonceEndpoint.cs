using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using PlutoFrameworkCore.PushNotificationServices.Core.Interfaces;

namespace PlutoFrameworkCore.PushNotificationServices.Api.ApiEndpoints;

public abstract class NonceEndpoint: IApiEndpoint
{
    public static string EndpointPath => "/api/nonce/";
    
    private record NonceObject
    {
        public required string Nonce { get; init; }
    }
    
    public static async Task<string> GetNonceAsync(HttpClient httpClient)
    {
        var response = (await httpClient.PostAsync(EndpointPath, null)).EnsureSuccessStatusCode();
        
        var nonceObj = await response.Content.ReadFromJsonAsync<NonceObject>();
        
        if (nonceObj == null) throw new HttpRequestException();
        
        return nonceObj.Nonce;
    }
}