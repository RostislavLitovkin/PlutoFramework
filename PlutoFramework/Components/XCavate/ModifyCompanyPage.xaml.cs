namespace PlutoFramework.Components.Xcavate;

public partial class ModifyCompanyPage : ContentPage
{
    public ModifyCompanyPage(ModifyCompanyViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = viewModel;
    }
}