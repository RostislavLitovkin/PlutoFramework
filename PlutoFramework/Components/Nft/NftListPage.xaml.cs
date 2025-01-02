using PlutoFramework.Model;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);

namespace PlutoFramework.Components.Nft;

public partial class NftListPage : ContentPage
{
	public NftListPage(BaseListViewModel<NftKey, NftWrapper> bindingContext)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = bindingContext;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ((BaseListViewModel<NftKey, NftWrapper>)this.BindingContext).InitialLoadAsync(CancellationToken.None);
    }
}