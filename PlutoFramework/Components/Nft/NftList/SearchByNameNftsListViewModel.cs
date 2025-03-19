using Microsoft.VisualStudio.Threading;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model;
using UniqueryPlus.Nfts;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);


namespace PlutoFramework.Components.Nft.NftList
{
    public partial class SearchByNameNftsListViewModel : BaseListViewModel<NftKey, NftWrapper>
    {
        private string name;
        public SearchByNameNftsListViewModel(string name)
        {
            this.name = name;
        }
        public override string Title => $"Searching: {name}";

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

                        var uniqueryNftEnumerable = UniqueryPlus.Nfts.NftModel.GetNftsByNameAsync(
                           [(await completedClientTask.ConfigureAwait(false)).SubstrateClient],
                           name,
                           limit: LIMIT
                           );

                        uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

                        i--;
                    }
                }
            }
            catch (Exception ex)
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

                Loading = false;

                await LoadMoreAsync(token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nft owned list error 2: ");
                Console.WriteLine(ex);
            }
        }

    }
}
