using PlutoFramework.Components.Xcavate;
using PlutoFramework.Model;
using PlutoFramework.Model.Sumsub;

namespace PlutoFramework.Components.Kilt
{
    public class NoDidModel
    {
        public static async Task DidNavigateToNextPageAsync(Func<Task> verifiedNavigation, Func<Task> unverifiedNavigation)
        {
            CancellationToken token = CancellationToken.None;

            // Check if the account already exists

            if (!Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY + "kilt1"))
            {
                Console.WriteLine("No did");

                return;
            }

            var did = Preferences.Get(PreferencesModel.PUBLIC_KEY + "kilt1", "");

            var secrets = SumsubSecretModel.GetSecrets();

            var applicantData = await SumsubModel.GetApplicantDataAsync(did, secrets.SecretKey, secrets.AppToken, token);

            if (applicantData is not null)
            {
                await verifiedNavigation.Invoke();
                //Application.Current.MainPage = new XcavateAppShell();
                return;
            }

            await unverifiedNavigation.Invoke();
            /*await Application.Current.MainPage.Navigation.PushAsync(
                new UserTypeSelectionPage()
            );*/
        }
    }
}
