namespace PlutoFramework.Components.Messaging;

public partial class OutgoingMessageView : ContentView
{
    public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), 
        typeof(string), typeof(IncomingMessageView));

    public string Message
    {
        get => (string)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }
        
    public static readonly BindableProperty TimestampProperty = BindableProperty.Create(nameof(Timestamp), 
        typeof(string), typeof(IncomingMessageView));

    public string Timestamp
    {
        get => (string)GetValue(TimestampProperty);
        set => SetValue(TimestampProperty, value);
    }
    
    public OutgoingMessageView()
    {
        InitializeComponent();
        
        BindingContext = this;
    }
}