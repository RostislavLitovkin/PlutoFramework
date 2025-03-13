using UniqueryPlus.Metadata;

namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyLittleThumbnailView : ContentView
{
	public static readonly BindableProperty XcavateMetadataProperty = BindableProperty.Create(
        nameof(XcavateMetadata), typeof(XcavateMetadata), typeof(PropertyLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyLittleThumbnailView)bindable;

            var metadata = (XcavateMetadata?)newValue;

            if (metadata == null)
            {
                return;
            }

            control.nameLabelText.Text = metadata.PropertyName;
            control.locationView.LocationName = metadata.LocationName;

            if (metadata.Images.Count > 0)
            {
                control.image.Source = metadata.Images[0];
            }

        });
    public PropertyLittleThumbnailView()
	{
		InitializeComponent();
	}

	public XcavateMetadata? XcavateMetadata
	{
		get => (XcavateMetadata?)GetValue(XcavateMetadataProperty);
        set => SetValue(XcavateMetadataProperty, value);
    }
}