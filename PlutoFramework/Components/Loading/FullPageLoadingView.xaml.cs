namespace PlutoFramework.Components.Loading;

public partial class FullPageLoadingView : ContentView
{
	public FullPageLoadingView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<FullPageLoadingViewModel>();

    }
}