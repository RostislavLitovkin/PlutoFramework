using PlutoFramework.Model.Xcavate;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class QuestionairePage : PageTemplate
{
	public QuestionairePage(QuestionaireInfo info)
	{
		InitializeComponent();

		BindingContext = new QuestionairePageViewModel
		{
			Info = info
		};
    }
}