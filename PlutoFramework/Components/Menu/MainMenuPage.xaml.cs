using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Menu;

public partial class MainMenuPage : PageTemplate
{
	public MainMenuPage()
	{
		InitializeComponent();

		BindingContext = new MainMenuPageViewModel();
	}
}