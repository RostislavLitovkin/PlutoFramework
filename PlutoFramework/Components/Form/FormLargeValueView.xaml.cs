namespace PlutoFramework.Components.Form;

public partial class FormLargeValueView : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
    nameof(Title), typeof(string), typeof(FormLargeValueView),
    string.Empty, BindingMode.OneWay,
    propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (FormLargeValueView)bindable;
        control.titleLabel.Text = (string)newValue;
    });

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value), typeof(string), typeof(FormLargeValueView),
        string.Empty, BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormLargeValueView)bindable;
            control.valueLabel.Text = (string)newValue;
        });
    public FormLargeValueView()
	{
		InitializeComponent();
	}

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}