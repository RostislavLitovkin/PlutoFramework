namespace PlutoFramework.Components.XcavateProperty;

public partial class PropertyDetailPage : ContentPage
{
    public PropertyDetailPage(PropertyDetailViewModel viewModel)
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        BindingContext = viewModel;
    }
}