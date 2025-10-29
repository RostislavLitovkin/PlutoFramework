using PlutoFramework.Model.Xcavate;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Xcavate;

public partial class QuestionnaireWarningPage : PageTemplate
{
    public QuestionnaireWarningPage(QuestionnaireWarningPageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}