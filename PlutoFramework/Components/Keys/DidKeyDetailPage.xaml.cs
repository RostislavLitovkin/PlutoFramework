using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Keys;

public partial class DidKeyDetailPage : PageTemplate
{
	public DidKeyDetailPage(DidKeyDetailPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}