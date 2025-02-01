using PlutoFramework.Model;

namespace PlutoFramework.Components.Form;

public partial class FormLargeInputView : ContentView
{
    public static readonly BindableProperty CardWidthProperty = BindableProperty.Create(
       nameof(CardWidth), typeof(int), typeof(FormLargeInputView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) => {
           var control = (FormLargeInputView)bindable;

           var width = (int)newValue - 20;
           control.entry.WidthRequest = width;
       });

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder), typeof(string), typeof(FormLargeInputView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormLargeInputView)bindable;
            control.entry.Placeholder = (string)newValue;
        });

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(FormLargeInputView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormLargeInputView)bindable;

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

    public FormLargeInputView()
	{
		InitializeComponent();
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

    private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        try
        {
            if (e.PropertyName != "Text")
            {
                return;
            }

            SetValue(TextProperty, ((Editor)sender).Text);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void OnUnfocused(object sender, FocusEventArgs e)
    {
        if (((Editor)sender).Text == "")
        {
            return;
        }
    }

    private void OnFocused(object sender, FocusEventArgs e)
    {
        
    }
}