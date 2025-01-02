using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.TransactionAnalyzer;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.SQLite;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.Nft;

public partial class NftLittleThumbnailView : ContentView
{
    public static readonly BindableProperty NftBaseProperty = BindableProperty.Create(
        nameof(NftBase), typeof(INftBase), typeof(NftLittleThumbnailView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftLittleThumbnailView)bindable;

            var nftBase = (INftBase)newValue;

            control.nftIdView.Id = nftBase.Id;

            control.nameLabelText.Text = nftBase.Metadata?.Name ?? "Unknown";
            control.image.Source = nftBase.Metadata?.Image[0..4] switch
            {
                // Default image
                null => "noimage.png",
                "http" => new UriImageSource
                {
                    Uri = new Uri(nftBase.Metadata.Image),
                    CacheValidity = new TimeSpan(1, 0, 0),
                },
                _ => nftBase.Metadata.Image
            };

            control.cardTapGestureRecognizer.CommandParameter = nftBase;

            // TODO: nftBase.Metadata?.Attributes ?? [];
        });

    public static readonly BindableProperty FavouriteProperty = BindableProperty.Create(
        nameof(Favourite), typeof(bool), typeof(NftLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftLittleThumbnailView)bindable;

            control.filledFavouriteIcon.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
        nameof(IsSelected), typeof(bool), typeof(NftLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftLittleThumbnailView)bindable;

            if ((bool)newValue)
            {
                control.card.Color = Color.FromArgb("#7aff7a");
            }
            else
            {
                control.card.SetDefaultColor();
            }
        });

    public static readonly BindableProperty SelectCommandProperty = BindableProperty.Create(
       nameof(SelectCommand), typeof(IAsyncRelayCommand<INftBase>), typeof(NftLittleThumbnailView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           Console.WriteLine("Console command set");

           var control = (NftLittleThumbnailView)bindable;

           if (control.moreLabel.GestureRecognizers.Count > 0)
           {
               control.moreLabel.GestureRecognizers.Clear();
           }

           if (control.card.GestureRecognizers.Count > 0)
           {
               control.card.GestureRecognizers.Clear();
           }

           control.cardTapGestureRecognizer.Command = (IAsyncRelayCommand<INftBase>)newValue;

           control.card.SetAppThemeColor(Label.BackgroundColorProperty, Color.FromArgb("#fdfdfd"), Color.FromArgb("#0a0a0a"));

           Console.WriteLine("Console command set done");

       });

    public static readonly BindableProperty EndpointProperty = BindableProperty.Create(
        nameof(Endpoint), typeof(Endpoint), typeof(NftLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftLittleThumbnailView)bindable;

            control.networkBubble.Name = ((Endpoint)newValue).Name;
            control.networkBubble.EndpointKey = ((Endpoint)newValue).Key;
        });

    public static readonly BindableProperty PriceProperty = BindableProperty.Create(
        nameof(Price), typeof(AssetInfoExpanded), typeof(NftLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftLittleThumbnailView)bindable;

            if (newValue is null)
            {
                return;
            }

            Grid.SetColumnSpan(control.nftInfoLayout, 1);

            var price = (AssetInfoExpanded)newValue;

            control.usdLabel.Text = price.UsdValue;
            control.usdLabel.TextColor = price.UsdColor;
        });

    public static readonly BindableProperty OperationProperty = BindableProperty.Create(
        nameof(Operation), typeof(NftOperation), typeof(NftLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftLittleThumbnailView)bindable;

            control.operationLabel.Text = (NftOperation)newValue switch
            {
                NftOperation.Received => "Received",
                NftOperation.Sent => "Sent",
                _ => "",
            };
        });
    public NftLittleThumbnailView()
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

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);

        set => SetValue(IsSelectedProperty, value);
    }
    public Endpoint Endpoint
    {
        get => (Endpoint)GetValue(EndpointProperty);

        set => SetValue(EndpointProperty, value);
    }

    public AssetInfoExpanded Price
    {
        get => (AssetInfoExpanded)GetValue(PriceProperty);

        set => SetValue(PriceProperty, value);
    }

    public NftOperation Operation
    {
        get => (NftOperation)GetValue(OperationProperty);

        set => SetValue(OperationProperty, value);
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

    public bool IsSelectable { get; set; } = false;

    public IAsyncRelayCommand<INftBase> SelectCommand
    {
        get => (IAsyncRelayCommand<INftBase>)GetValue(SelectCommandProperty);
        set => SetValue(SelectCommandProperty, value);
    }
    async void OnMoreClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await NftModel.NavigateToNftDetailPageAsync(NftBase, Endpoint, Favourite, CancellationToken.None);
    }
}