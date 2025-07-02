
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Xcavate;

public partial class XcavateCell : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(XcavateCell),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (XcavateCell)bindable;

            control.titleText.Text = ((string)newValue);
        });

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        nameof(Value), typeof(string), typeof(XcavateCell),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (XcavateCell)bindable;

            // Run on main thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                control.valueText.Text = (string)newValue;
            });
        });


    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command), typeof(IAsyncRelayCommand), typeof(XcavateCell),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (XcavateCell)bindable;

            control.tapGestureRecognizer.Command = (IAsyncRelayCommand)newValue;

            control.arrow.IsVisible = newValue != null;
        });

    public XcavateCell()
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

    public IAsyncRelayCommand Command
    {
        get => (IAsyncRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
}