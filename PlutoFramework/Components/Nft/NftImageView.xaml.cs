namespace PlutoFramework.Components.Nft;

#pragma warning disable CA1416 // Validate platform compatibility

public partial class NftImageView : ContentView
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        nameof(ImageSource), typeof(string), typeof(NftImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftImageView)bindable;

            control.image.Source = (string)newValue;
        });

    public static readonly BindableProperty ExtraButtonsVisibleProperty = BindableProperty.Create(
        nameof(ExtraButtonsVisible), typeof(bool), typeof(NftImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftImageView)bindable;

            control.extraButtonsBorder.IsVisible = (bool)newValue;
        });
    public NftImageView()
	{
		InitializeComponent();
	}
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public bool ExtraButtonsVisible
    {
        get => (bool)GetValue(ExtraButtonsVisibleProperty);
        set => SetValue(ExtraButtonsVisibleProperty, value);
    }
    private async void OnDownloadClicked(object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(new Uri(ImageSource), BrowserLaunchMode.SystemPreferred);
        //await FileModel.SaveImageAsync(ImageSource, "nft.png");
    }
    private async void OnExpandClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new NftImageFullScreenPage(ImageSource));
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
