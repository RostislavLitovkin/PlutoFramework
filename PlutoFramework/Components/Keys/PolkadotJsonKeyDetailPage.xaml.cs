using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Keys;

public partial class PolkadotJsonKeyDetailPage : PageTemplate
{
	public PolkadotJsonKeyDetailPage(PolkadotJsonKeyDetailPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
