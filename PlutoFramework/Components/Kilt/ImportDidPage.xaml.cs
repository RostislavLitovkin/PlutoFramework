using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Kilt;

public partial class ImportDidPage : PageTemplate
{
    public ImportDidPage()
	{
        InitializeComponent();

        BindingContext = new ImportDidViewModel();
    }
}