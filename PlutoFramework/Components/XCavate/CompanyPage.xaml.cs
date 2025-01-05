namespace PlutoFramework.Components.XCavate;

public partial class CompanyPage : ContentPage
{
    public static CompanyViewModel ViewModel;
    public CompanyPage(CompanyViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        this.BindingContext = viewModel;
        ViewModel = viewModel;
    }
}