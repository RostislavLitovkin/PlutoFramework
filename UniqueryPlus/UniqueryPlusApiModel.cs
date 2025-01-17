using ADRaffy.ENSNormalize;
using Newtonsoft.Json;
using System.Numerics;
using UniqueryPlus;

namespace UniqueryPlus
{
    public record NftId
    {
        public NftTypeEnum NftType { get; init; }
        public BigInteger CollectionId { get; init; }
        public BigInteger Id { get; init; }
    }

    public static class UniqueryPlusApiModel
    {
        public static async Task<Dictionary<NftTypeEnum, List<NftId>>> GetFeaturedNftsAsync(CancellationToken token)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync("https://plutonication.com/uniqueryplus/featured-nfts");

            var dict = new Dictionary<NftTypeEnum, List<NftId>>();
            if (!response.IsSuccessStatusCode)
            {
                return dict;
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
            var nftList = JsonConvert.DeserializeObject<List<NftId>>(jsonResponse);

            if (nftList is null)
            {
                return dict;
            }

            foreach (var nft in nftList)
            {
                if (!dict.ContainsKey(nft.NftType))
                {
                    dict.Add(nft.NftType, new List<NftId>());
                }

                dict[nft.NftType].Add(nft);
            }

            return dict;
        }
    }
}
