using Nethereum.Util;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.Nft;
using PlutoFramework.Constants;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Types;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;
using UniqueryPlus;
using UniqueryPlus.Collections;
using UniqueryPlus.External;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);

namespace PlutoFramework.Model
{
    public class NftAssetWrapper : NftWrapper
    {
        public required Asset? AssetPrice { get; set; }
        public required NftOperation Operation { get; set; }
    }
    public class MockNft : INftBase, IKodaLink
    {
        public NftTypeEnum Type => NftTypeEnum.PolkadotAssetHub_NftsPallet;
        public required BigInteger CollectionId { get; set; }
        public required BigInteger Id { get; set; }
        public required string Owner { get; set; }
        public MetadataBase? Metadata { get; set; }
        public string KodaLink => $"https://koda.art/ahp/nft/{CollectionId}/{Id}";
        public async Task<ICollectionBase> GetCollectionAsync(CancellationToken token)
        {
            return CollectionModel.GetMockCollection();
        }

        public async Task<INftBase> GetFullAsync(CancellationToken token)
        {
            return this;
        }
    }

    public class NftWrapper : INotifyPropertyChanged
    {
        public NftKey? Key => NftBase is not null ? (NftBase.Type, NftBase.CollectionId, NftBase.Id) : null;
        public INftBase? NftBase { get; set; }
        public Endpoint? Endpoint { get; set; }

