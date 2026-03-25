namespace PlutoFramework.Components.Animations;

public partial class LoadingView : ContentView
{
    private const uint BASE_ANIMATION_SPEED = 500;

    public static readonly BindableProperty PlayingProperty = BindableProperty.Create(
        nameof(Playing), typeof(bool), typeof(LoadingView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (LoadingView)bindable;
            Task loop = control.LoopAsync();
        },
        defaultValue: false);

    public LoadingView()
    {
        InitializeComponent();
    }
    public bool Playing
    { 
        get => (bool)GetValue(PlayingProperty);
        set => SetValue(PlayingProperty, value);
    }

    public async Task LoopAsync()
    {
        while (Playing)
        {
            await leftDot.FadeToAsync(1, BASE_ANIMATION_SPEED);

            await Task.WhenAll(
                leftDot.FadeToAsync(0, BASE_ANIMATION_SPEED),
                middleDot.FadeToAsync(1, BASE_ANIMATION_SPEED)
            );

            await Task.WhenAll(
                middleDot.FadeToAsync(0, BASE_ANIMATION_SPEED),
                rightDot.FadeToAsync(1, BASE_ANIMATION_SPEED)
            );

            await rightDot.FadeToAsync(0, BASE_ANIMATION_SPEED);
        }
    }
}