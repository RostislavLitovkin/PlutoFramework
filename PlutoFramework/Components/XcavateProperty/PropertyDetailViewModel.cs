using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Account;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Xcavate;
using SocketIOClient.Messages;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;
using PropertyModel = PlutoFramework.Model.Xcavate.XcavatePropertyModel;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class PropertyDetailViewModel : ObservableObject
    {
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
        private XcavateMetadata? metadata;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(BuyButtonState))]
        private NftMarketplaceDetails? nftMarketplaceDetails;

        public double AreaPricesPercentage => PropertyModel.GetAreaPricesPercentage(Metadata?.PropertyPrice ?? 0);
        public double RentalDemandPercentage => PropertyModel.GetRentalDemand();

        public string LocationShortName => $"{Metadata?.AddressStreet}, {Metadata?.AddressTownCity}";

        public string ListingPrice=> $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{
            String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * Metadata?.PropertyPrice)
            }";

        public string PricePerTokenText => $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{
            String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * Metadata?.PricePerToken)
            } [{String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, Metadata?.PricePerToken)} USDT]";

        public string Apy => PropertyModel.GetAPY(Metadata?.EstimatedRentalIncome ?? 1, Metadata?.PropertyPrice ?? 1);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TokensAvailable))]
        private uint tokensListed;

        public string TokensAvailable => $"{NftMarketplaceDetails?.Listed.ToString() ?? "-"} / {Metadata?.NumberOfTokens.ToString() ?? "-"}";

        public string RentalIncome => $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{
            String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * Metadata?.EstimatedRentalIncome)
            }";

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

        public string TokensOwnedWorth => $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * (TokensOwned * Metadata?.PricePerToken ?? 0))}";

        public bool OwnedPropertyTokensViewIsVisible => TokensOwned > 0;

        public bool RelistPropertyTokensButtonIsVisible => TokensOwned > 0;

        public ButtonStateEnum BuyButtonState => ListingHasExpired ? ButtonStateEnum.Disabled :
            NftMarketplaceDetails?.Listed > 0 ? ButtonStateEnum.Enabled : ButtonStateEnum.Disabled;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(BuyButtonState))]
        private bool listingHasExpired = false;

        [RelayCommand]
        public void Buy()
        {
            if (!AccountModel.CheckRequirements())
            {
                return;
            }

            var viewModel = DependencyService.Get<BuyPropertyTokensViewModel>();

            viewModel.NftMarketplaceDetails = NftMarketplaceDetails;
            viewModel.Metadata = Metadata;
            viewModel.IsVisible = true;
            viewModel.EndpointKey = Model.NftModel.GetEndpointKey(NftBase.Type);   
        }

        [RelayCommand]
        public void Relist()
        {
            if (!AccountModel.CheckRequirements())
            {
                return;
            }

            var viewModel = DependencyService.Get<RelistPropertyTokensViewModel>();

            viewModel.NftMarketplaceDetails = NftMarketplaceDetails;
            viewModel.Metadata = Metadata;
            viewModel.IsVisible = true;
            viewModel.EndpointKey = Model.NftModel.GetEndpointKey(NftBase.Type);
            viewModel.TokensOwned = TokensOwned;
        }

        [ObservableProperty]
        private bool favourite = false;

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
                Uri = $"https://realxmarket.xcavate.io/marketplace/{NftMarketplaceDetails?.AssetId}",
                Title = $"Share {Metadata?.PropertyName}",
            });

    }
}
