using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.WebView;

public partial class WebViewPage : PageTemplate
{
	public WebViewPage(string url)
	{
        InitializeComponent();

        webView.Source = url;
        topNavigationBar.Title = url;
    }
}
