using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Nft;

public partial class NftMultiImageView : ContentView
{
    public static readonly BindableProperty ImageSourcesProperty = BindableProperty.Create(
        nameof(ImageSource), typeof(string[]), typeof(NftMultiImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftMultiImageView)bindable;


            var imageSources = (string[])newValue;

            if (imageSources == null || imageSources.Length == 0)
            {
                control.viewModel.MainImageSource = "noimage.png";
                return;
            }

            control.viewModel.MainImageSource = imageSources[0];

            control.viewModel.ImageSources = new ObservableCollection<string>(imageSources);
        });

    private NftMultiImageViewModel viewModel;
    public NftMultiImageView()
	{
		InitializeComponent();

        viewModel = new NftMultiImageViewModel();

        BindingContext = viewModel;
    }

    public string[] ImageSources
    {
        get => (string[])GetValue(ImageSourcesProperty);
        set => SetValue(ImageSourcesProperty, value);
    }

    private void OnImageClicked(object sender, TappedEventArgs e)
    {
        viewModel.MainImageSource = ((NftImageView)sender).ImageSource;
    }
}