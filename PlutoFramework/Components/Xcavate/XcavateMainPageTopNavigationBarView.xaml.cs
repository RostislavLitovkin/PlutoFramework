namespace PlutoFramework.Components.Xcavate;

public partial class XcavateMainPageTopNavigationBarView : ContentView
{
	public XcavateMainPageTopNavigationBarView()
	{
		InitializeComponent();

		BindingContext = new XcavateMainPageTopNavigationBarViewModel();

    }
}