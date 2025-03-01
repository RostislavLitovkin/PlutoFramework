using PlutoFramework.Components.XcavateProperty;

namespace PlutoFramework.Components.Nft;

public partial class NftModifyMultiImageView : ContentView
{
    public static BindableProperty ImageSourcesProperty = BindableProperty.Create(
        nameof(ImageSources), typeof(List<ImageSourceWithName>), typeof(NftModifyMultiImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftModifyMultiImageView)bindable;

            Console.WriteLine("Images received");

            if (control.imagesStackLayout.Children.Count() > 0)
            {
                control.imagesStackLayout.Children.Clear();
            }

            var imageSources = (List<ImageSourceWithName>)newValue;

            if (imageSources.Count() == 0)
            {
                control.mainImage.ImageSourceWithName = null;
            }
            else
            {
                control.mainImage.ImageSourceWithName = imageSources[0];
            }

            foreach (var imageSource in imageSources)
            {
                NftModifyImageView imageView = new NftModifyImageView
                {
                    ImageSourceWithName = imageSource,
                    HeightRequest = 60,
                    WidthRequest = 60,
                    CanBeRemoved = true,
                };

                control.imagesStackLayout.Children.Add(imageView);
            }

            // Last add button
            NftModifyImageView addImageView = new NftModifyImageView
            {
                ImageSourceWithName = null,
                HeightRequest = 60,
                WidthRequest = 60,
            };

            control.imagesStackLayout.Children.Add(addImageView);
        });
    public NftModifyMultiImageView()
    {
        InitializeComponent();
    }

    public List<ImageSourceWithName> ImageSources
    {
        get => (List<ImageSourceWithName>)GetValue(ImageSourcesProperty);
        set => SetValue(ImageSourcesProperty, value);
    }
}