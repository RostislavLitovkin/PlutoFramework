
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.Mnemonics;
using PlutoFramework.Model;
using PlutoFramework.Model.Sumsub;
using PlutoFramework.View;

namespace PlutoFramework.Components.Xcavate
{
    public partial class WelcomeViewModel : ObservableObject
    {
        private bool clicked = false;

        [RelayCommand]
        public Task BrowsePropertiesAsync() => Application.Current.MainPage.Navigation.PushAsync(new SetupPasswordPage());

        // TODO other commands

        private static async Task DidNavigateToNextPageAsync()
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

            Console.WriteLine(did);

            var applicantData = await SumsubModel.GetApplicantDataAsync(did, token);

            await Application.Current.MainPage.Navigation.PushAsync(
                    new SetupPasswordPage()
                );

            return;

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
