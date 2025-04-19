using PlutoFramework.Components.Balance;
using PlutoFramework.Model.HydraDX;
using PlutoFramework.Model;

namespace PlutoFramework.Components.XcavateProperty;

public partial class OwnedPropertiesListView : ContentView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public OwnedPropertiesListView()
	{
		InitializeComponent();

		BindingContext = new OwnedPropertiesListViewModel();
	}
    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (client.Endpoint.Key != Constants.EndpointEnum.XcavatePaseo)
        {
            return;
        }

        if (!Preferences.ContainsKey(PreferencesModel.PUBLIC_KEY))
        {
            return;
        }

        await ((OwnedPropertiesListViewModel)BindingContext).InitialLoadAsync(token);
    }

    public void SetEmpty()
    {
        ((OwnedPropertiesListViewModel)BindingContext).Loading = false;
    }
}