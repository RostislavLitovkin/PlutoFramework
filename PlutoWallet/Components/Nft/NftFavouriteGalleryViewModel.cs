using CommunityToolkit.Mvvm.ComponentModel;
using PlutoWallet.Model;
using PlutoWallet.Model.SQLite;
using System.Collections.ObjectModel;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);

namespace PlutoWallet.Components.Nft
{
    public partial class NftFavouriteGalleryViewModel : ObservableObject
    {
        private const int displayLimit = 4;

        // There is no ObserableDictionary<_> type
        private Dictionary<NftKey, NftWrapper> favouriteNftsDict = new Dictionary<NftKey, NftWrapper>();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NoFavouriteNfts))]
        [NotifyPropertyChangedFor(nameof(LoadingFavouriteNfts))]
        private bool loading = true;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NoFavouriteNfts))]
        [NotifyPropertyChangedFor(nameof(AnyFavouriteNfts))]
        [NotifyPropertyChangedFor(nameof(LoadingFavouriteNfts))]
        private ObservableCollection<NftWrapper> favouriteNfts = new ObservableCollection<NftWrapper>();
        public bool NoFavouriteNfts => !Loading && FavouriteNfts.Count == 0;
        public bool AnyFavouriteNfts => FavouriteNfts.Count() > 0;
        public bool LoadingFavouriteNfts => Loading && FavouriteNfts.Count() < displayLimit;

        public async Task LoadSavedNftsAsync()
        {

            Console.WriteLine("Loading saved NFTs");

            Loading = true;

            // favourite Nfts
            foreach (var savedNft in await NftDatabase.GetFavouriteNftsAsync().ConfigureAwait(false))
            {
                if (savedNft.Key is not null && !favouriteNftsDict.ContainsKey((NftKey)savedNft.Key))
                {
                    favouriteNftsDict.Add((NftKey)savedNft.Key, savedNft);

                    if (favouriteNftsDict.Count() <= displayLimit)
                    {
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            if (FavouriteNfts.Count() < displayLimit)
                                FavouriteNfts.Add(savedNft);
                        });
                    }
                }
            }

            Loading = false;

            Console.WriteLine("Loading finished");
        }
    }
}
