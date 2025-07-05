using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Buttons;

namespace PlutoFramework.Components.Xcavate;

public partial class PageBottomBarButtonView : ContentView
{
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command), typeof(IRelayCommand), typeof(PageBottomBarButtonView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PageBottomBarButtonView)bindable;

            control.button.Command = (IRelayCommand)newValue;
        });

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(PageBottomBarButtonView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PageBottomBarButtonView)bindable;
            control.button.Text = (string)newValue;
        });

    public static readonly BindableProperty ButtonStateProperty = BindableProperty.Create(
        nameof(ButtonState), typeof(ButtonStateEnum), typeof(PageBottomBarButtonView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (PageBottomBarButtonView)bindable;
            control.button.ButtonState = (ButtonStateEnum)newValue;
        });
    public PageBottomBarButtonView()
	{
		InitializeComponent();
	}

    public IRelayCommand Command
    {
        get => (IRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public ButtonStateEnum ButtonState
    {
        get => (ButtonStateEnum)GetValue(ButtonStateProperty);
        set => SetValue(ButtonStateProperty, value);
    }
}