namespace PlutoFramework.Components.Kilt;

public partial class NoDidPage : ContentPage
{
	public NoDidPage(NoDidViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = viewModel;
	}
}