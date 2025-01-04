namespace PlutoFramework.Components.XCavate;

public partial class UserProfilePage : ContentPage
{
	public UserProfilePage(UserProfileViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        this.BindingContext = viewModel;
	}
}