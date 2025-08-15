using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Balance;

public partial class BalancePage : PageTemplate
{
	public BalancePage()
	{
        InitializeComponent();

        BindingContext = new BalancePageViewModel();

        _ = ((BalancePageViewModel)BindingContext).UpdateAsync();
    }
}