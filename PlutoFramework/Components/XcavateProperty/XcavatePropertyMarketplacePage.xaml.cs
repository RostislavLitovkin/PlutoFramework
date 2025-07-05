namespace PlutoFramework.Components.XcavateProperty;

using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);

public partial class XcavatePropertyMarketplacePage : ContentPage
{
    public XcavatePropertyMarketplacePage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        var viewModel = DependencyService.Get<XcavatePropertyMarketplaceViewModel>();
        BindingContext = viewModel;

        viewModel.InitialLoadAsync(CancellationToken.None);
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {

    }
}
