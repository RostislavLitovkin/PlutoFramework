using PlutoFramework.Constants;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyThumbnailView : ContentView
{
    public static readonly BindableProperty NftBaseProperty = BindableProperty.Create(
        nameof(NftBase), typeof(INftBase), typeof(PropertyThumbnailView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyThumbnailView)bindable;

            if (newValue is not XCavatePaseoNftsPalletNft)
            {
                return;
            }


            var nftBase = (XCavatePaseoNftsPalletNft)newValue;
            
            if (nftBase.XCavateMetadata is null)
            {
                return;
            }

            control.propertyNameLabel.Text = nftBase.XCavateMetadata.PropertyName;

            control.apyLabel.Text = XCavatePropertyModel.GetAPY(nftBase.XCavateMetadata.EstimatedRentalIncome, nftBase.XCavateMetadata.PropertyPrice);

            control.tokensLabel.Text = nftBase.NftMarketplaceDetails?.Listed?.ToString() ?? "-";

            control.priceLabel.Text = $"£{nftBase.XCavateMetadata.PropertyPrice}";

            control.locationView.LocationName = nftBase.XCavateMetadata.LocationName;

            control.image.Source = (nftBase.XCavateMetadata is not null && nftBase.XCavateMetadata.Images.Count() > 0) switch
            {
                // Default image
                false => "noimage.png",
                true => nftBase.XCavateMetadata?.Images[0][0..4] switch
                {
                    "http" => new UriImageSource
                    {
                        Uri = new Uri(nftBase.XCavateMetadata?.Images[0]),
                        CacheValidity = new TimeSpan(1, 0, 0),
                    },
                    _ => nftBase.XCavateMetadata?.Images[0]
                },
            };

            Console.WriteLine("Done loading XCavate property");
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
        await XCavatePropertyModel.NavigateToPropertyDetailPageAsync((XCavatePaseoNftsPalletNft)NftBase, CancellationToken.None);
    }
}