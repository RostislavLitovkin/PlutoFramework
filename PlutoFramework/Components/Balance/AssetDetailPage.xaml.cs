namespace PlutoFramework.Components.Balance
{
    public partial class AssetDetailPage : ContentPage
    {
        public AssetDetailPage(AssetDetailViewModel viewModel)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetNavBarIsVisible(this, false);

            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}