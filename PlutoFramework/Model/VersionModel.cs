using System;
using Newtonsoft.Json;

namespace PlutoFramework.Model
{
	public class VersionModel
	{
		public static async Task<LatestVersionInfo?> GetLatestVersionInfoAsync(string apiUrl, CancellationToken token)
		{
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(apiUrl, token).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadAsAsync<LatestVersionInfo>().ConfigureAwait(false);
        }
    }

    public class LatestVersionInfo
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("versionString")]
        public string VersionString { get; set; }
    }
}

