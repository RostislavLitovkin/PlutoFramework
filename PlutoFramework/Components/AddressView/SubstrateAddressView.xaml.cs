using PlutoFramework.Model;

namespace PlutoFramework.Components.AddressView;

public partial class SubstrateAddressView : ContentView, ILocalLoadableView
{
	public SubstrateAddressView()
	{
		InitializeComponent();
	}

	public void Load()
	{
        addressView.Title = "Substrate key";

        if (!KeysModel.HasSubstrateKey())
        {
            addressView.Address = "None";
            return;
        }

        var addressKey = KeysModel.GetSubstrateKey();

        addressView.Address = addressKey;
        addressView.QrAddress = addressKey;
    }
}
