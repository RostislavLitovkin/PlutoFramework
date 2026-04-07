using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.WebView
{
    public partial class ExtensionWebViewPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Action goBackFunction = () => { };

        [ObservableProperty]
        private Action reloadFunction = () => { };

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SearchIsVisible))]
        [NotifyPropertyChangedFor(nameof(RefreshIsVisible))]
        private string source = "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SearchIsVisible))]
        [NotifyPropertyChangedFor(nameof(RefreshIsVisible))]
        private string searchSource = "";

        public bool SearchIsVisible => Source != SearchSource;

        public bool RefreshIsVisible => Source == SearchSource;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(BackOpacity))]
        private bool canGoBack = false;

        public double BackOpacity => CanGoBack ? 1.0 : 0.5;

        [RelayCommand]
        public void GoBack() => GoBackFunction();

        [RelayCommand]
        public void Reload() => ReloadFunction();

        [RelayCommand]
        public void Search()
        {
            Source = SearchSource;
        }
    }
}
