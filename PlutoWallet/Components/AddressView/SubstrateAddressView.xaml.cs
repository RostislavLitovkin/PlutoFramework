using PlutoWallet.Model;

namespace PlutoWallet.Components.AddressView;

public partial class SubstrateAddressView : ContentView, ILocalLoadableView
{
	public SubstrateAddressView()
	{
		InitializeComponent();
	}

	public void Load()
	{
		var addressKey = KeysModel.GetSubstrateKey();

        addressView.Address = addressKey;
        addressView.QrAddress = addressKey;
		addressView.Title = "Substrate key";
    }
}
