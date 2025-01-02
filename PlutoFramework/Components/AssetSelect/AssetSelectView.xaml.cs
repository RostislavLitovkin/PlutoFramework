using PlutoFramework.Components.Card;

namespace PlutoFramework.Components.AssetSelect;

public partial class AssetSelectView : ContentView
{
	public AssetSelectView()
	{
		InitializeComponent();

        BindingContext = DependencyService.Get<AssetSelectViewModel>();
    }
}
