namespace PlutoFramework.Components.Messaging
{
    public partial class IncomingMessageView: ContentView
    {
        public static readonly BindableProperty MsgColorProperty = BindableProperty.Create(nameof(MsgColor), 
            typeof(Color), typeof(IncomingMessageView), Application.Current.Resources["Primary"] as Color);

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
        
        public IncomingMessageView()
        {
            InitializeComponent();
            
            BindingContext = this;
        }
    }
}