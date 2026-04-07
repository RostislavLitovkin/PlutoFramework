using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Kilt;

public partial class NoDidPage : PageTemplate
{
	public NoDidPage()
	{
        InitializeComponent();

        BindingContext = new NoDidViewModel();
	}
}