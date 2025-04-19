
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.WebView;
using PlutoFramework.Model;
using PlutoFramework.Model.Sumsub;
using PlutoFramework.View;
using PlutoFramework.ViewModel;
using UniqueryPlus.External;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.Xcavate
{
    public partial class WelcomeViewModel : ObservableObject
    {
        [RelayCommand]
        public Task LearnMoreAsync() => Application.Current.MainPage.Navigation.PushAsync(new WebViewPage("https://xcavate.io"));

        [RelayCommand]
        public Task BrowseProperties() => Application.Current.MainPage.Navigation.PushAsync(new SetupPasswordPage());

        [RelayCommand]
        public Task ImportAccount() => Application.Current.MainPage.Navigation.PushAsync(
            new EnterMnemonicsPage(
                new EnterMnemonicsViewModel
                {
                    Navigation = () => Application.Current.MainPage.Navigation.PushAsync(
                        new NoDidPage(
                            new NoDidViewModel
                            {
                                Navigation = DidNavigateToNextPageAsync
                                // #PyramidCode
                            }
                        )
                    )
                }
            )
        );

        [RelayCommand]
        public async Task CreateAccount()
        {
            await Model.KeysModel.GenerateNewAccountAsync(null, accountVariant: "");

            await Model.KeysModel.GenerateNewAccountAsync(null, accountVariant: "kilt1");

            await Application.Current.MainPage.Navigation.PushAsync(
                new UserTypeSelectionPage()
            );
        }

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
