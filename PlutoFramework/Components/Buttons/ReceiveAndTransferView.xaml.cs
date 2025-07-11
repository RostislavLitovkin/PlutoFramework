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
        ReceiveAndTransferModel.Receive();
    }

    void OnTransferClicked(System.Object sender, System.EventArgs e)
    {
        ReceiveAndTransferModel.Transfer();
    }
}
