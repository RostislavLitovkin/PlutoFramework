using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.NavigationBar;

public partial class TopNavigationBar : ContentView
{
    public static readonly BindableProperty ExtraIsVisibleProperty = BindableProperty.Create(
        nameof(ExtraIsVisible), typeof(bool), typeof(TopNavigationBar),
        defaultBindingMode: BindingMode.TwoWay,
        defaultValue: true,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (TopNavigationBar)bindable;

            control.extraLabel.IsVisible = (bool)newValue;
        });

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(TopNavigationBar),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (TopNavigationBar)bindable;

            control.titleText.Text = (string)newValue;
        });

    public static readonly BindableProperty ExtraCommandProperty = BindableProperty.Create(
        nameof(ExtraCommand), typeof(IAsyncRelayCommand), typeof(TopNavigationBar),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) => {
            var control = (TopNavigationBar)bindable;

            control.extraLabelTapGestureRecognizer.Command = (IAsyncRelayCommand)newValue;
        });
    public TopNavigationBar()
	{
		InitializeComponent();
	}

    public string Title
    {
        get => (string)GetValue(TitleProperty);

        set => SetValue(TitleProperty, value);
    }

    public string ExtraTitle { set { extraLabelText.Text = value; } }

    public Func<Task> ExtraFunc { get; set; }

    public IAsyncRelayCommand ExtraCommand
    {
        get => (IAsyncRelayCommand)GetValue(ExtraCommandProperty);

        set => SetValue(ExtraCommandProperty, value);
    }

    public bool ExtraIsVisible
    {
        get => (bool)GetValue(ExtraIsVisibleProperty);

        set => SetValue(ExtraIsVisibleProperty, value);
    }
    private async void OnBackClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnExtraClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        if (ExtraFunc is null)
        {
            return;
        }

        await ExtraFunc();
    }
}
