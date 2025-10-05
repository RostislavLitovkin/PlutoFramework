using PlutoFramework.Components.CustomLayouts;
using PlutoFramework.Templates.PageTemplate;

namespace PlutoFramework.Components.Settings;

public partial class DeveloperSettingsPage : PageTemplate
{
	public DeveloperSettingsPage()
	{
        InitializeComponent();

        BindingContext = new DeveloperSettingsViewModel();
    }

    private async void OnCreateCustomLayoutsClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new CustomLayoutsPage());
    }
}