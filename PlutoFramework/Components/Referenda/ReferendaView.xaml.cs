using PlutoFramework.Model;
using PlutoFramework.Model.SubSquare;

namespace PlutoFramework.Components.Referenda;

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

    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        await ReferendumModel.GetReferendaAsync(client, KeysModel.GetSubstrateKey(), token).ConfigureAwait(false);

        (BindingContext as ReferendaViewModel).UpdateReferenda();
    }

    public void SetEmpty()
    {
        (BindingContext as ReferendaViewModel).NoReferenda();
    }
}
