namespace PlutoFramework.Components.Buttons;

public partial class BasicGrayButton : Button
{
    public static readonly BindableProperty ButtonStateProperty = BindableProperty.Create(
        nameof(ButtonState), typeof(ButtonStateEnum), typeof(BasicGrayButton),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (BasicGrayButton)bindable;

            switch ((ButtonStateEnum)newValue)
            {
                case ButtonStateEnum.Enabled:
                    control.BackgroundColor = (Color)Application.Current.Resources["GrayButtonBackground"];

                    control.TextColor = (Color)Application.Current.Resources["GrayButtonText"];
                    control.BorderColor = (Color)Application.Current.Resources["GrayButtonBorder"];

                    control.IsEnabled = true;
                    break;
                case ButtonStateEnum.Disabled:
                    control.BackgroundColor = (Color)Application.Current.Resources["GrayButtonDisabledBackground"];

                    control.TextColor = (Color)Application.Current.Resources["GrayButtonDisabledText"];
                    control.BorderColor = (Color)Application.Current.Resources["GrayButtonDisabledBorder"];

                    control.IsEnabled = false;
                    break;
                case ButtonStateEnum.Warning:
                    control.BackgroundColor = (Color)Application.Current.Resources["GrayButtonWarningBackground"];

                    control.TextColor = (Color)Application.Current.Resources["GrayButtonWarningText"];
                    control.BorderColor = (Color)Application.Current.Resources["GrayButtonWarningBorder"];

                    control.IsEnabled = true;
                    break;
                case ButtonStateEnum.Invisible:
                    control.IsVisible = false;
                    break;
            }
        },
        defaultValue: ButtonStateEnum.Enabled);

    public BasicGrayButton()
	{
		InitializeComponent();
	}

    public ButtonStateEnum ButtonState
    {
        get => (ButtonStateEnum)GetValue(ButtonStateProperty);
        set => SetValue(ButtonStateProperty, value);
    }
}