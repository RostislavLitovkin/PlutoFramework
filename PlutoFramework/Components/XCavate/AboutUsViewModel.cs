using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.WebView;

namespace PlutoFramework.Components.Xcavate
{
    public partial class AboutUsViewModel : ObservableObject
    {
        [RelayCommand]
        public Task OpenPrivacyPolicyAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://app.realxmarket.io/privacy"));

        [RelayCommand]
        public Task OpenTermsAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://app.realxmarket.io/terms"));

        [RelayCommand]
        public Task OpenAgreementAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://app.realxmarket.io/agreement"));

        [RelayCommand]
        public Task OpenFeesAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://realxmarket.xcacvate.io/property-info-fees"));

        [RelayCommand]
        public Task OpenXAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://x.com/xcavateofficial"));

        [RelayCommand]
        public Task OpenYoutubeAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://www.youtube.com/channel/UClQdDmDso1Q466dojVDj7Ow"));

        [RelayCommand]
        public Task OpenGithubAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://github.com/XcavateBlockchain"));

        [RelayCommand]
        public Task OpenLiquidityFinderAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://liquidityfinder.com/company/xcavate-04f23037"));

        [RelayCommand]
        public Task OpenDiscordAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://discord.com/invite/AqE9Qwf7Dz"));
    }
}
