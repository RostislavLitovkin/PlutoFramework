using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.XcavateProperty;

public partial class XcavatePropertyMarketplacePage : PageTemplate
{
    public XcavatePropertyMarketplacePage()
    {
        InitializeComponent();

        var viewModel = DependencyService.Get<XcavatePropertyMarketplaceViewModel>();
        BindingContext = viewModel;

        viewModel.InitialLoadAsync(CancellationToken.None);
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {

    }
}
