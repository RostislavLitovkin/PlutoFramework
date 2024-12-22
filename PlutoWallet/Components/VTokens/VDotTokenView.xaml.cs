using PlutoWallet.Model;

namespace PlutoWallet.Components.VTokens;

public partial class VDotTokenView : ContentView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public VDotTokenView()
	{
		InitializeComponent();

        BindingContext = new VDotTokenViewModel();
    }

	public Task LoadAsync(PlutoWalletSubstrateClient client, CancellationToken token) => ((VDotTokenViewModel)BindingContext).UpdateConversionRateAsync(client, token);

    public void SetEmpty() => ((VDotTokenViewModel)BindingContext).SetEmpty();
}
