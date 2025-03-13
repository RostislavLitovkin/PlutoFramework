namespace PlutoFramework.Components.Xcavate
{
    public partial class UserTypeSelectionPage : ContentPage
    {
        public UserTypeSelectionPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            BindingContext = new UserTypeSelectionViewModel();
        }
    }
}