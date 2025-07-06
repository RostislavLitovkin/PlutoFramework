using PlutoFramework.Model;

namespace PlutoFramework.Components.OpenGov;

public partial class VotingDelegationView : ContentView, ISetEmptyView, ISubstrateClientLoadableAsyncView
{
	public VotingDelegationView()
	{
		InitializeComponent();

        BindingContext = new VotingDelegationViewModel();
    }

    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (client.Endpoint.Key == Constants.EndpointEnum.Polkadot && await client.IsConnectedAsync())
        {
            await ((VotingDelegationViewModel)BindingContext).GetVotingDelegationAsync((Polkadot.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, KeysModel.GetSubstrateKey(), token);
        }

        if (client.Endpoint.Key == Constants.EndpointEnum.PolkadotPeople && await client.IsConnectedAsync())
        {
            ((VotingDelegationViewModel)BindingContext).PolkadotPeopleConnected = true;

            await ((VotingDelegationViewModel)BindingContext).GetIdentityAsync((PolkadotPeople.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, token);
        }
    }

    public void SetEmpty()
    {
        ((VotingDelegationViewModel)BindingContext).SetEmpty();
    }
}