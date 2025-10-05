using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.CustomLayouts;

public partial class AddCustomItemPage : PageTemplate
{
	private CustomLayoutsViewModel customLayoutsViewModel;

    public AddCustomItemPage(CustomLayoutsViewModel customLayoutsViewModel)
	{
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
