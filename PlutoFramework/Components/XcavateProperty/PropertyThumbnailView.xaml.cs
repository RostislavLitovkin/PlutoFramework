using PlutoFramework.Components.Loading;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.SQLite;
using UniqueryPlus.Nfts;
using PropertyModel = PlutoFramework.Model.Xcavate.XcavatePropertyModel;

namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyThumbnailView : ContentView
{
    public static readonly BindableProperty NftBaseProperty = BindableProperty.Create(
        nameof(NftBase), typeof(INftBase), typeof(PropertyThumbnailView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyThumbnailView)bindable;

            if (newValue is not INftXcavateBase)
            {
                return;
            }

            var nftBase = (INftXcavateBase)newValue;

            if (nftBase.XcavateMetadata is null)
            {
                return;
            }

            control.propertyNameLabel.Text = nftBase.XcavateMetadata.PropertyName;

            control.apyLabel.Text = PropertyModel.GetAPY(nftBase.XcavateMetadata.EstimatedRentalIncome, nftBase.XcavateMetadata.PropertyPrice);

            if (control.TokensOwned == 0)
            {
                if (nftBase is INftXcavateNftMarketplace)
                {
                    control.tokensLabel.Text = ((INftXcavateNftMarketplace)nftBase).NftMarketplaceDetails?.Listed?.ToString() ?? "-";
                }
                else
                {
                    control.tokensLabel.Text = "-";
                }
            }
            else
            {
                control.tokensLabel.Text = $"{control.TokensOwned} / {nftBase.XcavateMetadata.NumberOfTokens}";
            }

            var currencySymbol = ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location);
            var propertyPriceLocalized = ExchangeRateModel.GetExchangeRate("USDT", currencySymbol) * nftBase.XcavateMetadata.PropertyPrice;

            control.priceLabelText.Text = $"{currencySymbol}{propertyPriceLocalized}";

            control.locationView.LocationName = nftBase.XcavateMetadata.LocationName;

            control.image.Source = (nftBase.XcavateMetadata is not null && nftBase.XcavateMetadata.Images.Count() > 0) switch
            {
                // Default image
                false => "noimage.png",
                true => nftBase.XcavateMetadata?.Images[0][0..4] switch
                {
                    "http" => new UriImageSource
                    {
                        Uri = new Uri(nftBase.XcavateMetadata?.Images[0]),
                        CacheValidity = new TimeSpan(1, 0, 0),
                    },
                    _ => nftBase.XcavateMetadata?.Images[0]
                },
            };
        });

    public static readonly BindableProperty FavouriteProperty = BindableProperty.Create(
        nameof(Favourite), typeof(bool), typeof(PropertyThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyThumbnailView)bindable;

            control.filledFavouriteIcon.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty TokensOwnedProperty = BindableProperty.Create(
        nameof(TokensOwned), typeof(uint), typeof(PropertyThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyThumbnailView)bindable;

            control.tokensTitleLabel.Text = "Tokens owned";

            var tokensOwned = (uint)newValue;

            if (control.NftBase is not null && ((XcavatePaseoNftsPalletNft)control.NftBase)?.XcavateMetadata is not null)
            {
                control.tokensLabel.Text = $"{tokensOwned} / {((XcavatePaseoNftsPalletNft)control.NftBase).XcavateMetadata?.NumberOfTokens}";
            }
            else
            {
                control.tokensLabel.Text = $"{tokensOwned}";
            }
        });

    public static readonly BindableProperty EndpointProperty = BindableProperty.Create(
        nameof(Endpoint), typeof(Endpoint), typeof(PropertyThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
        });


    public PropertyThumbnailView()
    {
        InitializeComponent();
    }
    public INftBase NftBase
    {
        get => (INftBase)GetValue(NftBaseProperty);
        set => SetValue(NftBaseProperty, value);
    }

    public uint TokensOwned
    {
        get => (uint)GetValue(TokensOwnedProperty);
        set => SetValue(TokensOwnedProperty, value);
    }

    public bool Favourite
    {
        get => (bool)GetValue(FavouriteProperty);

        set => SetValue(FavouriteProperty, value);
    }

    public Endpoint Endpoint
    {
        get => (Endpoint)GetValue(EndpointProperty);

        set => SetValue(EndpointProperty, value);
    }

    void OnFavouriteClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Favourite = !Favourite;

        Task save = XcavatePropertyDatabase.SavePropertyAsync(new NftWrapper
        {
            Endpoint = Endpoint,
            NftBase = NftBase,
            Favourite = Favourite
        });

        UpdateFavouritePropertiesModel.UpdateFavourite(NftBase as INftXcavateBase, Favourite);
    }

    async void OnMoreClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var loadingViewModel = DependencyService.Get<FullPageLoadingViewModel>();

        loadingViewModel.IsVisible = true;

        await XcavatePropertyModel.NavigateToPropertyDetailPageAsync(new NftWrapper
        {
            NftBase = NftBase,
            Endpoint = Endpoint,
            Favourite = Favourite
        }, CancellationToken.None);

        loadingViewModel.IsVisible = false;
    }
}