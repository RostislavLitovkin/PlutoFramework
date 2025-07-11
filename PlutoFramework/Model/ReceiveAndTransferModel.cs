using PlutoFramework.Components.Account;
using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.NetworkSelect;
using PlutoFramework.Components.TransferView;
using PlutoFramework.Constants;
using Substrate.NetApi;

namespace PlutoFramework.Model
{
    public class ReceiveAndTransferModel
    {
        public static void Receive()
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
                var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupViewModel>();

                noAccountPopupViewModel.IsVisible = true;

                return;
            }


            if (endpoint.ChainType == ChainType.Substrate)
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
            else if (endpoint.ChainType == ChainType.Ethereum)
            {
                qrViewModel.Address = Utils.Bytes2HexString(KeysModel.GetPublicKeyBytes()).Substring(0, 42);

                qrViewModel.QrAddress = qrViewModel.Address;
            }

            qrViewModel.IsVisible = true;
        }

        public static void Transfer()
        {
            if (!KeysModel.HasSubstrateKey())
            {
                var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupViewModel>();

                noAccountPopupViewModel.IsVisible = true;

                return;
            }

            var viewModel = DependencyService.Get<TransferViewModel>();

            viewModel.IsVisible = true;

            viewModel.GetFeeAsync();
        }
    }
}
