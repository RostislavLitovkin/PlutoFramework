namespace PlutoFramework.Components.Nft;

public partial class NftAttributeView : ContentView
{
    public static readonly BindableProperty AttributeNameProperty = BindableProperty.Create(
        nameof(AttributeName), typeof(string), typeof(NftAttributeView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftAttributeView)bindable;

            control.attributeNameLabel.Text = (string)newValue;
        });

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value), typeof(string), typeof(NftAttributeView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftAttributeView)bindable;

            control.attributeValueLabel.Text = (string)newValue;
        });

    public static readonly BindableProperty CardBackgroundColorProperty = BindableProperty.Create(
        nameof(CardBackgroundColor), typeof(Color), typeof(NftAttributeView),
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (NftAttributeView)bindable;

            control.border.BackgroundColor = (Color)newValue;
        });
    public NftAttributeView()
    {
        InitializeComponent();
    }

    public Color CardBackgroundColor
    {
        get => (Color)GetValue(CardBackgroundColorProperty);
        set => SetValue(CardBackgroundColorProperty, value);
    }

    public string AttributeName
    {
        get => (string)GetValue(AttributeNameProperty);
        set => SetValue(AttributeNameProperty, value);
    }

    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}