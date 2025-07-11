using System;
using System.Numerics;
using Newtonsoft.Json;
using PlutoFramework.Constants;

namespace PlutoFramework.Model.Kodadot
{
	public class UnlockablesModel
	{
        /// <summary>
        /// c# implementation of https://github.com/kodadot/nft-gallery/blob/main/services/keywise.ts
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="collectionId"></param>
        /// <returns>URL for Kodadot Unlockable</returns>
        public static Task<string?> FetchKeywiseAsync(Endpoint endpoint, BigInteger collectionId)
        {
            return endpoint.Key switch
            {
                EndpointEnum.KusamaAssetHub => FetchKeywiseAsync("ahk", collectionId),
                _ => Task.FromResult<string?>(null),
            };
        }

        /// <summary>
        /// c# implementation of https://github.com/kodadot/nft-gallery/blob/main/services/keywise.ts
        /// </summary>
        /// <param name="prefix">Chain prefix, check: https://github.com/kodadot/nft-gallery/blob/main/services/keywise.ts</param>
        /// <param name="collectionId"></param>
        /// <returns>URL for Kodadot Unlockable</returns>
        public static async Task<string?> FetchKeywiseAsync(string prefix, BigInteger collectionId)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                string json = await httpClient.GetStringAsync("https://keywise.kodadot.workers.dev/resolve/" + prefix + "-" + collectionId);

                var response = JsonConvert.DeserializeObject<UnlockablesResponse>(json);
                if (response is not null && response.Status == 200)
                {
                    return response.Url;
                }
            }
            catch {

            }

            return null;
        }
    }

    class UnlockablesResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("status")]
        public uint Status { get; set; } = 200;
    }
}

