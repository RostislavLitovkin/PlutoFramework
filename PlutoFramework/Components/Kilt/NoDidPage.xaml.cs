using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Kilt;

public partial class NoDidPage : PageTemplate
{
	public NoDidPage(NoDidViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;
	}
}