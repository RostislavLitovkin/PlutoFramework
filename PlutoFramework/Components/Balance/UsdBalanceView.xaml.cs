using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.HydraDX;
using PlutoFramework.Model.SQLite;

namespace PlutoFramework.Components.Balance;

public partial class UsdBalanceView : ContentView, ISubstrateClientLoadableAsyncView, ILocalLoadableAsyncView, ISetEmptyView
{
	public UsdBalanceView()
	{
		InitializeComponent();

        BindingContext = new UsdBalanceViewModel();
    }
    public async Task LoadAsync(CancellationToken token)
    {
        if (KeysModel.HasSubstrateKey())
        {
            return;
        }

        AssetsModel.LoadAssets(await BalancesDatabase.GetBalancesAsync());

        var viewModel = (UsdBalanceViewModel)BindingContext;
        viewModel.ReloadIsVisible = false;
        viewModel.UsdSum = AssetsModel.UsdSum.ToCurrencyString();
    }

    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (!KeysModel.HasSubstrateKey())
        {
            return;
        }

        if (client is not null && client.Endpoint.Key == Constants.EndpointEnum.Hydration && client.SubstrateClient.IsConnected)
        {
            try
            {
                await Sdk.GetAssetsAsync((Hydration.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, null, token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            AssetsModel.UpdateUsdBalance();
        }

        await Model.AssetsModel.GetBalanceAsync(client, KeysModel.GetSubstrateKey(), token, false);

        var viewModel = (UsdBalanceViewModel)BindingContext;
        viewModel.UpdateBalances();
    }

    public void SetEmpty()
    {
        if (!KeysModel.HasSubstrateKey())
        {
            return;
        }

        var viewModel = (UsdBalanceViewModel)BindingContext;
        viewModel.ReloadIsVisible = true;
    }
}

