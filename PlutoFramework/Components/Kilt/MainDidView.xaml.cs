using Kilt.NetApi.Generated;
using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;
using WebSocketSharp;

namespace PlutoFramework.Components.Kilt;

public partial class MainDidView : DidView, ILocalLoadableView, ISubstrateClientLoadableAsyncView
{
	public MainDidView()
	{
		InitializeComponent();
	}

    public void Load()
    {
        if (!Preferences.ContainsKey(PreferencesModel.DID + "kilt1"))
        {
            return;
        }

        this.Did = Preferences.Get(PreferencesModel.DID + "kilt1", "");

        this.Verification = (DidVerificationEnum)Enum.Parse(typeof(DidVerificationEnum), Preferences.Get(PreferencesModel.DID_VERIFICATION + "kilt1", DidVerificationEnum.Light.ToString()));
    }

    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        // You can allow only your chain.
        if (client is null || client.Endpoint.Key != Constants.EndpointEnum.Kilt || !client.SubstrateClient.IsConnected)
        {
            return ;
        }

        if (this.Did.IsNullOrEmpty())
        {
            return;
        }

        var didDetails = await ((SubstrateClientExt)client.SubstrateClient).DidStorage.Did(
            DidModel.DidAddressToAccountId32(this.Did),
            null,
            token
        );

        if (didDetails is null)
        {
            return;
        }

        this.Verification = DidVerificationEnum.Full;

        Preferences.Set(PreferencesModel.DID_VERIFICATION + "kilt1", DidVerificationEnum.Full.ToString());
    }
}