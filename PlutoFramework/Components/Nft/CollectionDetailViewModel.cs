using CommunityToolkit.Mvvm.ComponentModel;
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
using UniqueryPlus.Metadata;

namespace PlutoFramework.Components.Nft
{
    public partial class CollectionDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Name))]
        [NotifyPropertyChangedFor(nameof(Description))]
        [NotifyPropertyChangedFor(nameof(Image))]
        [NotifyPropertyChangedFor(nameof(Attributes))]
        [NotifyPropertyChangedFor(nameof(AttributesIsVisible))]
        [NotifyPropertyChangedFor(nameof(NftsMintedText))]
        private ICollectionBase collectionBase;
        public string Name => CollectionBase.Metadata?.Name ?? "Unknown";
        public string Description => CollectionBase.Metadata?.Description ?? "";
        public string Image => CollectionBase.Metadata?.Image ?? "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NftsMintedText))]
        private uint? nftMaxSuply = null;
        public string NftsMintedText => (NftMaxSuply is not null) ? $"{CollectionBase.NftCount}/{NftMaxSuply}" : CollectionBase.NftCount.ToString();

        [ObservableProperty]
        private MintType mintType;

        [ObservableProperty]
        private BigInteger? mintStartBlock;

        [ObservableProperty]
        private BigInteger? mintEndBlock;

        [ObservableProperty]
        private DateTime dateOfCreation;

        [ObservableProperty]
        private bool nftsSoulbound;
        public ObservableCollection<MetadataAttribute> Attributes => new ObservableCollection<MetadataAttribute>(CollectionBase.Metadata?.Attributes ?? []);
        public bool AttributesIsVisible => CollectionBase.Metadata?.Attributes is not null && CollectionBase.Metadata.Attributes.Length > 0;

        [ObservableProperty]
        private ObservableCollection<NftWrapper> nfts = new ObservableCollection<NftWrapper>();

        [RelayCommand]
        public async Task TransferAsync()
        {
            var collectionTransferViewModel = DependencyService.Get<NftTransferViewModel>();

            collectionTransferViewModel.EndpointKey = Endpoint.Key;
            collectionTransferViewModel.TransferFunction = ((ICollectionTransferable)CollectionBase).Transfer;
            collectionTransferViewModel.IsVisible = true;
            await collectionTransferViewModel.GetFeeAsync();
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsOwned))]
        [NotifyPropertyChangedFor(nameof(OwnerAddressText))]
        private string ownerAddress;

        public bool IsOwned => OwnerAddress == KeysModel.GetSubstrateKey();

        public string OwnerAddressText => IsOwned switch
        {
            true => "You",
            false => OwnerAddress,
        };

        [ObservableProperty]
        private uint maxNfts;

        [ObservableProperty]
        private bool mintable;

        [RelayCommand]
        public async Task CopyAddressAsync() => await CopyAddress.CopyToClipboardAsync(OwnerAddress);

        [RelayCommand]
        public async Task OpenSubscanOwnerPageAsync() => await Application.Current.MainPage.Navigation.PushAsync(new WebViewPage($"https://www.subscan.io/account/{OwnerAddress}"));


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MintPriceText))]
        private Endpoint endpoint;

        [ObservableProperty]
        private BigInteger collectionId = new BigInteger(0);

        [ObservableProperty]
        private bool favourite;

        [ObservableProperty]
        private string[] collectionNftImages;

        [ObservableProperty]
        private bool collectionFavourite;

        [ObservableProperty]
        private bool uniqueIsVisible;

        [ObservableProperty]
        private bool kodaIsVisible;


        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MintPriceText))]
        private BigInteger? mintPrice = null;
        public string? MintPriceText => MintPrice is null ? null : String.Format("{0:0.00} {1}", (double)MintPrice / double.Pow(10, Endpoint.Decimals), Endpoint.Unit);

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
        [NotifyPropertyChangedFor(nameof(IsTransferable))]
        private ButtonStateEnum transferButtonState = ButtonStateEnum.Disabled;

        public bool IsTransferable => TransferButtonState == ButtonStateEnum.Enabled;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsModifiable))]
        [NotifyPropertyChangedFor(nameof(IsImmutable))]
        private ButtonStateEnum modifyButtonState = ButtonStateEnum.Disabled;
        public bool IsModifiable => ModifyButtonState == ButtonStateEnum.Enabled;
        public bool IsImmutable => ModifyButtonState != ButtonStateEnum.Enabled;

        [ObservableProperty]
        private long eventStartTimestamp;

        [ObservableProperty]
        private long eventEndTimestamp;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsClaimable))]
        private ButtonStateEnum claimButtonState = ButtonStateEnum.Invisible;
        public bool IsClaimable => ClaimButtonState != ButtonStateEnum.Invisible;

        [RelayCommand]
        public async Task ClaimAsync()
        {
            CancellationToken token = CancellationToken.None;
            var clientExt = await Model.SubstrateClientModel.GetOrAddSubstrateClientAsync(Endpoint.Key, token);

            var client = clientExt.SubstrateClient;

            if (CollectionBase is not ICollectionEVMClaimable)
            {
                Console.WriteLine("It was not EVM claimable");
                return;
            }

            try
            {
                Method claim = ((ICollectionEVMClaimable)CollectionBase).Claim(KeysModel.GetSubstrateKey());

                var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

                await transactionAnalyzerConfirmationViewModel.LoadAsync(clientExt, claim, false, token: token);
            }
            catch (Exception ex)
            {
                //errorLabel.Text = ex.Message;
                Console.WriteLine(ex);
            }
        }
    }
}
