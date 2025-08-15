using PlutoFramework.Model.Xcavate;
using UniqueryPlus.Metadata;

namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyLittleThumbnailView : ContentView
{
	public static readonly BindableProperty XcavateMetadataProperty = BindableProperty.Create(
        nameof(XcavateMetadata), typeof(PropertyMetadata), typeof(PropertyLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyLittleThumbnailView)bindable;

            var metadata = (PropertyMetadata?)newValue;

            if (metadata == null)
            {
                return;
            }

            control.nameLabelText.Text = metadata.PropertyName;
            control.locationView.LocationName = $"{metadata.AddressStreet}, {metadata.AddressTownCity}";

            var images = metadata.Images;

            if (images.Count() > 0)
            {
                control.image.Source = images[0];
            }
        });

    public static readonly BindableProperty AmountProperty = BindableProperty.Create(
        nameof(Amount), typeof(uint), typeof(PropertyLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyLittleThumbnailView)bindable;

            if (newValue is null)
            {
                return;
            }

            Grid.SetColumnSpan(control.infoLayout, 1);

            var amount = (uint)newValue;

            var s = (amount > 1) ? "s" : "";
            control.amountLabel.Text = $"{amount} token{s}";
        });

    public static readonly BindableProperty OperationProperty = BindableProperty.Create(
        nameof(Operation), typeof(XcavatePropertyOperation), typeof(PropertyLittleThumbnailView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PropertyLittleThumbnailView)bindable;

            control.operationLabel.Text = (XcavatePropertyOperation)newValue switch
            {
                XcavatePropertyOperation.Buy => "Buy",
                _ => ((XcavatePropertyOperation)newValue).ToString(),
            };
        });

    public PropertyLittleThumbnailView()
	{
		InitializeComponent();
	}

	public PropertyMetadata? XcavateMetadata
	{
		get => (PropertyMetadata?)GetValue(XcavateMetadataProperty);
        set => SetValue(XcavateMetadataProperty, value);
    }

    public XcavatePropertyOperation Operation
    {
        get => (XcavatePropertyOperation)GetValue(OperationProperty);
        set => SetValue(OperationProperty, value);
    }

    public uint Amount
    {
        get => (uint)GetValue(AmountProperty);
        set => SetValue(AmountProperty, value);
    }
}
