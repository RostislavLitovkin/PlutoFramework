using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.XcavateProperty.Cells;

public partial class TotalInvestedCellView : ContentView, ISetEmptyView, ISubstrateClientLoadableAsyncView
{
	public TotalInvestedCellView()
	{
		InitializeComponent();
	}

    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (client.Endpoint.Key != Constants.EndpointEnum.XcavatePaseo)
        {
            return;
        }

        if (!KeysModel.HasSubstrateKey())
        {
            return;
        }

        await XcavateOwnedPropertiesModel.LoadAsync(client, KeysModel.GetSubstrateKey(), token);

        var usdInvested = XcavateOwnedPropertiesModel.GetTotalInvested();
        cell.Value = $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * usdInvested)}";
    }

    public void SetEmpty()
    {
        var usdInvested = XcavateOwnedPropertiesModel.GetTotalInvested();

        cell.Value = $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * usdInvested)}";
    }
}