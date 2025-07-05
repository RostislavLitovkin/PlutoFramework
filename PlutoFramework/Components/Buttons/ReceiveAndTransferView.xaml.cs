using PlutoFramework.Components.Account;
using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Components.TransferView;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using Substrate.NetApi;

namespace PlutoFramework.Components.Buttons;

public partial class ReceiveAndTransferView : ContentView
{
	public ReceiveAndTransferView()
	{
		InitializeComponent();
	}

    void OnReceiveClicked(System.Object sender, System.EventArgs e)
    {
        var qrViewModel = DependencyService.Get<AddressQrCodeViewModel>();

        var selectedEndpointKey = DependencyService.Get<MultiNetworkSelectViewModel>().SelectedKey ?? EndpointEnum.None;

        if (selectedEndpointKey == EndpointEnum.None)
        {
            return;
        }

        var endpoint = EndpointsModel.GetEndpoint(selectedEndpointKey);

        var keyToGenesisHash = Endpoints.HashToKey.ToDictionary(x => x.Value, x => x.Key);

        if (!KeysModel.HasSubstrateKey())
        {
            var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupModel>();

            noAccountPopupViewModel.IsVisible = true;

            return;
        }


        if (endpoint.ChainType == Constants.ChainType.Substrate)
        {
            qrViewModel.Address = Utils.GetAddressFrom(KeysModel.GetPublicKeyBytes(), endpoint.SS58Prefix);

            try
            {
                qrViewModel.QrAddress = "substrate:" + qrViewModel.Address + ":" + keyToGenesisHash[selectedEndpointKey];
            }
            catch
            {
                qrViewModel.QrAddress = "substrate:" + qrViewModel.Address;
            }
        }
        else if (endpoint.ChainType == Constants.ChainType.Ethereum)
        {
            qrViewModel.Address = Utils.Bytes2HexString(KeysModel.GetPublicKeyBytes()).Substring(0, 42);

            qrViewModel.QrAddress = qrViewModel.Address;
        }

        qrViewModel.IsVisible = true;
    }

    void OnTransferClicked(System.Object sender, System.EventArgs e)
    {
        if (!KeysModel.HasSubstrateKey())
        {
            var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupModel>();

            noAccountPopupViewModel.IsVisible = true;

            return;
        }

        var viewModel = DependencyService.Get<TransferViewModel>();

        viewModel.IsVisible = true;

        viewModel.GetFeeAsync();
    }
}
