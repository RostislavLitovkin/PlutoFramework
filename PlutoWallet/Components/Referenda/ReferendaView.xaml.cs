using PlutoWallet.Model;
using PlutoWallet.Model.SubSquare;

namespace PlutoWallet.Components.Referenda;

public partial class ReferendaView : ContentView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public ReferendaView()
	{
		InitializeComponent();

        BindingContext = new ReferendaViewModel();
    }

    public ReferendaView(ReferendaViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    public async Task LoadAsync(PlutoWalletSubstrateClient client, CancellationToken token)
    {
        await ReferendumModel.GetReferendaAsync(client, KeysModel.GetSubstrateKey(), token).ConfigureAwait(false);

        (BindingContext as ReferendaViewModel).UpdateReferenda();
    }

    public void SetEmpty()
    {
        (BindingContext as ReferendaViewModel).NoReferenda();
    }
}
