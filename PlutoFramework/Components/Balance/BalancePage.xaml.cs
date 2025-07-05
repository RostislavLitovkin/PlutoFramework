namespace PlutoFramework.Components.Balance;

public partial class BalancePage : ContentPage
{
	public BalancePage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = new UsdBalanceViewModel();

        ((UsdBalanceViewModel)BindingContext).UpdateBalances();
    }
}