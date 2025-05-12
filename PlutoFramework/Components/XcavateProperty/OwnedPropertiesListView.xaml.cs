using PlutoFramework.Components.Balance;
using PlutoFramework.Model.HydraDX;
using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.XcavateProperty;

public partial class OwnedPropertiesListView : ContentView, ISubstrateClientLoadableAsyncView, ISetEmptyView
{
	public OwnedPropertiesListView()
	{
		InitializeComponent();

		BindingContext = DependencyService.Get<OwnedPropertiesListViewModel>();
    }
    public async Task LoadAsync(PlutoFrameworkSubstrateClient client, CancellationToken token)
    {
        if (client.Endpoint.Key != Constants.EndpointEnum.XcavatePaseo)
        {
            return;
        }

        if (!KeysModel.HasSubstrateKey())
        {
            return;
        }

        await XcavateOwnedPropertiesModel.LoadAsync(client, KeysModel.GetSubstrateKey(), token);

        await ((OwnedPropertiesListViewModel)BindingContext).UpdateAsync(token);
    }

    public void SetEmpty()
    {
        ((OwnedPropertiesListViewModel)BindingContext).Loading = false;
    }
}