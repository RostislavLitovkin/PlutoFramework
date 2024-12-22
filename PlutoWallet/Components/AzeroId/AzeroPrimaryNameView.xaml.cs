using AzeroIdResolver;
using PlutoWallet.Model;

namespace PlutoWallet.Components.AzeroId;

public partial class AzeroPrimaryNameView : ContentView, ISubstrateClientLoadableAsyncView
{
	public AzeroPrimaryNameView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<AzeroPrimaryNameViewModel>();
    }

	public async Task LoadAsync(PlutoWalletSubstrateClient client, CancellationToken token)
	{
        var viewModel = (AzeroPrimaryNameViewModel)BindingContext;

        if (client is null || client.Endpoint.Key != Constants.EndpointEnum.AzeroTestnet)
        {
            return;
        }

        var temp = await TzeroId.GetPrimaryNameForAddress(client.SubstrateClient, KeysModel.GetSubstrateKey());

        if (temp == null)
        {
            viewModel.PrimaryName = "None";
            viewModel.ReservedUntilIsVisible = false;
        }
        else
        {
            viewModel.PrimaryName = temp.ToUpper();
            viewModel.Tld = ("." + await TzeroId.GetTld(client.SubstrateClient)).ToUpper();

            viewModel.ReservedUntil = await Model.AzeroId.AzeroIdModel.GetReservedUntilStringForName(temp);

            viewModel.ReservedUntilIsVisible = true;
        }
    }
}
