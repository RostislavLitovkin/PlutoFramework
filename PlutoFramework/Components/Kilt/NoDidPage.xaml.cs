namespace PlutoFramework.Components.Kilt;

public partial class NoDidPage : ContentPage
{
	public NoDidPage()
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();
	}
}