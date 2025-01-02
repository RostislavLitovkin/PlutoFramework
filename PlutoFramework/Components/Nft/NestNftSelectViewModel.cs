using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using UniqueryPlus.Nfts;
using PlutoFramework.Constants;
using System.Numerics;
using UniqueryPlus;
using Substrate.NetApi;
using CommunityToolkit.Mvvm.Input;
using Substrate.NetApi.Model.Extrinsics;
using PlutoFramework.Components.TransactionAnalyzer;

#nullable enable

namespace PlutoFramework.Components.Nft
{
    public partial class NestNftSelectViewModel : BaseListViewModel<NftKey, NftWrapper>, IPopup
    {
        public override string Title => ""; // Not used :)

        private bool isVisible = false;

        private NftTypeEnum nftTypeToSelect;
        private Queue<BigInteger>? collectionIdsToSelect = null;
        private BigInteger nftIdToIgnore;
        
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        private PlutoFrameworkSubstrateClient client;
        private INftBase nftBase;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public bool IsVisible
        {
            get => isVisible;
            set
            {
                if (!value)
                {
                    ItemsDict.Clear();
                    Items.Clear();
                    uniqueryNftEnumerator = null;
                }
                SetProperty(ref isVisible, value);
            }
        }

        private IAsyncEnumerator<INftBase>? uniqueryNftEnumerator = null;
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

                        if (newNft.Key is not null && !ItemsDict.ContainsKey((NftKey)newNft.Key) && newNft.NftBase?.Id != nftIdToIgnore)
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
                        if (collectionIdsToSelect is null)
                        {
                            return;
                        }

                        if (collectionIdsToSelect.Count() == 0)
                        {
                            return;
                        }

                        // Inspiration: https://youtu.be/zhCRX3B7qwY?si=RyNtzmzGHrxO17FD&t=2678

                        var uniqueryNftEnumerable = UniqueryPlus.Nfts.NftModel.GetNftsInCollectionOwnedByAsync(
                            [client.SubstrateClient],
                            this.collectionIdsToSelect.Dequeue(),
                            KeysModel.GetSubstrateKey(),
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
        }

        public override Task InitialLoadAsync(CancellationToken token) => Task.FromException<NotImplementedException>(new NotImplementedException());
        public async Task AppearAsync(
            IEnumerable<BigInteger>? collectionIdsToSelect,
            INftBase nftToNest,
            Endpoint endpoint,
            CancellationToken token
        )
        {
            if (IsVisible)
            {
                return;
            }

            Loading = true;
            IsVisible = true;

            this.nftBase = nftToNest;

            this.collectionIdsToSelect = collectionIdsToSelect is null ? null : new Queue<BigInteger>(collectionIdsToSelect);

            this.nftIdToIgnore = nftToNest.Id;

            this.nftTypeToSelect = nftToNest.Type;

            await LoadSavedNftsAsync().ConfigureAwait(false);

            Loading = false;

            this.client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(endpoint.Key, token);

            var uniqueryNftEnumerable =
                (this.collectionIdsToSelect is null) switch
                {
                    true => UniqueryPlus.Nfts.NftModel.GetNftsOwnedByAsync(
                        [client.SubstrateClient],
                        KeysModel.GetSubstrateKey(),
                        limit: LIMIT
                    ),
                    false => this.collectionIdsToSelect.Count() switch
                    {
                        0 => null,
                        _ => UniqueryPlus.Nfts.NftModel.GetNftsInCollectionOwnedByAsync(
                            [client.SubstrateClient],
                            this.collectionIdsToSelect.Dequeue(),
                            KeysModel.GetSubstrateKey(),
                            limit: LIMIT
                        ),
                    }
                };

            if (uniqueryNftEnumerable is null)
            {
                return;
            }

            uniqueryNftEnumerator = uniqueryNftEnumerable.GetAsyncEnumerator(token);

            await LoadMoreAsync(token).ConfigureAwait(false);
        }

        private async Task LoadSavedNftsAsync()
        {
            // Not favourite, owned Nfts
            var savedNfts = (await NftDatabase.GetNftsOwnedByAsync(KeysModel.GetSubstrateKey()))
                .Where(
                    t => t.NftBase != null &&
                    t.NftBase.Type == nftTypeToSelect &&
                    (
                         collectionIdsToSelect is null ||
                         collectionIdsToSelect.Contains(t.NftBase.CollectionId)
                    ) &&
                    t.NftBase.Id != nftIdToIgnore);

            foreach (var savedNft in savedNfts)
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

        [RelayCommand]
        private async Task NestAsync(INftBase nftBaseToNest)
        {
            CancellationToken token = CancellationToken.None;

            try
            {
                Method nest = ((INftNestable)nftBase).Nest(nftBaseToNest.CollectionId, nftBaseToNest.Id);

                var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

                await transactionAnalyzerConfirmationViewModel.LoadAsync(client, nest, false, token: token);
                
                this.IsVisible = false;
            }
            catch (Exception ex)
            {
                //errorLabel.Text = ex.Message;
                Console.WriteLine(ex);
            }
        }
    }
}
#nullable disable
