namespace PlutoFramework.Components.XCavate;

public partial class UserProfilePage : ContentPage
{
    public static UserProfileViewModel ViewModel;
    public UserProfilePage(UserProfileViewModel viewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        this.BindingContext = viewModel;

        ViewModel = viewModel;
    }
}