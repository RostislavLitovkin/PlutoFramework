namespace PlutoFramework.Components.XCavate;

public partial class CompanyPage : ContentPage
{
    public CompanyPage(CompanyViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ((CompanyViewModel)BindingContext).InitialLoadAsync(CancellationToken.None);
    }
}