        private bool favourite = false;
        public bool Favourite
        {
            get => favourite;
            set
            {
                if (favourite != value)
                {
                    favourite = value;
                    OnPropertyChanged(nameof(Favourite));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public override bool Equals(object? obj)
        {
            return obj is NftWrapper objNft &&
                    objNft.NftBase?.Metadata?.Name == this.NftBase?.Metadata?.Name &&
                    objNft.NftBase?.Metadata?.Description == this.NftBase?.Metadata?.Description &&
                    objNft.NftBase?.Metadata?.Image == this.NftBase?.Metadata?.Image &&
                    objNft.Endpoint?.Key == this.Endpoint?.Key;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NftBase?.Metadata?.Name, NftBase?.Metadata?.Description, NftBase?.Metadata?.Image, Endpoint?.Key);
        }

        public override string ToString()
        {
            return this.NftBase?.Metadata?.Name + " - " + this.NftBase?.Metadata?.Image;
        }
    }
    public class NftModel
    {
        public static INftBase GetMockNft(
            string name = "Mock Nft",
            string imageSource = "darkbackground2.png"
        )
        {
            Random random = new Random();

            int digits = random.Next(1, 9);

            return new MockNft
            {
                CollectionId = random.Next((int)Math.Pow(10, digits)),
                Id = random.Next((int)Math.Pow(10, digits)),
                Metadata = new MetadataBase
                {
                    Name = name,
                    Description = "Welcome, this is a mock Nft to test the UI for Nft views even without an internet connection. Yes, it is pretty handy! I need to make the description a little bit longer to test the edge cases with having a text to go out of bounds of the visible View.",
                    Image = imageSource,
                },
                Owner = "5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y"
            };
        }

        public static NftWrapper ToNftWrapper(INftBase nft)
        {
            if (nft.Metadata is not null && nft.Metadata.Image is null)
            {
                nft.Metadata.Image = "noimage.png";
            }
            return new NftWrapper
            {
                NftBase = nft,
                Endpoint = Endpoints.GetEndpointDictionary[GetEndpointKey(nft.Type)]
            };
        }

        public static async Task<NftAssetWrapper> ToNftNativeAssetWrapperAsync(INftBase nft, Endpoint endpoint, CancellationToken token)
        {
            var nftWrapper = ToNftWrapper(nft);

            BigInteger? price = nft is INftMarketPrice ?
                    await ((INftMarketPrice)nft).GetMarketPriceAsync(token) : null;

            return new NftAssetWrapper
            {
                NftBase = nft,
                Endpoint = Endpoints.GetEndpointDictionary[GetEndpointKey(nft.Type)],
                AssetPrice = (price is not null || price != 0) ? new Asset
                {
                    Amount = (double)(price ?? 1) / Math.Pow(10, endpoint.Decimals),
                    Pallet = AssetPallet.Native,
                    Symbol = endpoint.Unit,
                    ChainIcon = endpoint.Icon,
                    DarkChainIcon = endpoint.DarkIcon,
                    AssetId = 0,
                    Endpoint = endpoint,
                    Decimals = endpoint.Decimals
                } : null,
                Operation = NftOperation.None,
            };
        }

        public static EndpointEnum GetEndpointKey(NftTypeEnum nftType) => nftType switch
        {
            NftTypeEnum.PolkadotAssetHub_NftsPallet => EndpointEnum.PolkadotAssetHub,
            NftTypeEnum.KusamaAssetHub_NftsPallet => EndpointEnum.KusamaAssetHub,
            NftTypeEnum.Unique => EndpointEnum.Unique,
            NftTypeEnum.Opal => EndpointEnum.Opal,
            NftTypeEnum.Mythos => EndpointEnum.Mythos,
            NftTypeEnum.XcavatePaseo => EndpointEnum.XcavatePaseo,
            _ => throw new NotImplementedException(),
        };

        public static async Task NavigateToNftDetailPageAsync(INftBase nftBase, Endpoint endpoint, bool favourite, CancellationToken token)
        {
            try
            {
                var viewModel = new NftDetailViewModel();

                viewModel.Endpoint = endpoint;
                viewModel.CollectionId = nftBase.CollectionId;
                viewModel.ItemId = nftBase.Id;
                viewModel.Favourite = favourite;
                viewModel.OwnerAddress = nftBase.Owner;

                var savedCollection = await CollectionDatabase.GetCollectionAsync($"{nftBase.Type}-{nftBase.CollectionId}");

                if (savedCollection is not null)
                {
                    viewModel.CollectionFavourite = savedCollection.Favourite;
                    viewModel.CollectionBase = savedCollection.CollectionBase;
                    viewModel.CollectionNftImages = savedCollection.NftImages;
                }

                await UpdateViewModelAsync(viewModel, nftBase, token);

                if (endpoint.Key == EndpointEnum.AzeroTestnet)
                {
                    viewModel.AzeroIdReservedUntil = await Model.AzeroId.AzeroIdModel.GetReservedUntilStringForName(nftBase.Metadata.Name).ConfigureAwait(false);
                }

                await Application.Current.MainPage.Navigation.PushAsync(new NftDetailPage(viewModel));

                // load these details after
                viewModel.KodadotUnlockableUrl = await Model.Kodadot.UnlockablesModel.FetchKeywiseAsync(endpoint, nftBase.CollectionId).ConfigureAwait(false);

                try
                {
                    if (savedCollection is null)
                    {
                        savedCollection = await Model.CollectionModel.ToCollectionWrapperAsync(await nftBase.GetCollectionAsync(token).ConfigureAwait(false), CancellationToken.None).ConfigureAwait(false);

                        viewModel.CollectionBase = savedCollection.CollectionBase;
                        viewModel.CollectionNftImages = savedCollection.NftImages;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                ICollectionBase fullCollection = null;
                try
                {
                    fullCollection = await savedCollection.CollectionBase.GetFullAsync(token).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                if (fullCollection is not null && fullCollection is ICollectionStats)
                {
                    viewModel.FloorPrice = ((ICollectionStats)fullCollection).FloorPrice;
                    viewModel.HighestSale = ((ICollectionStats)fullCollection).HighestSale;
                    viewModel.Volume = ((ICollectionStats)fullCollection).Volume;
                }

                var fullNft = await nftBase.GetFullAsync(token).ConfigureAwait(false);

                if (fullNft is INftNestable)
                {
                    viewModel.IsNestable = true;
                    viewModel.NestedNfts = new ObservableCollection<NftWrapper>((await ((INftNestable)fullNft).GetNestedNftsAsync(token).ConfigureAwait(false)).Select(nestedNftWrapper => Model.NftModel.ToNftWrapper(nestedNftWrapper.NftBase)));
                }

                if (fullNft is INftNestable && (fullNft as INftNestable).HasParentNft)
                {
                    viewModel.HasParentNft = true;
                    viewModel.ParentNftBase = await (fullNft as INftNestable).GetParentNftAsync(token).ConfigureAwait(false);
                    viewModel.ParentNftFavourite = await NftDatabase.IsNftFavouriteAsync(viewModel.ParentNftBase.Type, viewModel.ParentNftBase.CollectionId, viewModel.ParentNftBase.Id).ConfigureAwait(false);
                }

                if (
                    fullNft is INftNestable &&
                    fullCollection is not null &&
                    fullCollection is ICollectionNestable &&
                    (
                        (((ICollectionNestable)fullCollection).IsNestableByTokenOwner && fullNft.Owner == KeysModel.GetSubstrateKey()) ||
                        (((ICollectionNestable)fullCollection).IsNestableByCollectionOwner && fullCollection.Owner == KeysModel.GetSubstrateKey())
                    )
                )
                {
                    viewModel.NestButtonState = ButtonStateEnum.Enabled;
                }

                await UpdateViewModelAsync(viewModel, fullNft, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static async Task UpdateViewModelAsync(NftDetailViewModel viewModel, INftBase nft, CancellationToken token)
        {
            viewModel.NftBase = nft;

            viewModel.Price = nft switch
            {
                INftBuyable nftBuyable => nftBuyable.IsForSale ? nftBuyable.Price ?? 0 : 0,
                INftBuyableWithReceiver nftBuyableWithReceiver => nftBuyableWithReceiver.IsForSale ? nftBuyableWithReceiver.Price ?? 0 : 0,
                INftEVMBuyableWithReceiver nftEVMBuyableWithReceiver => nftEVMBuyableWithReceiver.IsForSale ? nftEVMBuyableWithReceiver.Price ?? 0 : 0,
                _ => 0
            };

            viewModel.IsForSale = (nft is INftBuyable && ((INftBuyable)nft).IsForSale) ||
                (nft is INftBuyableWithReceiver && ((INftBuyableWithReceiver)nft).IsForSale) ||
                (nft is INftEVMBuyableWithReceiver && ((INftEVMBuyableWithReceiver)nft).IsForSale);

            viewModel.KodaIsVisible = nft is IKodaLink;
            viewModel.UniqueIsVisible = nft is IUniqueMarketplaceLink;

            viewModel.TransferButtonState = (nft is INftTransferable && ((INftTransferable)nft).IsTransferable) ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;
            viewModel.SellButtonState = nft is INftSellable || nft is INftEVMSellable ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

            viewModel.ModifyButtonState = ButtonStateEnum.Disabled; // Maybe later
            viewModel.BurnButtonState = nft is INftBurnable && ((INftBurnable)nft).IsBurnable ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;
        }

        public static async Task NavigateToCollectionDetailPageAsync(ICollectionBase collectionBase, Endpoint endpoint, bool favourite, CancellationToken token)
        {
            try
            {
                var viewModel = new CollectionDetailViewModel();

                viewModel.Endpoint = endpoint;
                viewModel.CollectionId = collectionBase.CollectionId;
                viewModel.Favourite = favourite;
                viewModel.OwnerAddress = collectionBase.Owner;

                await UpdateViewModelAsync(viewModel, collectionBase, token);

                await Application.Current.MainPage.Navigation.PushAsync(new CollectionDetailPage(viewModel));

                var fullCollection = await collectionBase.GetFullAsync(token);

                await UpdateViewModelAsync(viewModel, fullCollection, token);

                viewModel.Nfts = new ObservableCollection<NftWrapper>((await fullCollection.GetNftsAsync(25, null, token)).Select(Model.NftModel.ToNftWrapper));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task UpdateViewModelAsync(CollectionDetailViewModel viewModel, ICollectionBase collection, CancellationToken token)
        {
            if (collection is ICollectionStats)
            {
                viewModel.FloorPrice = ((ICollectionStats)collection).FloorPrice;
                viewModel.HighestSale = ((ICollectionStats)collection).HighestSale;
                viewModel.Volume = ((ICollectionStats)collection).Volume;
            }

            viewModel.KodaIsVisible = collection is IKodaLink;
            viewModel.UniqueIsVisible = collection is IUniqueMarketplaceLink;

            viewModel.TransferButtonState = collection is ICollectionTransferable && ((ICollectionTransferable)collection).IsTransferable ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;
            viewModel.ModifyButtonState = ButtonStateEnum.Disabled; // Maybe later

            viewModel.CollectionBase = collection;

            if (collection is ICollectionEVMClaimable)
            {
                var eventInfo = await ((ICollectionEVMClaimable)collection).GetEventInfoAsync(token).ConfigureAwait(false);

                if (eventInfo is not null)
                {
                    viewModel.EventStartTimestamp = (long)eventInfo.StartTimestamp;
                    viewModel.EventEndTimestamp = (long)eventInfo.EndTimestamp;

                    var timestampNow = DateTime.Now.ToUnixTimestamp();

                    var canBeClaimed = (eventInfo.StartTimestamp <= timestampNow && timestampNow < eventInfo.EndTimestamp);
                    Console.WriteLine("Can be claimed" + canBeClaimed);
                    viewModel.ClaimButtonState = canBeClaimed ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;
                }
                else
                {
                    Console.WriteLine("EVM event info was null");
                }
            }

            if (collection is ICollectionMintConfig)
            {
                viewModel.MintPrice = (collection as ICollectionMintConfig).MintPrice;
                viewModel.MintStartBlock = (collection as ICollectionMintConfig).MintStartBlock;
                viewModel.MintEndBlock = (collection as ICollectionMintConfig).MintEndBlock;
                viewModel.MintType = (collection as ICollectionMintConfig).MintType;
                viewModel.NftMaxSuply = (collection as ICollectionMintConfig).NftMaxSuply;
            }

            if (collection is ICollectionCreatedAt)
            {
                viewModel.DateOfCreation = (collection as ICollectionCreatedAt).CreatedAt.UtcDateTime;
            }

            if (collection is ICollectionNftsSoulbound)
            {
                viewModel.NftsSoulbound = (collection as ICollectionNftsSoulbound).NftsSoulbound;
            }
        }
    }
}
