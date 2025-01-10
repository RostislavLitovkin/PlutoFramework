namespace PlutoFramework.Components.XCavate;

public partial class AboutUsView : ContentView
{
	public AboutUsView()
	{
		InitializeComponent();

        BindingContext = new AboutUsViewModel();
    }
}