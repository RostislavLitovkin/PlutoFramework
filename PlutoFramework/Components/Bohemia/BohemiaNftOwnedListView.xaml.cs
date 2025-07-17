using PlutoFramework.Components.Nft;
using PlutoFramework.Model;

namespace PlutoFramework.Components.Bohemia;

public partial class BohemiaNftOwnedListView : ContentView, ILocalLoadableAsyncView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public BohemiaNftOwnedListView()
	{
		InitializeComponent();
	}

    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (!KeysModel.HasSubstrateKey())
        {
            return;
        }

        await nftsOwnedListView.LoadAsync(client, token);

		((ToJoinDaoViewModel)toJoinDaoView.BindingContext).NftCount = (uint)((NftOwnedListViewModel)nftsOwnedListView.BindingContext).Items.Count();
    }

    public void SetEmpty()
    {
        ((NftOwnedListViewModel)nftsOwnedListView.BindingContext).Loading = false;

        ((ToJoinDaoViewModel)toJoinDaoView.BindingContext).NftCount = (uint)((NftOwnedListViewModel)nftsOwnedListView.BindingContext).Items.Count();
    }

    public async Task LoadAsync(CancellationToken token)
    {
        await ((NftOwnedListViewModel)nftsOwnedListView.BindingContext).LoadSavedNftsAsync();

        ((ToJoinDaoViewModel)toJoinDaoView.BindingContext).NftCount = (uint)((NftOwnedListViewModel)nftsOwnedListView.BindingContext).Items.Count();
    }
}