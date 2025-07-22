using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class ModifyCompanyPage : PageTemplate
{
    public ModifyCompanyPage(ModifyCompanyViewModel viewModel)
	{
        InitializeComponent();

        BindingContext = viewModel;
    }
}