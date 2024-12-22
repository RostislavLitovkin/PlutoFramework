using PlutoWallet.Model;
using PlutoWallet.Model.HydrationModel;
using System.Collections.ObjectModel;

namespace PlutoWallet.Components.HydraDX;

public partial class OmnipoolLiquidityView : ContentView, ISubstrateClientLoadableAsyncView
{
    public OmnipoolLiquidityView()
    {
        InitializeComponent();

        BindingContext = new OmnipoolLiquidityViewModel();
    }

    public Task LoadAsync(PlutoWalletSubstrateClient client, CancellationToken token)
    {
        if (client is null || client.Endpoint.Key != Constants.EndpointEnum.Hydration || !client.SubstrateClient.IsConnected)
        {
            return Task.FromResult(0);
        }

        return (BindingContext as OmnipoolLiquidityViewModel).GetOmnipoolLiquidityAsync((Hydration.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, token);
    }
}
