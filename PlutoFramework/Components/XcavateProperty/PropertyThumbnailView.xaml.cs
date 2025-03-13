using PlutoFramework.Constants;
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

            if (newValue is not XcavatePaseoNftsPalletNft)
            {
                return;
            }


            var nftBase = (XcavatePaseoNftsPalletNft)newValue;
            
            if (nftBase.XcavateMetadata is null)
            {
                return;
            }

            control.propertyNameLabel.Text = nftBase.XcavateMetadata.PropertyName;

            control.apyLabel.Text = PropertyModel.GetAPY(nftBase.XcavateMetadata.EstimatedRentalIncome, nftBase.XcavateMetadata.PropertyPrice);

            control.tokensLabel.Text = nftBase.NftMarketplaceDetails?.Listed?.ToString() ?? "-";

            control.priceLabel.Text = $"£{nftBase.XcavateMetadata.PropertyPrice}";

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

    public static readonly BindableProperty EndpointProperty = BindableProperty.Create(
        nameof(Endpoint), typeof(Endpoint), typeof(PropertyThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyThumbnailView)bindable;
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
        /*Task save = NftDatabase.SaveItemAsync(new NftWrapper
        {
            Endpoint = Endpoint,
            NftBase = NftBase,
            Favourite = Favourite
        });*/
    }

    async void OnMoreClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await XcavatePropertyModel.NavigateToPropertyDetailPageAsync((XcavatePaseoNftsPalletNft)NftBase, CancellationToken.None);
    }
}