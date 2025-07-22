using PlutoFramework.Components.WebView;
using PlutoFramework.Templates.PageTemplate;
using UniqueryPlus.External;

namespace PlutoFramework.Components.Nft;

public partial class CollectionDetailPage : PageTemplate
{
    private CollectionDetailViewModel viewModel;
    public CollectionDetailPage(CollectionDetailViewModel viewModel)
    {
        InitializeComponent();

        this.viewModel = viewModel;

        BindingContext = viewModel;
    }

    private async void OnUniqueClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new WebViewPage(((IUniqueMarketplaceLink)viewModel.CollectionBase).UniqueMarketplaceLink));
    }

    private async void OnKodaClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new WebViewPage(((IKodaLink)viewModel.CollectionBase).KodaLink));
    }
}