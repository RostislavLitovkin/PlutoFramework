
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.WebView;
using PlutoFramework.View;
using PlutoFramework.ViewModel;

namespace PlutoFramework.Components.Xcavate
{
    public partial class WelcomeViewModel : ObservableObject
    {
        [RelayCommand]
        public Task LearnMoreAsync() => Application.Current.MainPage.Navigation.PushAsync(new WebViewPage("https://xcavate.io/risk-warning/"));

        [RelayCommand]
        public void BrowseProperties()
        {
            Application.Current.MainPage = new AppShell();
        }

        [RelayCommand]
        public Task ImportAccountAsync() => Application.Current.MainPage.Navigation.PushAsync(
            new SetupPasswordPage()
            {
                Navigation = () => Application.Current.MainPage.Navigation.PushAsync(
                    new EnterMnemonicsPage(
                        new EnterMnemonicsViewModel
                        {
                            Navigation = () => Application.Current.MainPage.Navigation.PushAsync(
                                new NoDidPage(
                                    new NoDidViewModel
                                    {
                                        Navigation = NoDidModel.DidNavigateToNextPageAsync
                                        // #PyramidCode
                                    }
                                )
                            )
                        }
                    )
                )
            }
        );

        [RelayCommand]
        public Task CreateAccountAsync() => Application.Current.MainPage.Navigation.PushAsync(
            new SetupPasswordPage() {
                Navigation = CreateAccountNavigationAsync
            }
        );
        public async Task CreateAccountNavigationAsync()
        {
            await Model.KeysModel.GenerateNewAccountAsync(null, accountVariant: "");

            await Model.KeysModel.GenerateNewAccountAsync(null, accountVariant: "kilt1");

            await Application.Current.MainPage.Navigation.PushAsync(
                new UserTypeSelectionPage()
            );
        }
    }
}
