namespace PlutoFramework.Components.Messaging;

public partial class OutgoingMessageView : ContentView
{
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), 
        typeof(string), typeof(IncomingMessageView));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
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