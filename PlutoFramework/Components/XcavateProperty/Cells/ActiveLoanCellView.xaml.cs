using PlutoFramework.Model.Currency;
using PlutoFramework.Model;

namespace PlutoFramework.Components.XcavateProperty.Cells;

public partial class ActiveLoanCellView : ContentView, ISetEmptyView
{
	public ActiveLoanCellView()
	{
		InitializeComponent();
	}

    public void SetEmpty()
    {
        var usdActiveLoan = 0.0;
        cell.Value = usdActiveLoan.ToCurrencyString();
    }
}