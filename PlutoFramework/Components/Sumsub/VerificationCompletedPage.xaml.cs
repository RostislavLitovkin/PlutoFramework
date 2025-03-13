namespace PlutoFramework.Components.Sumsub
{
    public partial class VerificationCompletedPage : ContentPage
    {
        public VerificationCompletedPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();
        }
        private void ContinueToMainPageClicked(System.Object sender, System.EventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Application.Current.MainPage = new AppShell();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}