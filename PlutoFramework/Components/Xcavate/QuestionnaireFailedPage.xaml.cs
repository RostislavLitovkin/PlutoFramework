using PlutoFramework.Model.Xcavate;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class QuestionnaireFailedPage : PageTemplate
{
	public QuestionnaireFailedPage(QuestionnaireEvaluationDetail evaluation)
	{
		InitializeComponent();

		BindingContext = new QuestionnaireFailedPageViewModel
		{
			Text = evaluation?.Message ?? "",
        };
    }
}