using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Account;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using UniqueryPlus.Metadata;
using UniqueryPlus.Nfts;
using PropertyModel = PlutoFramework.Model.Xcavate.XcavatePropertyModel;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class PropertyDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AreaPricesPercentage))]
        [NotifyPropertyChangedFor(nameof(RentalDemandPercentage))]
        [NotifyPropertyChangedFor(nameof(LocationShortName))]
        [NotifyPropertyChangedFor(nameof(ListingPrice))]
        [NotifyPropertyChangedFor(nameof(PricePerTokenText))]
        [NotifyPropertyChangedFor(nameof(Apy))]
        [NotifyPropertyChangedFor(nameof(TokensAvailable))]
        [NotifyPropertyChangedFor(nameof(RentalIncome))]    
        private XcavateMetadata? metadata;

        [ObservableProperty]
        private NftMarketplaceDetails? nftMarketplaceDetails;

        public double AreaPricesPercentage => PropertyModel.GetAreaPricesPercentage(Metadata?.PropertyPrice ?? 0);
        public double RentalDemandPercentage => PropertyModel.GetRentalDemand();

        public string LocationShortName => $"{Metadata?.AddressStreet}, {Metadata?.AddressTownCity}";

        public string ListingPrice=> $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{
            String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * Metadata?.PropertyPrice)
            }";

        public string PricePerTokenText => $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{
            String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * Metadata?.PricePerToken)
            } [{String.Format("{0:0.00}", Metadata?.PricePerToken)} USDT]";

        public string Apy => PropertyModel.GetAPY(Metadata?.EstimatedRentalIncome ?? 1, Metadata?.PropertyPrice ?? 1);

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TokensAvailable))]
        private uint tokensListed;

        public string TokensAvailable => $"{NftMarketplaceDetails?.Listed.ToString() ?? "-"} / {Metadata?.NumberOfTokens.ToString() ?? "-"}";

        public string RentalIncome => $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{
            String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * Metadata?.EstimatedRentalIncome)
            }";

        [ObservableProperty]
        private string companyName = "Needs to be filled";
  
        [ObservableProperty]
        private string companyImage = "xcavate.png";

        [RelayCommand]
        public Task OpenMapAsync() => Task.FromResult(0); //Browser.Default.OpenAsync(<location url>, BrowserLaunchMode.SystemPreferred);

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
        }

        [ObservableProperty]
        private bool favourite = false;

        [RelayCommand]
        public void MakeFavourite()
        {
            Favourite = !Favourite;
        }

        [RelayCommand]
        public Task ShareAsync() => Share.RequestAsync(new ShareTextRequest
            {
                Uri = $"https://realxmarket.xcavate.io/marketplace/{NftMarketplaceDetails?.AssetId}",
                Title = $"Share {Metadata?.PropertyName}",
            });

    }
}
