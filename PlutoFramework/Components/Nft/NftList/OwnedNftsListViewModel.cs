using Microsoft.VisualStudio.Threading;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.Nft
{
    public partial class OwnedNftsListViewModel : BaseListViewModel<NftKey, NftWrapper>
    {
        public override string Title => "Owned NFTs";

        private List<Task<PlutoFrameworkSubstrateClient>> clientTasks;

        private IAsyncEnumerator<INftBase> uniqueryNftEnumerator = null;

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
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    if (uniqueryNftEnumerator != null && await uniqueryNftEnumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var newNft = Model.NftModel.ToNftWrapper(uniqueryNftEnumerator.Current);

                        if (newNft.Key is not null && !ItemsDict.ContainsKey((NftKey)newNft.Key))
                        {
                            ItemsDict.Add((NftKey)newNft.Key, newNft);
                            await NftDatabase.SaveItemAsync(newNft).ConfigureAwait(false);

                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                Items.Add(newNft);
                            });
                        }
                    }

                    else
                    {
                        if (clientTasks.Count() == 0)
                        {
                            return;
                        }

                        // Inspiration: https://youtu.be/zhCRX3B7qwY?si=RyNtzmzGHrxO17FD&t=2678
                        var completedClientTask = await Task.WhenAny(clientTasks).WithCancellation(token).ConfigureAwait(false);

                        clientTasks.Remove(completedClientTask);

                        var uniqueryNftEnumerable = UniqueryPlus.Nfts.NftModel.GetNftsOwnedByAsync(
                            [(await completedClientTask.ConfigureAwait(false)).SubstrateClient],
                            KeysModel.GetSubstrateKey(),
                            limit: LIMIT
                        );

                        uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

                        i--;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nft owned list error: ");
                Console.WriteLine(ex);
            }

            Loading = false;

        }

        public override async Task InitialLoadAsync(CancellationToken token)
        {
            Loading = true;

            clientTasks = SubstrateClientModel.Clients.Values.ToList();

            await LoadSavedNftsAsync().ConfigureAwait(false);

            Loading = false;

            await LoadMoreAsync(token).ConfigureAwait(false);
        }

        private async Task LoadSavedNftsAsync()
        {
            // Not favourite, owned Nfts
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
            }
        }
    }
}
