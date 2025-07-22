using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Sumsub
{
    public partial class VerificationCompletedPage : PageTemplate
    {
        public VerificationCompletedPage()
        {
            InitializeComponent();
        }
        private async void ContinueToMainPageClicked(System.Object sender, System.EventArgs e)
        {
            // unused
            //await Navigation.PushAsync(new SetupPasswordPage());
        }
    }
}