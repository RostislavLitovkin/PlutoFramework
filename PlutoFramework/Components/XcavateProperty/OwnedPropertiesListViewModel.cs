using PlutoFramework.Components.Nft;
using PlutoFramework.Constants;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.Model;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using XcavatePaseo.NetApi.Generated;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class OwnedPropertiesListViewModel : BaseListViewModel<NftKey, PropertyTokenOwnershipInfo>
    {
        public override string Title => "Owned Properties";

        //private List<Task<PlutoFrameworkSubstrateClient>> clientTasks;

        private IAsyncEnumerator<PropertyTokenOwnershipInfo> uniqueryNftEnumerator = null;

        public override async Task LoadMoreAsync(CancellationToken token)
        {
            if (Loading)
            {
                return;
            }

            if (uniqueryNftEnumerator == null)
            {
                return;
            }

            Loading = true;

            try
            {
                for (uint i = 0; i < LIMIT; i++)
                {
                    Console.WriteLine("Loading more");

                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var newNft = uniqueryNftEnumerator.Current;

                        if (newNft.Key is not null && !ItemsDict.ContainsKey((NftKey)newNft.Key))
                        {
                            ItemsDict.Add((NftKey)newNft.Key, newNft);

                            // Save to DB
                            //await NftDatabase.SaveItemAsync(newNft).ConfigureAwait(false);

                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                Items.Add(newNft);
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nft owned list error: ");
                Console.WriteLine(ex);
            }

            Loading = false;

        }

        public override async Task InitialLoadAsync(CancellationToken token)
        {
            Loading = true;

            var uniqueryNftEnumerable = PropertyMarketplaceModel.GetPropertiesOwnedByAsync(
                            (SubstrateClientExt)(await SubstrateClientModel.GetOrAddSubstrateClientAsync(EndpointEnum.XcavatePaseo, token).ConfigureAwait(false)).SubstrateClient,
                            KeysModel.GetSubstrateKey(),
                            limit: LIMIT
                        );

            uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

            await LoadSavedNftsAsync().ConfigureAwait(false);

            Loading = false;

            await LoadMoreAsync(token).ConfigureAwait(false);

            Console.WriteLine("initial load done");
        }

        private Task LoadSavedNftsAsync()
        {
            return Task.FromResult(0);
            /*
            foreach (var savedNft in await NftDatabase.GetNftsOwnedByAsync(KeysModel.GetSubstrateKey()).ConfigureAwait(false))
            {
                if (savedNft.Key is not null && !ItemsDict.ContainsKey((NftKey)savedNft.Key))
                {
                    ItemsDict.Add((NftKey)savedNft.Key, savedNft);

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Items.Add(savedNft);
                    });
                }
            }*/
        }
    }
}
