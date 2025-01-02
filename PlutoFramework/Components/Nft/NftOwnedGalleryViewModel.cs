using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using System.Collections.ObjectModel;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);

namespace PlutoFramework.Components.Nft
{
    public partial class NftOwnedGalleryViewModel : ObservableObject
    {
        private const int displayLimit = 4;

        // There is no ObserableDictionary<_> type
        private Dictionary<NftKey, NftWrapper> ownedNftsDict = new Dictionary<NftKey, NftWrapper>();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NoOwnedNfts))]
        [NotifyPropertyChangedFor(nameof(LoadingOwnedNfts))]
        private bool loading = true;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NoOwnedNfts))]
        [NotifyPropertyChangedFor(nameof(AnyOwnedNfts))]
        [NotifyPropertyChangedFor(nameof(LoadingOwnedNfts))]
        private ObservableCollection<NftWrapper> ownedNfts = new ObservableCollection<NftWrapper>();
        public bool NoOwnedNfts => !Loading && OwnedNfts.Count == 0;
        public bool AnyOwnedNfts => OwnedNfts.Count() > 0;
        public bool LoadingOwnedNfts => Loading && OwnedNfts.Count() < displayLimit;

        public async Task LoadSavedNftsAsync()
        {
            Loading = true;

            // owned Nfts
            foreach (var savedNft in await NftDatabase.GetNftsOwnedByAsync(KeysModel.GetSubstrateKey()).ConfigureAwait(false))
            {
                if (savedNft.Key is not null && !ownedNftsDict.ContainsKey((NftKey)savedNft.Key))
                {
                    ownedNftsDict.Add((NftKey)savedNft.Key, savedNft);

                    if (ownedNftsDict.Count() <= displayLimit)
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            if (OwnedNfts.Count() < displayLimit)
                                OwnedNfts.Add(savedNft);
                        });
                    }
                }
            }

            Loading = false;
        }

        [RelayCommand]
        public Task NavigateToNftOwnedPageAsync() => Application.Current.MainPage.Navigation.PushAsync(new NftListPage(new OwnedNftsListViewModel()));
    }
}
