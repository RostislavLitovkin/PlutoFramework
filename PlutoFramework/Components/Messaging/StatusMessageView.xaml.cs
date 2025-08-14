namespace PlutoFramework.Components.Messaging;

public partial class StatusMessageView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), 
        typeof(string), typeof(IncomingMessageView));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public StatusMessageView()
    {
        InitializeComponent();
        
        BindingContext = this;
    }
}