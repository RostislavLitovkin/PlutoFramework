using PlutoFramework.Components.XcavateProperty;

namespace PlutoFramework.Components.Nft;

public partial class NftModifyImageView : ContentView
{
	public static readonly BindableProperty ImageSourceWithNameProperty = BindableProperty.Create(
        nameof(ImageSourceWithName), typeof(ImageSourceWithName), typeof(NftModifyImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftModifyImageView)bindable;

            var imageSourceWithName = (ImageSourceWithName?)newValue;

            if (imageSourceWithName == null)
            {
                control.image.IsVisible = false;
                control.addImageView.IsVisible = true;
                return;
            }

            control.image.IsVisible = true;
            control.addImageView.IsVisible = false;
            control.image.Source = imageSourceWithName.ImageSource;
        });

    public static readonly BindableProperty CanBeRemovedProperty = BindableProperty.Create(
        nameof(CanBeRemoved), typeof(bool), typeof(NftModifyImageView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftModifyImageView)bindable;

            control.removeImageView.IsVisible = (bool)newValue;
        });
    public NftModifyImageView()
	{
		InitializeComponent();
	}

    public ImageSourceWithName? ImageSourceWithName
    {
        get => (ImageSourceWithName?)GetValue(ImageSourceWithNameProperty);
        set => SetValue(ImageSourceWithNameProperty, value);
    }
    public bool CanBeRemoved
    {
        get => (bool)GetValue(CanBeRemovedProperty);
        set => SetValue(CanBeRemovedProperty, value);
    }
}