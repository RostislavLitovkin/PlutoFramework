using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Components.WebView;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Xcavate;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;
using PropertyModel = PlutoFramework.Model.Xcavate.XcavatePropertyModel;

namespace PlutoFramework.Components.XcavateProperty
{
    public enum MainActionStates
    {
        Buy,
        Expired,
        Refund,
        SoldOut,
        Unknown
    }

    public partial class PropertyDetailViewModel : ObservableObject
    {
        private MainActionStates getMainActionState => (ListingHasExpired, TokensOwned, ListingDetails?.ListedTokens) switch
        {
            (true, 0, _) => MainActionStates.Expired,
            (true, _, _) => MainActionStates.Refund,
            (false, _, > 0) => MainActionStates.Buy,
            (false, _, null) => MainActionStates.SoldOut,
            (false, _, 0) => MainActionStates.SoldOut,
            //_ => MainActionStates.Unknown,
        };

        [ObservableProperty]
        private Endpoint endpoint;

        [ObservableProperty]
        private INftBase nftBase;

        [ObservableProperty]
        private XcavateRegion region;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AreaPricesPercentage))]
        [NotifyPropertyChangedFor(nameof(RentalDemandPercentage))]
        [NotifyPropertyChangedFor(nameof(LocationShortName))]
        [NotifyPropertyChangedFor(nameof(ListingPrice))]
        [NotifyPropertyChangedFor(nameof(PricePerTokenText))]
        [NotifyPropertyChangedFor(nameof(Apy))]
        [NotifyPropertyChangedFor(nameof(TokensAvailable))]
        [NotifyPropertyChangedFor(nameof(RentalIncome))]
        [NotifyPropertyChangedFor(nameof(TokensOwnedWorth))]
        private PropertyMetadata? metadata;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MainActionButtonState))]
        [NotifyPropertyChangedFor(nameof(MainActionText))]
        private XcavateOngoingObjectListingDetails? listingDetails;

        public double AreaPricesPercentage => PropertyModel.GetAreaPricesPercentage(Metadata?.PropertyPrice ?? 0);
        public double RentalDemandPercentage => PropertyModel.GetRentalDemand();

        public string LocationShortName => $"{Metadata?.AddressStreet}, {Metadata?.AddressTownCity}";

        public string ListingPrice => ((decimal)(Metadata?.PropertyPrice ?? 0)).ToCurrencyString();

        public string PricePerTokenText => $"{ ((decimal)(Metadata?.PricePerToken ?? 0)).ToCurrencyString() } [{String.Format((string)Application.Current.Resources["CurrencyFormat"], Metadata?.PricePerToken)} USDT]";

        public string Apy => PropertyModel.GetAPY(Metadata?.EstimatedRentalIncome ?? (decimal)1, Metadata?.PropertyPrice ?? 1);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TokensAvailable))]
        private uint tokensListed;

        public string TokensAvailable => $"{ListingDetails?.ListedTokens.ToString() ?? "-"} / {Metadata?.NumberOfTokens.ToString() ?? "-"}";

        public string RentalIncome => ((decimal)(Metadata?.EstimatedRentalIncome ?? 0)).ToCurrencyString();

        [ObservableProperty]
        private string companyName = "Needs to be filled";
  
        [ObservableProperty]
        private string companyImage = "xcavate.png";

        [RelayCommand]
        public Task OpenMapAsync() => Task.FromResult(0); //Browser.Default.OpenAsync(<location url>, BrowserLaunchMode.SystemPreferred);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TokensOwnedWorth))]
        [NotifyPropertyChangedFor(nameof(OwnedPropertyTokensViewIsVisible))]
        [NotifyPropertyChangedFor(nameof(RelistPropertyTokensButtonIsVisible))]
        private uint tokensOwned = 0;

        public string TokensOwnedWorth => ((decimal)(TokensOwned * Metadata?.PricePerToken ?? 0)).ToCurrencyString();

        public bool OwnedPropertyTokensViewIsVisible => TokensOwned > 0;

        public bool RelistPropertyTokensButtonIsVisible => TokensOwned > 0;

        public string MainActionText => getMainActionState switch
        {
            MainActionStates.Buy => "Buy",
            MainActionStates.Expired => "Expired",
            MainActionStates.Refund => "Refund",
            MainActionStates.SoldOut => "Sold Out",
            MainActionStates.Unknown => "Unknown",
            _ => "Unknown",
        };
        public ButtonStateEnum MainActionButtonState => getMainActionState switch
        {
            MainActionStates.Buy => ButtonStateEnum.Enabled,
            MainActionStates.Expired => ButtonStateEnum.Disabled,
            MainActionStates.Refund => ButtonStateEnum.Enabled,
            MainActionStates.SoldOut => ButtonStateEnum.Disabled,
            MainActionStates.Unknown => ButtonStateEnum.Disabled,
            _ => ButtonStateEnum.Disabled,
        };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MainActionButtonState))]
        [NotifyPropertyChangedFor(nameof(MainActionText))]
        private bool listingHasExpired = false;

        [RelayCommand]
        public Task MainActionAsync()
        {
            switch (getMainActionState)
            {
                case MainActionStates.Buy:
                    return BuyAsync();
                case MainActionStates.Refund:
                    // TODO refund here
                    return Task.FromResult(0);

            }

            return Task.FromResult(0);
        }

        public async Task BuyAsync()
        {
            if (!await RequirementsModel.CheckRequirementsAsync())
            {
                return;
            }

            var viewModel = DependencyService.Get<BuyPropertyTokensViewModel>();

            viewModel.ListingDetails = ListingDetails;
            viewModel.Metadata = Metadata;
            viewModel.IsVisible = true;
            viewModel.EndpointKey = PlutoFrameworkCore.NftModel.GetEndpointKey(NftBase.Type);   
        }

        [RelayCommand]
        public async Task RelistAsync()
        {
            if (!await RequirementsModel.CheckRequirementsAsync())
            {
                return;
            }

            var viewModel = DependencyService.Get<RelistPropertyTokensViewModel>();

            viewModel.ListingDetails = ListingDetails;
            viewModel.Metadata = Metadata;
            viewModel.IsVisible = true;
            viewModel.EndpointKey = PlutoFrameworkCore.NftModel.GetEndpointKey(NftBase.Type);
            viewModel.TokensOwned = TokensOwned;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FavouriteImage))]
        private bool favourite = false;

        public ImageSource FavouriteImage => new FontImageSource
        {
            Color = (Color)Application.Current.Resources["Primary"],
            FontFamily = "FontAwesome",
            Size = 25,
            Glyph = Favourite ? "\uf004" : "\uf08a",
            FontAutoScalingEnabled = false
        };



        [RelayCommand]
        public async Task MakeFavouriteAsync()
        {
            Favourite = !Favourite;

            await XcavatePropertyDatabase.SavePropertyAsync(new NftWrapper
            {
                Endpoint = Endpoint,
                NftBase = NftBase,
                Favourite = Favourite
            });

            UpdateFavouritePropertiesModel.UpdateFavourite(NftBase as INftXcavateBase, Favourite);
        }

        [RelayCommand]
        public Task ShareAsync() => Share.RequestAsync(new ShareTextRequest
            {
                Uri = $"https://realxmarket.xcavate.io/marketplace/{ListingDetails?.AssetId}",
                Title = $"Share {Metadata?.PropertyName}",
            });

        [RelayCommand]
        public Task NavigateToFeesAsync() => Shell.Current.Navigation.PushAsync(new WebViewPage("https://realxmarket.xcavate.io/property-info-fees"));
    }
}
