using PlutoFramework.Model;
using PlutoFramework.Templates.PageTemplate;
using UniqueryPlus;

namespace PlutoFramework.Components.Nft;

public partial class NftMainPage : PageTemplate
{
    public NftMainPage()
    {
        InitializeComponent();

        var viewModel = new NftMainViewModel();

        BindingContext = viewModel;

        Task s = viewModel.ConnectClientsAsync(CancellationToken.None);
    }

    private async void OnClaimDiamondsClicked(object sender, EventArgs e)
    {
        CancellationToken token = CancellationToken.None;

        try
        {
            var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(Constants.EndpointEnum.Opal, token);

            var collectionBase = await UniqueryPlus.Collections.CollectionModel.GetCollectionByCollectionIdAsync(client.SubstrateClient, NftTypeEnum.Opal, 4557, CancellationToken.None);

            await NftModel.NavigateToCollectionDetailPageAsync(collectionBase, client.Endpoint, false, token);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}