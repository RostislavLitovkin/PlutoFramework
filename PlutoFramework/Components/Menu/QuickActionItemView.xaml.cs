using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Menu;

public partial class QuickActionItemView : ContentView
{
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(QuickActionItemView), default(ImageSource));

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(QuickActionItemView), default(string));

    public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(IAsyncRelayCommand), typeof(QuickActionItemView),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (QuickActionItemView)bindable;

                control.verticalStackLayout.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = (IAsyncRelayCommand)newValue
                });
            });

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public IAsyncRelayCommand Command
    {
        get => (IAsyncRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public QuickActionItemView()
    {
        InitializeComponent();

        verticalStackLayout.BindingContext = this;
    }
}