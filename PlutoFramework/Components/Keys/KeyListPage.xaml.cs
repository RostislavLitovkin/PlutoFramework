using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Keys;

public partial class KeyListPage : PageTemplate
{
	public KeyListPage()
	{
		InitializeComponent();

		BindingContext = new KeyListPageViewModel();
    }
}