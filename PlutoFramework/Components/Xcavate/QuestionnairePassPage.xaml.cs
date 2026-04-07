using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class QuestionnairePassPage : PageTemplate
{
	public QuestionnairePassPage(QuestionnairePassPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}