using PlutoFramework.Model;

namespace PlutoFramework.Components.CustomLayouts;

public partial class CustomLayoutItemAddView : ContentView
{
    public static readonly BindableProperty ItemNameProperty = BindableProperty.Create(
        nameof(ItemName), typeof(string), typeof(CustomLayoutItemAddView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (CustomLayoutItemAddView)bindable;
            control.nameLabelText.Text = (string)newValue;
        });

    public static readonly BindableProperty ComponentIdProperty = BindableProperty.Create(
        nameof(ComponentId), typeof(ComponentId), typeof(CustomLayoutItemAddView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {

        });

    public CustomLayoutItemAddView()
	{
		InitializeComponent();
	}

    public string ItemName
    {
        get => (string)GetValue(ItemNameProperty);

        set => SetValue(ItemNameProperty, value);
    }

    public ComponentId ComponentId
    {
        get => (ComponentId)GetValue(ComponentIdProperty);

        set => SetValue(ComponentIdProperty, value);
    }

}
