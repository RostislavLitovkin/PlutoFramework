using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.XCavate
{
    public partial class AboutUsViewModel : ObservableObject
    {
        [RelayCommand]
        public Task FAQAsync() => Application.Current.MainPage.Navigation.PushAsync(new FrequentlyAskedQuestionsPage());

        [RelayCommand]
        public Task OpenTeamAsync() => Browser.Default.OpenAsync("https://xcavate.io/team/", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenBlogAsync() => Browser.Default.OpenAsync("https://xcavate.io/blog/", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenWhitepaperAsync() => Browser.Default.OpenAsync("https://xcavate.io/XcavateWhitepaper.pdf", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenXAsync() => Browser.Default.OpenAsync("https://x.com/xcavateofficial", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenYoutubeAsync() => Browser.Default.OpenAsync("https://www.youtube.com/channel/UClQdDmDso1Q466dojVDj7Ow", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenGithubAsync() => Browser.Default.OpenAsync("https://github.com/XcavateBlockchain", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenLiquidityFinderAsync() => Browser.Default.OpenAsync("https://liquidityfinder.com/company/xcavate-04f23037", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenDiscordAsync() => Browser.Default.OpenAsync("https://discord.com/invite/AqE9Qwf7Dz", BrowserLaunchMode.SystemPreferred);
    }
}
