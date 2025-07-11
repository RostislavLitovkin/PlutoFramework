using System.Collections.ObjectModel;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using UniqueryPlus.Collections;
using UniqueryPlus.External;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.Nft;

public partial class NftPictureView : ContentView
{
    public static readonly BindableProperty NftBaseProperty = BindableProperty.Create(
        nameof(NftBase), typeof(INftBase), typeof(NftPictureView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftPictureView)bindable;

            if (newValue is null)
            {
                return;
            }

            var nftBase = (INftBase)newValue;

            if (nftBase.Metadata?.Image is null)
            {
                return;
            }

            control.image.Source = nftBase.Metadata.Image;
        });

    public static readonly BindableProperty FavouriteProperty = BindableProperty.Create(
        nameof(Favourite), typeof(bool), typeof(NftPictureView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftPictureView)bindable;

            //control.filledFavouriteIcon.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty EndpointProperty = BindableProperty.Create(
        nameof(Endpoint), typeof(Endpoint), typeof(NftPictureView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {

        });

    public NftPictureView()
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
        await Model.NftModel.NavigateToNftDetailPageAsync(NftBase, Endpoint, Favourite, CancellationToken.None);
    }
}
