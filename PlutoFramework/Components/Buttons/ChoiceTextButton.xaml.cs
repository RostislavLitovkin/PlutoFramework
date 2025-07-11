using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Buttons;

public partial class ChoiceTextButton : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text), typeof(string), typeof(ChoiceTextButton),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (ChoiceTextButton)bindable;

                control.label.Text = (string)newValue;

            });

    public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected), typeof(bool), typeof(ChoiceTextButton),
            defaultValue: false,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (ChoiceTextButton)bindable;

                control.selectedBackground.IsVisible = (bool)newValue;
            });

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command), typeof(IRelayCommand), typeof(ChoiceTextButton),
            defaultValue: null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = (ChoiceTextButton)bindable;
                control.gestureRecognizer.Command = (IRelayCommand)newValue;
            });

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        nameof(CommandProperty), typeof(object), typeof(ChoiceTextButton),
        defaultValue: null,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (ChoiceTextButton)bindable;
            control.gestureRecognizer.CommandParameter = newValue;
        });
    public ChoiceTextButton()
    {
        InitializeComponent();
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    public IRelayCommand Command
    {
        get => (IRelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }
}