using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);

namespace PlutoFramework.Components.Nft;

public partial class NftListPage : PageTemplate
{
	public NftListPage(BaseListViewModel<NftKey, NftWrapper> bindingContext)
	{
        InitializeComponent();

        BindingContext = bindingContext;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ((BaseListViewModel<NftKey, NftWrapper>)this.BindingContext).InitialLoadAsync(CancellationToken.None);
    }
}