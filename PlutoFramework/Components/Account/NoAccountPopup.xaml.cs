namespace PlutoFramework.Components.Account;

public partial class NoAccountPopup : ContentView
{
	public NoAccountPopup()
	{
		InitializeComponent();

		BindingContext = DependencyService.Get<NoAccountPopupModel>();
  }
}