using Newtonsoft.Json;
using PlutoFramework.Model.Constants;

namespace PlutoFramework.Model.HydrationModel
{
    public static class HydrationSdk
    {
        /// <summary>
        /// Source: https://github.com/galacticcouncil/sdk/tree/master/packages/sdk
        /// getAllAssets(): Asset[]
        /// </summary>
        /// <returns></returns>
        public static async Task<List<HydrationAsset>> GetAllAssetsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{PlutoExpress.PLUTO_EXPRESS_API_URL}/all-assets");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var assets = JsonConvert.DeserializeObject<List<HydrationAsset>>(json);
                    return assets ?? [];
                }
                else
                {
                    return [];
                }
            }
        }
    }
}
