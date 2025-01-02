namespace PlutoFramework.Components.TransactionAnalyzer;

public partial class AnalyzedOutcomeView : ContentView
{
	public AnalyzedOutcomeView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<AnalyzedOutcomeViewModel>();
    }
}