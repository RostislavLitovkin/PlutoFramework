namespace PlutoFramework.Components.AssetSelect;

public partial class AssetSelectButtonView : ContentView
{
    public AssetSelectButtonView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<AssetSelectButtonViewModel>();
    }
}
