﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Components.WebView;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using Substrate.NetApi.Model.Extrinsics;
using System.Collections.ObjectModel;
using System.Numerics;
using UniqueryPlus.Collections;
using UniqueryPlus.External;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.Nft
{
    public partial class NftDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Name))]
        [NotifyPropertyChangedFor(nameof(Description))]
        [NotifyPropertyChangedFor(nameof(Image))]
        [NotifyPropertyChangedFor(nameof(Attributes))]
        [NotifyPropertyChangedFor(nameof(AttributesIsVisible))]
        private INftBase nftBase;

        public string Name => NftBase.Metadata?.Name ?? "Unknown";

        public string Description => NftBase.Metadata?.Description ?? "";

        public string Image => NftBase.Metadata?.Image ?? "";

        public ObservableCollection<MetadataAttribute> Attributes => new ObservableCollection<MetadataAttribute>(NftBase.Metadata?.Attributes ?? []);
        public bool AttributesIsVisible => NftBase.Metadata?.Attributes is not null && NftBase.Metadata.Attributes.Length > 0;

        [RelayCommand]
        public async Task TransferAsync()
        {
            var nftTransferViewModel = DependencyService.Get<NftTransferViewModel>();

            nftTransferViewModel.EndpointKey = Endpoint.Key;
            nftTransferViewModel.TransferFunction = ((INftTransferable)NftBase).Transfer;
            nftTransferViewModel.IsVisible = true;
            await nftTransferViewModel.GetFeeAsync();
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsOwned))]
        [NotifyPropertyChangedFor(nameof(OwnerAddressText))]
        [NotifyPropertyChangedFor(nameof(BuyViewIsVisible))]
        private string ownerAddress;

        public bool IsOwned => OwnerAddress == KeysModel.GetSubstrateKey();

        public string OwnerAddressText => IsOwned switch
        {
            true => "You",
            false => OwnerAddress,
        };

        [RelayCommand]
        public async Task CopyAddressAsync() => await CopyAddress.CopyToClipboardAsync(OwnerAddress);

        [RelayCommand]
        public async Task OpenSubscanOwnerPageAsync() => await Application.Current.MainPage.Navigation.PushAsync(new WebViewPage($"https://www.subscan.io/account/{OwnerAddress}"));


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PriceText))]
        private Endpoint endpoint;

        [ObservableProperty]
        private BigInteger collectionId = new BigInteger(0);

        [ObservableProperty]
        private BigInteger itemId = new BigInteger(0);

        [ObservableProperty]
        private bool favourite;

        [ObservableProperty]
        private Option<string> kodadotUnlockableUrl;

        [ObservableProperty]
        private string azeroIdReservedUntil;

        [ObservableProperty]
        private string[] collectionNftImages;

        [ObservableProperty]
        private bool collectionFavourite;

        [ObservableProperty]
        private ICollectionBase collectionBase;

        [ObservableProperty]
        private bool uniqueIsVisible;

        [RelayCommand]
        private async Task OpenUniqueAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new WebViewPage(((IUniqueMarketplaceLink)NftBase).UniqueMarketplaceLink));
        }

        [ObservableProperty]
        private bool kodaIsVisible;

        [RelayCommand]
        private async Task OpenKodaAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new WebViewPage(((IKodaLink)NftBase).KodaLink));
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FloorPriceText))]
        [NotifyPropertyChangedFor(nameof(TradingStatsIsVisible))]
        private BigInteger floorPrice;

        public string FloorPriceText => String.Format("{0:0.00} {1}", (double)FloorPrice / double.Pow(10, Endpoint.Decimals), Endpoint.Unit);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HighestSaleText))]
        [NotifyPropertyChangedFor(nameof(TradingStatsIsVisible))]
        private BigInteger highestSale;

        public string HighestSaleText => String.Format("{0:0.00} {1}", (double)HighestSale / double.Pow(10, Endpoint.Decimals), Endpoint.Unit);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(VolumeText))]
        [NotifyPropertyChangedFor(nameof(TradingStatsIsVisible))]
        private BigInteger volume;
        public string VolumeText => String.Format("{0:0.00} {1}", (double)Volume / double.Pow(10, Endpoint.Decimals), Endpoint.Unit);
        public bool TradingStatsIsVisible => HighestSale > 0 || Volume > 0 || FloorPrice > 0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(BuyViewIsVisible))]
        [NotifyPropertyChangedFor(nameof(SoldForViewIsVisible))]
        private bool isForSale = false;

        public bool BuyViewIsVisible => IsForSale && !IsOwned;
        public bool SoldForViewIsVisible => IsForSale && IsOwned;


        [RelayCommand]
        public async Task BuyAsync()
        {
            CancellationToken token = CancellationToken.None;
            var clientExt = await Model.SubstrateClientModel.GetOrAddSubstrateClientAsync(Endpoint.Key, token);

            var client = clientExt.SubstrateClient;

            Method buy = NftBase switch {
                INftBuyable nftBuyable => nftBuyable.Buy(),
                INftBuyableWithReceiver nftBuyableWithReceiver => nftBuyableWithReceiver.Buy(KeysModel.GetSubstrateKey()),
                INftEVMBuyableWithReceiver nftEVMBuyableWithReceiver => nftEVMBuyableWithReceiver.Buy(KeysModel.GetSubstrateKey(), KeysModel.GetSubstrateKey()),
                _ => throw new NotSupportedException()
            };

            try
            {
                var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

                await transactionAnalyzerConfirmationViewModel.LoadAsync(clientExt, buy, false);
            }
            catch (Exception ex)
            {
                //errorLabel.Text = ex.Message;
                Console.WriteLine(ex);
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PriceText))]
        private BigInteger price;

        public string PriceText => String.Format("{0:0.00} {1}", (double)Price / double.Pow(10, Endpoint.Decimals), Endpoint.Unit);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsTransferable))]
        private ButtonStateEnum transferButtonState = ButtonStateEnum.Disabled;

        public bool IsTransferable => TransferButtonState == ButtonStateEnum.Enabled;
        public bool IsSoulbound => TransferButtonState == ButtonStateEnum.Disabled;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsSellable))]
        private ButtonStateEnum sellButtonState = ButtonStateEnum.Disabled;

        public bool IsSellable => SellButtonState == ButtonStateEnum.Enabled;

        [RelayCommand]
        public async Task SellAsync()
        {
            var nftSellViewModel = DependencyService.Get<NftSellViewModel>();

            nftSellViewModel.Endpoint = Endpoint;

            nftSellViewModel.SellFunction = NftBase switch
            {
                INftSellable nftSellable => nftSellable.Sell,
                INftEVMSellable nftEVMSellable => (BigInteger price) => nftEVMSellable.Sell(price, KeysModel.GetSubstrateKey()),
                _ => throw new NotSupportedException()
            };

            nftSellViewModel.IsVisible = true;

            await nftSellViewModel.GetFeeAsync(Endpoint.Key, NftBase);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsModifiable))]
        private ButtonStateEnum modifyButtonState = ButtonStateEnum.Disabled;
        public bool IsModifiable => ModifyButtonState == ButtonStateEnum.Enabled;

        [RelayCommand]
        private void Modify()
        {
            // TODO
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsBurnable))]
        private ButtonStateEnum burnButtonState = ButtonStateEnum.Disabled;
        public bool IsBurnable => BurnButtonState == ButtonStateEnum.Enabled;

        [RelayCommand]
        private async Task BurnAsync()
        {
            CancellationToken token = CancellationToken.None;
            var clientExt = await Model.SubstrateClientModel.GetOrAddSubstrateClientAsync(Endpoint.Key, token);

            var client = clientExt.SubstrateClient;

            try
            {
                Method burn = ((INftBurnable)NftBase).Burn();

                var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

                await transactionAnalyzerConfirmationViewModel.LoadAsync(clientExt, burn, false, token: token);
            }
            catch (Exception ex)
            {
                //errorLabel.Text = ex.Message;
                Console.WriteLine(ex);
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NestedNftsLoading))]
        private bool isNestable = false;

        [ObservableProperty]
        private ButtonStateEnum nestButtonState = ButtonStateEnum.Invisible;

        [RelayCommand]
        public async Task NestAsync()
        {
            var token = CancellationToken.None;
            var nestNftSelectViewModel = DependencyService.Get<NestNftSelectViewModel>();

            await nestNftSelectViewModel.AppearAsync(((ICollectionNestable)CollectionBase).RestrictedByCollectionIds, NftBase, Endpoint, token);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NestedNftsLoading))]
        private ObservableCollection<NftWrapper> nestedNfts = new ObservableCollection<NftWrapper>();

        public string NestedNftsLoading => (IsNestable, NestedNfts.Count()) switch
        {
            (false, _) => "Loading",
            (true, 0) => "No nested NFTs",
            (true, _) => ""
        };

        [ObservableProperty]
        private INftBase parentNftBase;

        [ObservableProperty]
        private bool parentNftFavourite;

        [ObservableProperty]
        private bool hasParentNft = false;
    }
}
