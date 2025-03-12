namespace PlutoFramework.Components.Kilt;

public partial class DidListView : ContentView
{
	public DidListView()
	{
		InitializeComponent();

        BindingContext = new DidListViewModel();
    }

    // Incomplete, add loading functions according to: https://plutolabs.gitbook.io/plutoframework/make-your-application/create-custom-components
}