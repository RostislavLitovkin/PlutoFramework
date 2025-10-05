using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Extrinsic;

public partial class CallDetailPage : PageTemplate
{
	public CallDetailPage(CallDetailViewModel viewModel)
	{
        InitializeComponent();

		BindingContext = viewModel;
	}
}