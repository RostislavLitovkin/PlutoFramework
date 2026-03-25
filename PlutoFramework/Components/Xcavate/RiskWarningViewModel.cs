using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.WebView;

namespace PlutoFramework.Components.Xcavate
{
    public partial class RiskWarningViewModel : ObservableObject
    {
        [RelayCommand]
        public Task LearnMoreAsync() => Shell.Current.Navigation.PushAsync(new ExtensionWebViewPage("https://app.realxmarket.io/risk-warning"));
    }
}
