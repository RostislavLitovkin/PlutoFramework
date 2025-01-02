namespace PlutoFramework.Components.NetworkSelect;

public partial class NetworkSelectPopup : ContentView
{
	public NetworkSelectPopup()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<NetworkSelectPopupViewModel>();
    }
}
