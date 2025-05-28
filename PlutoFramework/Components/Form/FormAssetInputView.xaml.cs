using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Form;

public partial class FormAssetInputView : ContentView
{
    public static readonly BindableProperty CardWidthProperty = BindableProperty.Create(
       nameof(CardWidth), typeof(int), typeof(FormAssetInputView),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var control = (FormAssetInputView)bindable;

           var width = (int)newValue - 20;
           control.entry.WidthRequest = width;
       });

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        nameof(Placeholder), typeof(string), typeof(FormAssetInputView),
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormAssetInputView)bindable;
            control.entry.Placeholder = (string)newValue;
        });

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(FormAssetInputView),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormAssetInputView)bindable;

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
        nameof(UpdateCommand), typeof(IRelayCommand), typeof(FormAssetInputView),
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.Create(
        nameof(KeyboardType), typeof(Keyboard), typeof(FormAssetInputView),
        defaultValue: Keyboard.Default,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (FormAssetInputView)bindable;
            control.entry.Keyboard = (Keyboard)newValue;
        });

    public FormAssetInputView()
	{
		InitializeComponent();
	}

    public Keyboard KeyboardType
    {
        get => (Keyboard)GetValue(KeyboardTypeProperty);
        set => SetValue(KeyboardTypeProperty, value);
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
}