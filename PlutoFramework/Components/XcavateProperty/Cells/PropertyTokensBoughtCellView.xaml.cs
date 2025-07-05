using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;
using UniqueryPlus.Nfts;

namespace PlutoFramework.Components.XcavateProperty.Cells;

public partial class PropertyTokensBoughtCellView : ContentView, ISetEmptyView, ISubstrateClientLoadableAsyncView
{
	public PropertyTokensBoughtCellView()
	{
		InitializeComponent();
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

        cell.Value = XcavateOwnedPropertiesModel.GetTotalPropertiesOwned().ToString();
    }

    public void SetEmpty()
    {
        cell.Value = XcavateOwnedPropertiesModel.GetTotalPropertiesOwned().ToString();
    }
}