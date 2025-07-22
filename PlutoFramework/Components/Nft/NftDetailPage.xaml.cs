using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Nft;

public partial class NftDetailPage : PageTemplate
{
    public NftDetailPage(NftDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}