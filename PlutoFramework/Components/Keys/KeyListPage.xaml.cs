using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Keys;

public partial class KeyListPage : PageTemplate
{
	public KeyListPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        BindingContext = new KeyListPageViewModel();
    }
}