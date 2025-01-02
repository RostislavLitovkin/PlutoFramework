using PlutoFramework.Model;
using System.Collections;
using System.Collections.ObjectModel;
using UniqueryPlus;

namespace PlutoFramework.Components.Nft;

public partial class NftMainPage : ContentPage
{
    public NftMainPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

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