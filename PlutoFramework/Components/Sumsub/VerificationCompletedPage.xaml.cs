using PlutoFramework.View;

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
        private async void ContinueToMainPageClicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SetupPasswordPage());
        }
    }
}