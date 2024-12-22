namespace PlutoFramework.Components.UpdateView;

public partial class UpdateView : ContentView, ILocalLoadableAsyncView
{
    private const string url = "https://plutonication.com/plutowallet/latest-version";
    private const string downloadUrl = "https://play.google.com/store/apps/details?id=com.rostislavlitovkin.plutowallet";

    public UpdateView()
	{
		InitializeComponent();

		BindingContext = new UpdateViewModel();
    }

    public Task LoadAsync(CancellationToken token) => (BindingContext as UpdateViewModel).CheckLatestVersionAsync(url, token);


    async void OnClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        try
        {
            await Launcher.Default.OpenAsync(downloadUrl);
        }
        catch
        {

        }
    }
}
