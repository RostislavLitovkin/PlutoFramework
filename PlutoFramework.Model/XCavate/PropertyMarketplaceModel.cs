using Substrate.NetApi.Model.Types.Primitive;
using XcavatePaseo.NetApi.Generated;
using UniqueryPlus;
using Substrate.NetApi;
using XcavatePaseo.NetApi.Generated.Storage;
using XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.pallet;
using UniqueryPlus.Nfts;


namespace PlutoFramework.Model.Xcavate
{
    public class PropertyMarketplaceModel
    {
        public static async Task<RecursiveReturn<INftBase>> GetPropertiesAsync(SubstrateClientExt client, uint limit, byte[]? lastKey, CancellationToken token)
        {
            Console.WriteLine("Finding properties.");
            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat U32
            var keyPrefixLength = 66;

            var keyPrefix = Utils.HexToByteArray(NftMarketplaceStorage.AssetIdDetailsParams(new U32(0)).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, limit, lastKey, string.Empty, token).ConfigureAwait(false);

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new RecursiveReturn<INftBase>
                {
                    Items = [],
                    LastKey = lastKey,
                };
            }

            var storageChangeSets = await client.State.GetQueryStorageAtAsync(fullKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), string.Empty, token).ConfigureAwait(false);

            var nftIds = new List<(U32, U32)>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                if (change[1] == null)
                {
                    continue;
                }

                var details = new AssetDetails();
                details.Create(change[1]);

                Console.WriteLine($"Property id: {details.CollectionId} - {details.ItemId}");
                nftIds.Add((details.CollectionId, details.ItemId));
            };

            return await XcavatePaseoNftModel.GetNftsNftsPalletAsync(client, nftIds, fullKeys.Last().ToString(), token).ConfigureAwait(false);
        }

        public static IAsyncEnumerable<INftBase> GetPropertiesAsync(
            SubstrateClientExt client,
            uint limit = 25
        )
        {
            return RecursionHelper.ToIAsyncEnumerableAsync(
                [client],
                (SubstrateClient client, NftTypeEnum type, byte[]? lastKey, CancellationToken token) => GetPropertiesAsync((SubstrateClientExt)client, limit, lastKey, token),
                limit
            );
        }
    }
}
