namespace PlutoFramework.Components.Kilt;

public partial class ImportDidPage : ContentPage
{

    public ImportDidPage(ImportDidViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = viewModel;

    }
}