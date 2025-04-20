using PlutoFramework.Components.Xcavate;
using PlutoFramework.Model;
using PlutoFramework.Model.Sumsub;
using PlutoFramework.View;

namespace PlutoFramework.Components.Kilt
{
    public class NoDidModel
    {
        public static async Task DidNavigateToNextPageAsync()
        {
            Console.WriteLine("Navigate to next page");

            CancellationToken token = CancellationToken.None;

            // Check if the account already exists

            if (!Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY + "kilt1"))
            {
                Console.WriteLine("No did");

                return;
            }

            var did = Preferences.Get(PreferencesModel.PUBLIC_KEY + "kilt1", "");

            var applicantData = await SumsubModel.GetApplicantDataAsync(did, token);

            if (applicantData is not null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(
                    new SetupPasswordPage()
                );

                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(
                new UserTypeSelectionPage()
            );
        }
    }
}
