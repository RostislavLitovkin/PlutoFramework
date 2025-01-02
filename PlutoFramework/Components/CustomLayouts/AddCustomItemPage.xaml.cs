namespace PlutoFramework.Components.CustomLayouts;

public partial class AddCustomItemPage : ContentPage
{
	private CustomLayoutsViewModel customLayoutsViewModel;


    public AddCustomItemPage(CustomLayoutsViewModel customLayoutsViewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        this.customLayoutsViewModel = customLayoutsViewModel;

        BindingContext = new AddCustomItemViewModel();
    }

    private async void OnClicked(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
		Model.CustomLayoutModel.AddComponentToSavedLayout(((CustomLayoutItemAddView)sender).ComponentId);

        customLayoutsViewModel.ComponentInfos = Model.CustomLayoutModel.ParsePlutoComponentInfos(
                    Preferences.Get("PlutoLayout",
                    Model.CustomLayoutModel.DEFAULT_PLUTO_LAYOUT)
                );

        await Navigation.PopAsync();
    }
}
