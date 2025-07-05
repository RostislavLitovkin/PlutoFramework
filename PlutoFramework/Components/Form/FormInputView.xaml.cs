using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Form;

public partial class FormInputView : ContentView
{
    public static readonly BindableProperty CardWidthProperty = BindableProperty.Create(
       nameof(CardWidth), typeof(int), typeof(FormInputView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var control = (FormInputView)bindable;

           var width = (int)newValue - 20;
           control.entry.WidthRequest = width;
       });

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder), typeof(string), typeof(FormInputView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormInputView)bindable;
            control.entry.Placeholder = (string)newValue;
        });

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(FormInputView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormInputView)bindable;

            if (control.entry.Text == (string)newValue)
            {
                return;
            }

            try
            {
                control.entry.Text = (string)newValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        });


    public static readonly BindableProperty UpdateCommandProperty = BindableProperty.Create(
        nameof(UpdateCommand), typeof(IRelayCommand), typeof(FormInputView),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.Create(
        nameof(KeyboardType), typeof(Keyboard), typeof(FormInputView),
        defaultValue: Keyboard.Default,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormInputView)bindable;
            control.entry.Keyboard = (Keyboard)newValue;
        });

    public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(
        nameof(MaxValue), typeof(string), typeof(FormInputView),
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var maxValue = (string?)newValue;
            var control = (FormInputView)bindable;
            control.maxButton.IsVisible = maxValue != null;
            control.card.CardPadding = new Thickness(10, 0, 0, 0);
            Grid.SetColumnSpan(control.entry, 1);
        }
    );
    public FormInputView()
    {
        InitializeComponent();
    }

    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
    }

    public string? MaxValue
    {
        get => (string?)GetValue(MaxValueProperty);
        set => SetValue(MaxValueProperty, value);
    }

    public int CardWidth
    {
        get => (int)GetValue(CardWidthProperty);
        set => SetValue(CardWidthProperty, value);
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }
    public IRelayCommand UpdateCommand
    {
        get => (IRelayCommand)GetValue(UpdateCommandProperty);
        set => SetValue(UpdateCommandProperty, value);
    }

    public bool ValidateEmail { get; set; } = false;
    private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        try
        {
            if (e.PropertyName != "Text")
            {
                return;
            }

            SetValue(TextProperty, ((Entry)sender).Text);

            if (UpdateCommand != null)
            {
                UpdateCommand.Execute(null);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void OnUnfocused(object sender, FocusEventArgs e)
    {
        if (((Entry)sender).Text == "")
        {
            return;
        }

        if (ValidateEmail)
        {
            if (FormModel.IsValidEmail(((Entry)sender).Text))
            {
                card.SetDefaultColor();
            }
            else
            {
                card.SetRedColor();
            }
        }
    }

    private void OnFocused(object sender, FocusEventArgs e)
    {
        card.SetDefaultColor();
    }

    private void OnMaxClicked(object sender, TappedEventArgs e)
    {
        SetValue(TextProperty, MaxValue);
    }
}