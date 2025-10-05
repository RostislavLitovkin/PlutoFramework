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

        await nftOwnedListView.LoadAsync(client, token);

		((ToJoinDaoViewModel)toJoinDaoView.BindingContext).NftCount = (uint)((NftOwnedListViewModel)nftOwnedListView.BindingContext).Items.Count();
    }

    public void SetEmpty()
    {
        ((NftOwnedListViewModel)nftOwnedListView.BindingContext).Loading = false;

        ((ToJoinDaoViewModel)toJoinDaoView.BindingContext).NftCount = (uint)((NftOwnedListViewModel)nftOwnedListView.BindingContext).Items.Count();
    }

    public async Task LoadAsync(CancellationToken token)
    {
        await ((NftOwnedListViewModel)nftOwnedListView.BindingContext).LoadSavedNftsAsync();

        ((ToJoinDaoViewModel)toJoinDaoView.BindingContext).NftCount = (uint)((NftOwnedListViewModel)nftOwnedListView.BindingContext).Items.Count();
    }
}