namespace PlutoFramework.Components.Buttons;

public partial class ElevatedButton : Button
{
    public static readonly BindableProperty ButtonStateProperty = BindableProperty.Create(
        nameof(ButtonState), typeof(ButtonStateEnum), typeof(ElevatedButton),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (ElevatedButton)bindable;

            control.IsVisible = (ButtonStateEnum)newValue != ButtonStateEnum.Invisible;
            switch ((ButtonStateEnum)newValue)
            {
                case ButtonStateEnum.Enabled:
                    /*control.Background = new LinearGradientBrush
                    {
                        EndPoint = new Point(1, 0),
                        GradientStops = new GradientStopCollection
                        {
                            new GradientStop { Offset = 0.0f, Color = Color.FromArgb("ecb278") },
                            new GradientStop { Offset = 0.3f, Color = Color.FromArgb("dc7da6") },
                            new GradientStop { Offset = 0.8f, Color = Color.FromArgb("3b4f74") },
                            new GradientStop { Offset = 1.0f, Color = Color.FromArgb("57a0c5") }
                        },
                    };*/

                    control.BackgroundColor = (Color)Application.Current.Resources["X-BLUE"];

                    control.TextColor = Colors.White;

                    control.IsEnabled = true;
                    break;
                case ButtonStateEnum.Disabled:
                    /*control.Background = new LinearGradientBrush
                    {
                        EndPoint = new Point(1, 0),
                        GradientStops = new GradientStopCollection
                        {
                            new GradientStop { Offset = 0.0f, Color = Color.FromArgb("#d9b38c") },
                            new GradientStop { Offset = 0.3f, Color = Color.FromArgb("#e0b8c9") },
                            new GradientStop { Offset = 0.8f, Color = Color.FromArgb("#7585a3") },
                            new GradientStop { Offset = 1.0f, Color = Color.FromArgb("#98bbcd") }
                        },
                    };*/

                    control.BackgroundColor = (Color)Application.Current.Resources["X-BLUE-DISABLED"];

                    control.IsEnabled = false;
                    break;
                case ButtonStateEnum.Warning:
                    control.IsEnabled = true;
                    control.Background = Colors.Red;
                    control.TextColor = Colors.White;
                    break;
            }
        },
        defaultValue: ButtonStateEnum.Enabled);

    public ElevatedButton()
    {
        InitializeComponent();
    }

    public ButtonStateEnum ButtonState
    {
        get => (ButtonStateEnum)GetValue(ButtonStateProperty);
        set => SetValue(ButtonStateProperty, value);
    }
}