using PlutoFramework.Model;

namespace PlutoFramework.Components.Nft;

public partial class NftsOwnedListView : ContentView, ILocalLoadableAsyncView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public NftsOwnedListView()
	{
		InitializeComponent();
		
		BindingContext = new NftOwnedListViewModel();
	}

    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (!KeysModel.HasSubstrateKey())
        {
            return;
        }

        await ((NftOwnedListViewModel)BindingContext).LoadAsync(client, token);
    }

    public void SetEmpty()
    {
        ((NftOwnedListViewModel)BindingContext).Loading = false;
    }

    public async Task LoadAsync(CancellationToken token)
    {
        await ((NftOwnedListViewModel)BindingContext).LoadSavedNftsAsync();
    }
}