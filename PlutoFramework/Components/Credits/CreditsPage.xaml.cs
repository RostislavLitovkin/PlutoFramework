namespace PlutoFramework.Components.Credits
{
    public partial class CreditsPage : ContentPage
    {
        public CreditsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();
        }
    }
}