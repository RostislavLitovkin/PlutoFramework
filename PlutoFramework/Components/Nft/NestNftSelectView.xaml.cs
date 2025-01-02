namespace PlutoFramework.Components.Nft;

public partial class NestNftSelectView : ContentView
{
	public NestNftSelectView()
	{
		InitializeComponent();

        var viewModel = DependencyService.Get<NestNftSelectViewModel>();

        BindingContext = viewModel;
    }
}