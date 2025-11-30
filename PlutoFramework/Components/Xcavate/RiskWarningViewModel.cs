using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.WebView;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Xcavate
{
    public partial class RiskWarningViewModel : ObservableObject
    {
        [RelayCommand]
        public Task LearnMoreAsync() => NavigationModel.PushAsync(new WebViewPage("https://realxmarket.xcavate.io/risk-warning"));
    }
}
