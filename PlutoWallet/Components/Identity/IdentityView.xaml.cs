using PlutoWallet.Model;

namespace PlutoWallet.Components.Identity;

public partial class IdentityView : ContentView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public IdentityView()
	{
		InitializeComponent();

        BindingContext = new IdentityViewModel();
    }

	public Task LoadAsync(PlutoWalletSubstrateClient client, CancellationToken token)
	{
		if (client is null || client.Endpoint.Key != Constants.EndpointEnum.PolkadotPeople || !client.SubstrateClient.IsConnected)
        {
            return Task.FromResult(0);
        }

        return ((IdentityViewModel)BindingContext).GetIdentityAsync((PolkadotPeople.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, token);
    }

    public void SetEmpty()
    {
        ((IdentityViewModel)BindingContext).SetEmpty();
    }
}
