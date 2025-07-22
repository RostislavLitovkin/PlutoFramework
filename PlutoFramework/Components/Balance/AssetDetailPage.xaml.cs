using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Balance
{
    public partial class AssetDetailPage : PageTemplate
    {
        public AssetDetailPage(AssetDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}