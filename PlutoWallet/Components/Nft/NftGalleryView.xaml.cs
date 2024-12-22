using PlutoWallet.Model;
using System.Collections.ObjectModel;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);

namespace PlutoWallet.Components.Nft;

public partial class NftGalleryView : ContentView
{
    private static Dictionary<NftKey, NftWrapper> nftsDict = new Dictionary<NftKey, NftWrapper>();

    public static readonly BindableProperty NftsProperty = BindableProperty.Create(
        nameof(Nfts), typeof(ObservableCollection<NftWrapper>), typeof(NftGalleryView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftGalleryView)bindable;

            BindableLayout.SetItemsSource(control.horizontalStackLayout, (ObservableCollection<NftWrapper>)newValue);
        });

    public static readonly BindableProperty PlusIsVisibleProperty = BindableProperty.Create(
       nameof(PlusIsVisible), typeof(bool), typeof(NftGalleryView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var control = (NftGalleryView)bindable;

           control.plusButton.IsVisible = (bool)newValue;
       });

    public static readonly BindableProperty LoadingIsVisibleProperty = BindableProperty.Create(
       nameof(LoadingIsVisible), typeof(bool), typeof(NftGalleryView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var control = (NftGalleryView)bindable;

           control.loadingItem.IsVisible = (bool)newValue;
       });

    public static readonly BindableProperty ErrorIsVisibleProperty = BindableProperty.Create(
      nameof(ErrorIsVisible), typeof(bool), typeof(NftGalleryView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (NftGalleryView)bindable;

          control.errorItem.IsVisible = (bool)newValue;
      });

    public static readonly BindableProperty NoNftsIsVisibleProperty = BindableProperty.Create(
      nameof(NoNftsIsVisible), typeof(bool), typeof(NftGalleryView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (NftGalleryView)bindable;

          control.noNftsItem.IsVisible = (bool)newValue;
      });

    public static readonly BindableProperty NoNftsTextProperty = BindableProperty.Create(
      nameof(NoNftsText), typeof(string), typeof(NftGalleryView),
      defaultBindingMode: BindingMode.TwoWay,
      propertyChanging: (bindable, oldValue, newValue) =>
      {
          var control = (NftGalleryView)bindable;

          control.noNftsItem.Text = (string)newValue;
      });
    public NftGalleryView()
    {
        InitializeComponent();
    }
    public ObservableCollection<NftWrapper> Nfts
    {
        get => (ObservableCollection<NftWrapper>)GetValue(NftsProperty);
        set => SetValue(NftsProperty, value);
    }

    public bool PlusIsVisible
    {
        get => (bool)GetValue(PlusIsVisibleProperty);
        set => SetValue(PlusIsVisibleProperty, value);
    }

    public bool LoadingIsVisible
    {
        get => (bool)GetValue(LoadingIsVisibleProperty);
        set => SetValue(LoadingIsVisibleProperty, value);
    }

    public bool ErrorIsVisible
    {
        get => (bool)GetValue(ErrorIsVisibleProperty);
        set => SetValue(ErrorIsVisibleProperty, value);
    }
    public bool NoNftsIsVisible
    {
        get => (bool)GetValue(NoNftsIsVisibleProperty);
        set => SetValue(NoNftsIsVisibleProperty, value);
    }
    public string NoNftsText
    {
        get => (string)GetValue(NoNftsTextProperty);
        set => SetValue(NoNftsTextProperty, value);
    }
    void OnPlusClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {

    }
}
