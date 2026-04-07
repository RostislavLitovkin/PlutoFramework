namespace PlutoFramework.Components.WebView;

public partial class DAppWebViewConnectionRequestPopupView : ContentView
{
    public DAppWebViewConnectionRequestPopupView()
    {
        InitializeComponent();

        BindingContext = DependencyService.Get<DAppWebViewConnectionRequestPopupViewModel>();
    }
}