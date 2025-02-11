namespace PlutoFramework.Components.Xcavate;

public partial class AboutUsView : ContentView
{
	public AboutUsView()
	{
		InitializeComponent();

        BindingContext = new AboutUsViewModel();
    }
}