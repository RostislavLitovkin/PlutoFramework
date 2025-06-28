namespace PlutoFramework.Components.Hyperlink;

public partial class Link : Span
{
    public static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(Link), string.Empty);

    public Command OpenUrlCommand { get; }

    public Link()
	{
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
        OpenUrlCommand = new Command<string> (async (url) => { Console.WriteLine("here"); await Launcher.OpenAsync(url).ConfigureAwait(true);  });
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates

        BindingContext = this;

        InitializeComponent();
	}

	public string Url
	{
        get => (string)GetValue(Link.UrlProperty);
        set => SetValue(Link.UrlProperty, value);
    }
}