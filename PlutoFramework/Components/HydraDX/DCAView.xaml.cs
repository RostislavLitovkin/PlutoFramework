using PlutoFramework.Model;

namespace PlutoFramework.Components.HydraDX;

public partial class DCAView : ContentView, ISubstrateClientLoadableAsyncView
{
    public DCAView()
    {
        InitializeComponent();
        BindingContext = new DCAViewModel();
    }

    public Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (client is null || client.Endpoint.Key != Constants.EndpointEnum.Hydration || !client.SubstrateClient.IsConnected)
        {
            return Task.FromResult(0);
        }

        return (BindingContext as DCAViewModel).GetDCAAsync((Hydration.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, token);
    }
}
