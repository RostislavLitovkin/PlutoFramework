using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Tabs;

public partial class TabView : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title), typeof(string), typeof(TabView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TabView)bindable;
            control.titleLabel.Text = (string)newValue;
            control.titleLabel.IsVisible = newValue is not null;
        });

    public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon), typeof(ImageSource), typeof(TabView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TabView)bindable;
            control.icon.Source = (ImageSource)newValue;
            control.icon.IsVisible = newValue is not null;

        });

    public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
        nameof(IsSelected), typeof(bool), typeof(TabView),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TabView)bindable;

            if ((bool)newValue)
            {
                control.underline.BackgroundColor = control.SelectedUnderlineColor;
            }
            else
            {
                control.underline.BackgroundColor = Colors.Transparent;
            }
        });

    public static readonly BindableProperty SelectCommandProperty = BindableProperty.Create(
        nameof(SelectCommand), typeof(IRelayCommand), typeof(TabView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TabView)bindable;

            control.tapGestureRecognizer.Command = (IRelayCommand)newValue;
        });

    public static readonly BindableProperty SelectCommandParameterProperty = BindableProperty.Create(
        nameof(SelectCommandParameter), typeof(object), typeof(TabView),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TabView)bindable;

            control.tapGestureRecognizer.CommandParameter = newValue;
        });

    public static readonly BindableProperty SelectedUnderlineColorProperty = BindableProperty.Create(
        nameof(SelectedUnderlineColor), typeof(Color), typeof(TabView),
        defaultValue: Colors.Transparent,
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var control = (TabView)bindable;
            if (control.IsSelected)
            {
                control.underline.BackgroundColor = (Color)newValue;
            }
        });

    public TabView()
    {
        InitializeComponent();
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public Color SelectedUnderlineColor
    {
        get => (Color)GetValue(SelectedUnderlineColorProperty);
        set => SetValue(SelectedUnderlineColorProperty, value);
    }

    public IRelayCommand SelectCommand
    {
        get => (IRelayCommand)GetValue(SelectCommandProperty);
        set => SetValue(SelectCommandProperty, value);
    }

    public object SelectCommandParameter
    {
        get => (object)GetValue(SelectCommandParameterProperty);
        set => SetValue(SelectCommandParameterProperty, value);
    }
}
