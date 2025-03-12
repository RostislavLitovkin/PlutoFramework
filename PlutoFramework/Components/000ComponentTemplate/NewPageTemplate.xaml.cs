namespace PlutoFramework.Components._000ComponentTemplate;

public partial class NewPageTemplate : ContentPage
{
	public NewPageTemplate()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();
	}
}