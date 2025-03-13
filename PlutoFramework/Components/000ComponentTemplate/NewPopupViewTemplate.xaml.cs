namespace PlutoFramework.Components._000ComponentTemplate;

public partial class NewPopupViewTemplate : ContentView
{
	public NewPopupViewTemplate()
	{
		InitializeComponent();

		BindingContext = DependencyService.Get<NewPopupViewModelTemplate>();
    }
}