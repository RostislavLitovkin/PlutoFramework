namespace PlutoFramework.Components.Nft;

public partial class NftFavouriteGalleryView : ContentView, ILocalLoadableAsyncView
{
	public NftFavouriteGalleryView()
	{
		InitializeComponent();

        BindingContext = new NftFavouriteGalleryViewModel();

        Console.WriteLine("fav gallery exists");
    }

	public Task LoadAsync(CancellationToken token) => (BindingContext as NftFavouriteGalleryViewModel).LoadSavedNftsAsync();
    
}