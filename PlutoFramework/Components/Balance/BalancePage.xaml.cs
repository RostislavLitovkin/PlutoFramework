using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Balance;

public partial class BalancePage : PageTemplate
{
	public BalancePage()
	{
        InitializeComponent();

        BindingContext = new UsdBalanceViewModel();

        ((UsdBalanceViewModel)BindingContext).UpdateBalances();
    }
}