namespace PlutoFramework.Components.WebView;

public partial class WebSignRawPopupView : ContentView
{
	public WebSignRawPopupView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<WebSignRawPopupViewModel>();
    }
}