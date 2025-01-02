using PlutoFramework.Model;

namespace PlutoFramework.Components.CalamarView;

public partial class CalamarView : ContentView, ISubstrateClientLoadableView
{
    public CalamarView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<CalamarViewModel>();
    }

    public void Load(PlutoFrameworkSubstrateClient client)
    {
        var viewModel = (CalamarViewModel)BindingContext;
        string address = KeysModel.GetPublicKey();

        if (client.Endpoint.CalamarChainName == null)
        {
            // Not supported
        }

        viewModel.WebAddress = "https://calamar.app/" + client.Endpoint.CalamarChainName + "/account/" + address;
    }

    void OnReloadClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var viewModel = DependencyService.Get<CalamarViewModel>();
        viewModel.WebAddress = viewModel.WebAddress;
    }

    async void OnOpenClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        var viewModel = DependencyService.Get<CalamarViewModel>();
        await Launcher.OpenAsync(viewModel.WebAddress);
    }
}
