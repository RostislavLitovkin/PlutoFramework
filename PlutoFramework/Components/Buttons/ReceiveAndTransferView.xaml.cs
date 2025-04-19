using PlutoFramework.Components.Account;
using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.TransferView;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Buttons;

public partial class ReceiveAndTransferView : ContentView
{
	public ReceiveAndTransferView()
	{
		InitializeComponent();
	}

    void OnReceiveClicked(System.Object sender, System.EventArgs e)
    {
        if (!KeysModel.HasSubstrateKey())
        {
            var noAccountPopupViewModel = DependencyService.Get<NoAccountPopupModel>();

            noAccountPopupViewModel.IsVisible = true;

            return;
        }

        var chainAddressViewModel = DependencyService.Get<ChainAddressViewModel>();

        var qrViewModel = DependencyService.Get<AddressQrCodeViewModel>();

        qrViewModel.QrAddress = chainAddressViewModel.QrAddress;
        qrViewModel.Address = chainAddressViewModel.Address;
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
