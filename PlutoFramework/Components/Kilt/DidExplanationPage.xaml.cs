using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Kilt
{
    public partial class DidExplanationPage : PageTemplate
    {
        public Command<string> OpenUrlCommand { get; }
        public DidExplanationPage()
        {
#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
            OpenUrlCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url).ConfigureAwait(true));
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates

            InitializeComponent();
        }
    }
}