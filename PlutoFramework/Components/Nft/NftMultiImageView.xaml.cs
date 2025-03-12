using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Nft;

public partial class NftMultiImageView : ContentView
{
    public static readonly BindableProperty ImageSourcesProperty = BindableProperty.Create(
        nameof(ImageSources), typeof(List<string>), typeof(NftMultiImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (NftMultiImageView)bindable;

            Console.WriteLine("Images received");

            var imageSources = (List<string>)newValue;

            if (imageSources == null || imageSources.Count() == 0)
            {
                Console.WriteLine("Null");

                control.mainImage.ImageSource = "noimage.png";
                return;
            }

            control.mainImage.ImageSource = imageSources[0];


            foreach(string imageSource in imageSources)
            {
                NftImageView imageView = new NftImageView(false)
                {
                    ImageSource = imageSource,
                    HeightRequest = 60,
                    WidthRequest = 60,
                };

                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    control.mainImage.ImageSource = ((NftImageView)s).ImageSource;
                };

                imageView.GestureRecognizers.Add(tapGestureRecognizer);

                control.imagesStackLayout.Children.Add(imageView);
            }
        });
    public NftMultiImageView()
	{
		InitializeComponent();
    }

    public List<string> ImageSources
    {
        get => (List<string>)GetValue(ImageSourcesProperty);
        set => SetValue(ImageSourcesProperty, value);
    }
}