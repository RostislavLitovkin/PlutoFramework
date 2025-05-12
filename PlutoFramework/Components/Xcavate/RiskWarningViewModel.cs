using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.WebView;

namespace PlutoFramework.Components.Xcavate
{
    public partial class RiskWarningViewModel : ObservableObject
    {
        [RelayCommand]
        public Task LearnMoreAsync() => Application.Current.MainPage.Navigation.PushAsync(new WebViewPage("https://xcavate.io/risk-warning/"));
    }
}
