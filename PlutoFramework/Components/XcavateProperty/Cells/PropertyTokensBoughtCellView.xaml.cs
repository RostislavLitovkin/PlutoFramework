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

        foreach(var v in XcavateOwnedPropertiesModel.ItemsDict.Values)
        {
            Console.WriteLine("This item was found: " + v.Key);
        }

        Console.WriteLine("Total values in dict: " + XcavateOwnedPropertiesModel.ItemsDict.Values.Count());

        Console.WriteLine("Token price: " + ((INftXcavateMetadata)XcavateOwnedPropertiesModel.ItemsDict.Values.First().NftBase).XcavateMetadata.PricePerToken);

    }

    public void SetEmpty()
    {
        cell.Value = XcavateOwnedPropertiesModel.GetTotalPropertiesOwned().ToString();
    }
}