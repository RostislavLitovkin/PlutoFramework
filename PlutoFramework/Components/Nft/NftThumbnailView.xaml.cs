using Markdig;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using UniqueryPlus.Nfts;
using PlutoFramework.Model.SQLite;

namespace PlutoFramework.Components.Nft;

public partial class NftThumbnailView : ContentView
{
    public static readonly BindableProperty NftBaseProperty = BindableProperty.Create(
        nameof(NftBase), typeof(INftBase), typeof(NftThumbnailView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftThumbnailView)bindable;

            if (newValue is null)
            {
                return;
            }

            var nftBase = (INftBase)newValue;

            control.nameLabelText.Text = nftBase.Metadata?.Name ?? "Unknown";
            control.descriptionLabel.Text = Markdown.ToHtml(nftBase.Metadata?.Description ?? "No description");
            control.image.Source = nftBase.Metadata?.Image[0..4] switch
            {
                // Default image
                null => "noimage.png",
                "http" => new UriImageSource
                {
                    Uri = new Uri(nftBase.Metadata.Image),
                    CacheValidity = new TimeSpan(1,0,0),
                },
                _ => nftBase.Metadata.Image
            };

            if (nftBase is INftXcavateMetadata)
            {
                control.priceAttribute.Value = $"£{((INftXcavateMetadata)nftBase).XcavateMetadata?.PropertyPrice}";

                // Set Xcavate apy

                control.apyAttribute.Value = "10.0%";

                control.xcavateAttributes.IsVisible = true;
            }

            // TODO: nftBase.Metadata?.Attributes ?? [];
        });

    public static readonly BindableProperty FavouriteProperty = BindableProperty.Create(
        nameof(Favourite), typeof(bool), typeof(NftThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftThumbnailView)bindable;

            control.filledFavouriteIcon.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty EndpointProperty = BindableProperty.Create(
        nameof(Endpoint), typeof(Endpoint), typeof(NftThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            if (newValue is null)
            {
                return;
            }
            var control = (NftThumbnailView)bindable;

            control.networkBubble.Name = ((Endpoint)newValue).Name;
            control.networkBubble.EndpointKey = ((Endpoint)newValue).Key;
        });

    public NftThumbnailView()
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
        Task save = NftDatabase.SaveItemAsync(new NftWrapper
        {
            Endpoint = Endpoint,
            NftBase = NftBase,
            Favourite = Favourite
        });
    }
    async void OnMoreClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await NftModel.NavigateToNftDetailPageAsync(NftBase, Endpoint, Favourite, CancellationToken.None);
    }
}
