using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.ViewModel;

namespace PlutoFramework.View;

public partial class AddCustomItemPage : ContentPage
{
	private CustomLayoutsViewModel customLayoutsViewModel;


    public AddCustomItemPage(CustomLayoutsViewModel customLayoutsViewModel)
	{
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        InitializeComponent();

        this.customLayoutsViewModel = customLayoutsViewModel;
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
