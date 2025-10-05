using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyDetailPage : PageTemplate
{
    public PropertyDetailPage(PropertyDetailViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}