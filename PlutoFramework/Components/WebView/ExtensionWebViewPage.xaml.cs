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

    private Task OnScrolledAsync(object sender, ScrolledEventArgs e)
    {
        if (lastScrollY < e.ScrollY && !scrollingDown)
        {
            scrollingDown = true;

            return navigationBar.TranslateToAsync(0, 60, 250, Easing.CubicInOut)
                .ContinueWith(_ => { lastScrollY = e.ScrollY; }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        else if (lastScrollY > e.ScrollY && scrollingDown)
        {
            scrollingDown = false;

            return navigationBar.TranslateToAsync(0, 0, 250, Easing.CubicInOut)
                .ContinueWith(_ => { lastScrollY = e.ScrollY; }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        lastScrollY = e.ScrollY;
        return Task.CompletedTask;
    }

    private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        var viewModel = (ExtensionWebViewPageViewModel)BindingContext;

        if (e.PropertyName == "CanGoBack")
        {
            viewModel.CanGoBack = ((Microsoft.Maui.Controls.WebView)sender).CanGoBack;
        }

        if (e.PropertyName == "Source")
        {
            Console.WriteLine(((Microsoft.Maui.Controls.WebView)sender).Source.ToString());
        }
    }
}