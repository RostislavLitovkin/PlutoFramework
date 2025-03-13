namespace PlutoFramework.Components.Xcavate;

public partial class WelcomePage : ContentPage
{
	public WelcomePage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = new WelcomeViewModel();
    }
}