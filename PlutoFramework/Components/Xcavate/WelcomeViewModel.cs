
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Kilt;
using PlutoFramework.Components.WebView;
using PlutoFramework.View;
using PlutoFramework.ViewModel;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Xcavate
{
    public class WelcomeSplash
    {
        public string Image { get; set; }
        public string Description { get; set; }
    }

    public partial class WelcomeViewModel : ObservableObject
    {
        public ObservableCollection<WelcomeSplash> Splashes => new ObservableCollection<WelcomeSplash>
        {
            new WelcomeSplash{ Image = "xcavatelaunchbg1.jpg", Description = "Fractional real estate investment made simple and secure" },
            new WelcomeSplash{ Image = "xcavatelaunchbg2.png", Description = "Browse the marketplace to find your ideal property investment" },
            new WelcomeSplash{ Image = "xcavatelaunchbg3.png", Description = "Unlock the future of real estate with secure, tokenized ownership" },
        };

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
