using PlutoFramework.Model.Xcavate;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class QuestionaireFailedPage : PageTemplate
{
	public QuestionaireFailedPage(QuestionaireEvaluationDetail evaluation)
	{
		InitializeComponent();

		BindingContext = new QuestionaireFailedPageViewModel
		{
			Text = evaluation?.Message ?? "",
        };
    }
}