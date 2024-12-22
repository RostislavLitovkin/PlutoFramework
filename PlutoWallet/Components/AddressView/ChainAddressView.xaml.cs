using PlutoWallet.Model;
using Substrate.NetApi;

namespace PlutoWallet.Components.AddressView;

public partial class ChainAddressView : ContentView, IMainSubstrateClientLoadableView
{
	public ChainAddressView()
	{
        BindingContext = DependencyService.Get<ChainAddressViewModel>();

        InitializeComponent();
    }
    public void MainLoad(PlutoWalletSubstrateClient client)
    {
        var viewModel = (ChainAddressViewModel)BindingContext;
        var endpoint = client.Endpoint;

        if (endpoint.Name.Length <= 10)
        {
            viewModel.ChainAddressName = endpoint.Name + " key";
        }
        else
        {
            viewModel.ChainAddressName = endpoint.Name.Split(" ")[0] + " key";
        }

        if (endpoint.ChainType == Constants.ChainType.Substrate)
        {
            viewModel.Address = Utils.GetAddressFrom(KeysModel.GetPublicKeyBytes(), endpoint.SS58Prefix);

            try
            {
                viewModel.QrAddress = "substrate:" + viewModel.Address + ":" + client.SubstrateClient.GenesisHash;
            }
            catch
            {
                viewModel.QrAddress = "substrate:" + viewModel.Address;
            }
        }
        else if (endpoint.ChainType == Constants.ChainType.Ethereum)
        {
            viewModel.Address = Utils.Bytes2HexString(KeysModel.GetPublicKeyBytes()).Substring(0, 42);

            viewModel.QrAddress = viewModel.Address;
        }

        IsVisible = true;
    }
}
