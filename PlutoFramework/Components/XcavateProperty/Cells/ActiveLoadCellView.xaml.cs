using PlutoFramework.Model.Currency;
using PlutoFramework.Model;

namespace PlutoFramework.Components.XcavateProperty.Cells;

public partial class ActiveLoadCellView : ContentView, ISetEmptyView
{
	public ActiveLoadCellView()
	{
		InitializeComponent();
	}

    public void SetEmpty()
    {
        var usdActiveLoan = 0;
        cell.Value = $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * usdActiveLoan)}";
    }
}