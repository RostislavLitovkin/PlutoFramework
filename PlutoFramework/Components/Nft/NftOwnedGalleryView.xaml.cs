namespace PlutoFramework.Components.Nft;

public partial class NftOwnedGalleryView : ContentView, ILocalLoadableAsyncView
{
	public NftOwnedGalleryView()
	{
		InitializeComponent();

		BindingContext = new NftOwnedGalleryViewModel();
	}

	public async Task LoadAsync(CancellationToken token)
    {
        await (BindingContext as NftOwnedGalleryViewModel).LoadSavedNftsAsync();
    }
}