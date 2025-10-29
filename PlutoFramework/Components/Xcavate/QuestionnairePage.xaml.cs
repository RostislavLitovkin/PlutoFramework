using PlutoFramework.Model.Xcavate;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class QuestionnairePage : PageTemplate
{
	public QuestionnairePage(QuestionnaireInfo info)
	{
		InitializeComponent();

		BindingContext = new QuestionnairePageViewModel
		{
			Info = info
		};
    }
}