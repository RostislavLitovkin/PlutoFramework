namespace PlutoFramework.Components.Error
{
    public partial class BadInternetConnectionPage : ContentPage
    {
        public BadInternetConnectionPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();
        }
    }
}