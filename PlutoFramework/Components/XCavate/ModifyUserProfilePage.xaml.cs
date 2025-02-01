namespace PlutoFramework.Components.XCavate;

public partial class ModifyUserProfilePage : ContentPage
{
	public ModifyUserProfilePage(ModifyUserProfileViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

		BindingContext = viewModel;
	}
}