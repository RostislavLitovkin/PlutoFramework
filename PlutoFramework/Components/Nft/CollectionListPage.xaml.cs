using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;
using CollectionKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger);

namespace PlutoFramework.Components.Nft;

public partial class CollectionListPage : PageTemplate
{
    public CollectionListPage(BaseListViewModel<CollectionKey, CollectionWrapper> bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await ((BaseListViewModel<CollectionKey, CollectionWrapper>)this.BindingContext).InitialLoadAsync(CancellationToken.None);
    }
}