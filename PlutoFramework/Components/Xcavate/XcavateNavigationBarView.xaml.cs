namespace PlutoFramework.Components.Xcavate;

public partial class XcavateNavigationBarView : ContentView
{
	public XcavateNavigationBarView()
	{
		InitializeComponent();

		BindingContext = DependencyService.Get<XcavateNavigationBarViewModel>();
	}
}