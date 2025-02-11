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

            if (clientTasks.Count() == 0 && uniqueryNftEnumerator is null)
            { 
                return;
            }

            Loading = true;

            try
            {
                for (int i = 0; i < LIMIT; i++)
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
                            uniqueryNftEnumerator = null;
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


            Console.WriteLine("Done, length = " + Items.Count());
        }

        public override async Task InitialLoadAsync(CancellationToken token)
        {
            Console.WriteLine("Initial load :)");
            try
            {
                Loading = true;

                clientTasks = SubstrateClientModel.Clients.Values.ToList();

                await LoadSavedNftsAsync().ConfigureAwait(false);

                Loading = false;

                await LoadMoreAsync(token).ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Nft owned list error 2: ");
                Console.WriteLine(ex);
            }
        }

        private async Task LoadSavedNftsAsync()
        {
            Console.WriteLine("Load saved nfts");
            // Not favourite, owned Nfts
            foreach (var savedNft in await NftDatabase.GetNftsOwnedByAsync(KeysModel.GetSubstrateKey()).ConfigureAwait(false))
            {
                Console.WriteLine("Maybe added, length = " + Items.Count());

                if (savedNft.Key is not null && !ItemsDict.ContainsKey((NftKey)savedNft.Key))
                {
                    Console.WriteLine("Added something");
                    ItemsDict.Add((NftKey)savedNft.Key, savedNft);

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Items.Add(savedNft);
                    });
                }
                else
                {
                    Console.WriteLine("Did not add something");

                }
            }
        }
    }
}
