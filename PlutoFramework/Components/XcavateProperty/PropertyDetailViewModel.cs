using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model.XCavate;

namespace PlutoFramework.Components.XcavateProperty
{
    public partial class PropertyDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private string propertyName;

        [ObservableProperty]
        private List<string> images;

        [ObservableProperty]
        private string companyName;
  
        [ObservableProperty]
        private string companyImage;

        [ObservableProperty]
        private string locationName;

        [ObservableProperty]
        private string locationUrl;

        [ObservableProperty]
        private string listingPrice;

        [ObservableProperty]
        private string apy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TokensAvailable))]
        private uint? tokens;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TokensAvailable))]
        private uint maxTokens;

        public string TokensAvailable => $"{Tokens?.ToString() ?? "-"} / {MaxTokens}";

        [ObservableProperty]
        private string propertyDescription;

        [ObservableProperty]
        private string propertyType;

        [RelayCommand]
        public Task OpenMapAsync() => Browser.Default.OpenAsync(LocationUrl, BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public void Buy()
        {

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
                Uri = "https://xcavate.io/",
                Title = $"Share {PropertyName}",
            });
        

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PricePerTokenText))]
        private double usdtPricePerToken;

        public string PricePerTokenText => $"£{String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", "£") * UsdtPricePerToken)} ~ {String.Format("{0:0.00}", UsdtPricePerToken)} USDT";

        [ObservableProperty]
        private double areaPricesPercentage;

        [ObservableProperty]
        private double rentalDemandPercentage;

        [ObservableProperty]
        private string blocks;

        [ObservableProperty]
        private string bedrooms;

        [ObservableProperty]
        private string bathrooms;

        [ObservableProperty]
        private string type;

        [ObservableProperty]
        private string locationShortName;

        [ObservableProperty]
        private string rentalIncome;
    }
}
