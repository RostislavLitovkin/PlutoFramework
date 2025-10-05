using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Keys;

public partial class Sr25519KeyDetailPage : PageTemplate
{
	public Sr25519KeyDetailPage(Sr25519KeyDetailPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}