namespace PlutoFramework.Components.Mnemonics;

public partial class SuccessfulImportPopupView : ContentView
{
	public SuccessfulImportPopupView()
	{
		InitializeComponent();

		BindingContext = DependencyService.Get<SuccessfulImportPopupViewModel>();
    }
}