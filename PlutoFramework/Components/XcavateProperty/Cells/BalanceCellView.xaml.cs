using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Balance;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.HydraDX;
using PlutoFramework.Model.SQLite;

namespace PlutoFramework.Components.XcavateProperty.Cells;

public partial class BalanceCellView : ContentView, ISetEmptyView, ISubstrateClientLoadableAsyncView, ILocalLoadableAsyncView
{
    public BalanceCellView()
    {
        InitializeComponent();

        cell.Command = new AsyncRelayCommand( () => Application.Current.MainPage.Navigation.PushAsync(new BalancePage()));
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
                await Sdk.GetAssetsAsync((Hydration.NetApi.Generated.SubstrateClientExt)client.SubstrateClient,null, token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            AssetsModel.UpdateUsdBalance();
        }

        await Model.AssetsModel.GetBalanceAsync(client, KeysModel.GetSubstrateKey(), token, false);

        cell.Value = Model.AssetsModel.UsdSum.ToCurrencyString();
    }

    public void SetEmpty()
    {
        AssetsModel.UpdateUsdBalance();

        cell.Value = Model.AssetsModel.UsdSum.ToCurrencyString();
    }
}