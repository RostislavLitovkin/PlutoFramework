namespace PlutoFramework.Components.Messaging
{
    public partial class IncomingMessageView: ContentView
    {
        public static readonly BindableProperty MsgColorProperty = BindableProperty.Create(nameof(MsgColor), 
            typeof(Color), typeof(IncomingMessageView), Application.Current.Resources["X-LEAFGREEN"] as Color);

        public Color MsgColor
        {
            get => (Color)GetValue(MsgColorProperty);
            set => SetValue(MsgColorProperty, value);
        }
        
        public static readonly BindableProperty SenderProperty = BindableProperty.Create(nameof(Sender), typeof(string),
            typeof(IncomingMessageView));

        public string Sender
        {
            get => (string)GetValue(SenderProperty);
            set => SetValue(SenderProperty, value);
        }
        
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
        
        public IncomingMessageView()
        {
            InitializeComponent();
            
            BindingContext = this;
        }
    }
}