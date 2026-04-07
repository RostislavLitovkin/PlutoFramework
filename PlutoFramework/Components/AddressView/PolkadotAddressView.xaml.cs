using PlutoFramework.Constants;
using PlutoFramework.Model;
using Substrate.NetApi;

namespace PlutoFramework.Components.AddressView;

public partial class PolkadotAddressView : ContentView, ILocalLoadableView
{
	public PolkadotAddressView()
	{
		InitializeComponent();
	}

    public void Load()
    {
        var endpoint = Endpoints.GetEndpointDictionary[EndpointEnum.Polkadot];

        addressView.Title = $"{endpoint.Name.Split(" ")[0]} key";

        if (!KeysModel.HasSubstrateKey())
        {
            addressView.Address = "None";
            return;
        }

        addressView.Address = Utils.GetAddressFrom(KeysModel.GetPublicKeyBytes(), endpoint.SS58Prefix);
        addressView.QrAddress = $"substrate:{addressView.Address}:0x91b171bb158e2d3848fa23a9f1c25182fb8e20313b2c1eb49219da7a70ce90c3";
    }
}