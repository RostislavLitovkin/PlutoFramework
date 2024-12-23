namespace PlutoFramework.Components.CustomLayouts;

public partial class CustomLayoutItemDragger : ContentView
{
    public static readonly BindableProperty ItemNameProperty = BindableProperty.Create(
        nameof(ItemName), typeof(string), typeof(CustomLayoutItemDragger),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (CustomLayoutItemDragger)bindable;
            control.nameLabelText.Text = (string)newValue;
        });

    public static readonly BindableProperty ComponentIdProperty = BindableProperty.Create(
        nameof(ComponentId), typeof(string), typeof(CustomLayoutItemDragger),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {

        });

    public CustomLayoutItemDragger()
	{
		InitializeComponent();
	}

    public string ItemName
    {
        get => (string)GetValue(ItemNameProperty);

        set => SetValue(ItemNameProperty, value);
    }

    public string ComponentId
    {
        get => (string)GetValue(ComponentIdProperty);

        set => SetValue(ComponentIdProperty, value);
    }
}
