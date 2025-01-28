namespace PlutoFramework.Components.Nft;

public partial class NftImageView : ContentView
{
    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        nameof(ImageSource), typeof(string), typeof(NftImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftImageView)bindable;

            control.image.Source = (string)newValue;

            if (((string)newValue).Length <= 4 || ((string)newValue)[0..4] != "http")
            {
                control.downloadButton.Opacity = 0.5;
            }
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

    public NftImageView(bool extraButtonsVisible)
    {
        InitializeComponent();

        extraButtonsBorder.IsVisible = extraButtonsVisible;
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
        if (downloadButton.Opacity == 0.5)
        {
            return;
        }
        
        await Browser.Default.OpenAsync(new Uri(ImageSource), BrowserLaunchMode.SystemPreferred);
    }
    private async void OnExpandClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new NftImageFullScreenPage(ImageSource));
    }
}
