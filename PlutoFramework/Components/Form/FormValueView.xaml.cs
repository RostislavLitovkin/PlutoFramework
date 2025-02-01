namespace PlutoFramework.Components.Form;

public partial class FormValueView : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(FormValueView),
        string.Empty, BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (FormValueView)bindable;
        control.titleLabel.Text = (string)newValue;
    });

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value), typeof(string), typeof(FormValueView),
        string.Empty, BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
    {
        var control = (FormValueView)bindable;
        control.valueLabel.Text = (string)newValue;
    });
    public FormValueView()
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