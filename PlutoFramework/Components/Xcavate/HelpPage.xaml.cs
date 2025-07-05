namespace PlutoFramework.Components.Xcavate;

public partial class HelpPage : ContentPage
{
	public HelpPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();
	}
}