using PlutoFramework.Templates.PageTemplate;


namespace PlutoFramework.Components.WebView;

public partial class ExtensionWebViewPage : PageTemplate
{
    private double lastScrollY = 0;
    private bool scrollingDown = false;
    public ExtensionWebViewPage(string source)
    {
        InitializeComponent();

        BindingContext = new ExtensionWebViewPageViewModel
        {
            Source = source,
            SearchSource = source,
            GoBackFunction = webView.GoBack,
            ReloadFunction = webView.Reload,
        };
    }

    private async void OnScrolled(object sender, ScrolledEventArgs e)
    {
        if (lastScrollY < e.ScrollY && !scrollingDown)
        {
            scrollingDown = true;

            await navigationBar.TranslateToAsync(0, 60, 250, Easing.CubicInOut);
        }
        else if (lastScrollY > e.ScrollY && scrollingDown)
        {
            scrollingDown = false;

            await navigationBar.TranslateToAsync(0, 0, 250, Easing.CubicInOut);
        }

        lastScrollY = e.ScrollY;
    }

    private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var viewModel = (ExtensionWebViewPageViewModel)BindingContext;

        if (e.PropertyName == "CanGoBack")
        {
            viewModel.CanGoBack = ((Microsoft.Maui.Controls.WebView)sender).CanGoBack;
        }

        if (e.PropertyName == "Source" && ((Microsoft.Maui.Controls.WebView)sender).Source is UrlWebViewSource)
        {
            viewModel.SearchSource = ((UrlWebViewSource)((Microsoft.Maui.Controls.WebView)sender).Source).Url;
        }
    }

    private void OnNavigated(object sender, WebNavigatedEventArgs e)
    {
        var viewModel = (ExtensionWebViewPageViewModel)BindingContext;

        viewModel.SearchSource = e.Url;
    }
}