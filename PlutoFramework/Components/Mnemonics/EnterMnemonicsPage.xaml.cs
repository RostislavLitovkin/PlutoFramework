namespace PlutoFramework.Components.Mnemonics;

public partial class EnterMnemonicsPage : ContentPage
{
	public EnterMnemonicsPage(EnterMnemonicsViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = viewModel;
    }
}
