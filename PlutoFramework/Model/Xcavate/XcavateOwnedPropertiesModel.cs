using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Constants;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Model.Xcavate
{
    public static class XcavateOwnedPropertiesModel
    {
        private const int LIMIT = 100;
        public static Dictionary<NftKey, PropertyTokenOwnershipInfo> ItemsDict = new Dictionary<NftKey, PropertyTokenOwnershipInfo>();
        private static Dictionary<EndpointEnum, DateTime> timeUsedDict = new Dictionary<EndpointEnum, DateTime>();
        private static Dictionary<EndpointEnum, TaskCompletionSource> waitUsedDict = new Dictionary<EndpointEnum, TaskCompletionSource>();

        public static bool Loading = false;

        private static IAsyncEnumerator<PropertyTokenOwnershipInfo> uniqueryNftEnumerator = null;

        public static async Task LoadAsync(SubstrateClientExt client, string address, CancellationToken token, bool forceReload = false)
        {
            // If it has been used <1 minute ago, do not load again
            if (timeUsedDict.TryGetValue(client.Endpoint.Key, out var lastUsedTime) && (DateTime.UtcNow - lastUsedTime).TotalMinutes < 1)
            {
                if (waitUsedDict.TryGetValue(client.Endpoint.Key, out var wait))
                {
                    await wait.Task;
                }

                return;
            }

            timeUsedDict[client.Endpoint.Key] = DateTime.UtcNow;

            waitUsedDict[client.Endpoint.Key] = new TaskCompletionSource();


            var uniqueryNftEnumerable = PropertyMarketplaceModel.GetPropertiesOwnedByAsync(
                (XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, // Needs to be improved for mainnet
                address,
                limit: 10
            );

            uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

            Loading = true;

            for (uint i = 0; i < LIMIT; i++)
            {
                Console.WriteLine("Loading more");

                if (token.IsCancellationRequested)
                {
                    break;
                }

                if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync())
                {
                    var newNft = uniqueryNftEnumerator.Current;

                    if (newNft.Key is not null && !ItemsDict.ContainsKey((NftKey)newNft.Key))
                    {
                        Console.WriteLine("New property added to dict");
                        ItemsDict.Add((NftKey)newNft.Key, newNft);
                    }
                }
            }

            Loading = false;

            waitUsedDict[client.Endpoint.Key].TrySetResult();
        }

        public static long GetTotalPropertiesOwned() => ItemsDict.Values.Sum(x => x.Amount);

        public static long GetTotalInvested() => ItemsDict.Values.Sum(x => x.Amount * ((INftXcavateMetadata)x.NftBase).XcavateMetadata?.PricePerToken ?? 0);
    }
}
