using PlutoFramework.Components.AddressView;
using PlutoFramework.Components.TransferView;

namespace PlutoFramework.Components.Buttons;

public partial class ReceiveAndTransferView : ContentView
{
	public ReceiveAndTransferView()
	{
		InitializeComponent();
	}

    void OnReceiveClicked(System.Object sender, System.EventArgs e)
    {
        var chainAddressViewModel = DependencyService.Get<ChainAddressViewModel>();

        var qrViewModel = DependencyService.Get<AddressQrCodeViewModel>();

        qrViewModel.QrAddress = chainAddressViewModel.QrAddress;
        qrViewModel.Address = chainAddressViewModel.Address;
        qrViewModel.IsVisible = true;
    }

    void OnTransferClicked(System.Object sender, System.EventArgs e)
    {
        var viewModel = DependencyService.Get<TransferViewModel>();

        viewModel.IsVisible = true;

        viewModel.GetFeeAsync();
    }
}
