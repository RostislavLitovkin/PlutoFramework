using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.Xcavate
{
    public partial class AboutUsViewModel : ObservableObject
    {
        [RelayCommand]
        public Task OpenPrivacyPolicyAsync() => Browser.Default.OpenAsync("https://realxmarket.xcavate.io/privacy", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenTermsAsync() => Browser.Default.OpenAsync("https://realxmarket.xcavate.io/terms", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenAgreementAsync() => Browser.Default.OpenAsync("https://realxmarket.xcavate.io/agreement", BrowserLaunchMode.SystemPreferred);

        [RelayCommand]
        public Task OpenFeesAsync() => Browser.Default.OpenAsync("https://realxmarket.xcacvate.io/property-info-fees", BrowserLaunchMode.SystemPreferred);

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
