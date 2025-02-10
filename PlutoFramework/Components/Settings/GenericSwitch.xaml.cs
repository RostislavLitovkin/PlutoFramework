using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace PlutoFramework.Components.Settings;

public partial class GenericSwitch : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(GenericSwitch),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (GenericSwitch)bindable;
            control.nameLabelText.Text = (string)newValue;
        });

    public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(
        nameof(IsToggled), typeof(bool), typeof(GenericSwitch),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (GenericSwitch)bindable;
            control.thisSwitch.IsToggled = (bool)newValue;
        });

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command), typeof(IRelayCommand), typeof(GenericSwitch),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (GenericSwitch)bindable;

            control.thisSwitch.Toggled += (sender, e) =>
            {
                ((IRelayCommand)newValue).Execute(null);
            };
        });

    public GenericSwitch()
	{
		InitializeComponent();
	}

    public string Title
    {
        get => (string)GetValue(TitleProperty);

        set => SetValue(TitleProperty, value);
    }

    public bool IsToggled
    {
        get => (bool) GetValue(IsToggledProperty);
        set => SetValue(IsToggledProperty, value);
    }

    public IRelayCommand Command
    {
        get => (IRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
}