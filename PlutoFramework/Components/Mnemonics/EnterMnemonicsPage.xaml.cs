using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Mnemonics;

public partial class EnterMnemonicsPage : PageTemplate
{
	public EnterMnemonicsPage(EnterMnemonicsViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;
    }
}
