using PlutoFramework.Model.Xcavate;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class QuestionairePassPage : PageTemplate
{
	public QuestionairePassPage(QuestionaireEvaluationDetail evaluation, Func<Task> navigation)
	{
		InitializeComponent();

		BindingContext = new QuestionairePassPageViewModel
		{
			Text = evaluation?.Message ?? "",
			Title = evaluation?.Message switch
			{
				"Pass" => "Questionaire passed",
				"Warning" => "Risk warning",
				_ => ""
            },
			Navigation = navigation
		};
	}
}