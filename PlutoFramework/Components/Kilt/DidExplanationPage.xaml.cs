namespace PlutoFramework.Components.Kilt
{
    public partial class DidExplanationPage : ContentPage
    {
        public Command<string> OpenUrlCommand { get; }
        public DidExplanationPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

#pragma warning disable VSTHRD101 // Avoid unsupported async delegates
            OpenUrlCommand = new Command<string>(async (url) => await Launcher.OpenAsync(url).ConfigureAwait(true));
#pragma warning restore VSTHRD101 // Avoid unsupported async delegates

            InitializeComponent();
        }
    }
}