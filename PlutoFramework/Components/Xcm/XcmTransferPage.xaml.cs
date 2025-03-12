using System.Numerics;
using Microsoft.Maui.Controls.Shapes;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;

namespace PlutoFramework.Components.Xcm;

public partial class XcmTransferPage : ContentPage
{
    public XcmTransferPage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        var viewModel = DependencyService.Get<XcmTransferViewModel>();

        BindingContext = viewModel;

        InitializeComponent();
    }

    async void OnSignAndTransferClicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            var viewModel = DependencyService.Get<XcmTransferViewModel>();

            var popupViewModel = DependencyService.Get<XcmNetworkSelectPopupViewModel>();

            var originEndpoint = Endpoints.GetEndpointDictionary[popupViewModel.OriginKey];

            string bestWebSecket = await WebSocketModel.GetFastestWebSocketAsync(originEndpoint.URLs);

            PlutoFrameworkSubstrateClient clientExt = new PlutoFrameworkSubstrateClient(
                originEndpoint,
                new Uri(bestWebSecket),
                ChargeTransactionPayment.Default()
            );

            Console.WriteLine("Origin key: " + popupViewModel.OriginKey);
            Console.WriteLine("Destination key: " + popupViewModel.DestinationKey);

            await clientExt.ConnectAndLoadMetadataAsync();

            var client = clientExt.SubstrateClient;

            Method transferMethod = XcmTransferModel.XcmTransfer(
                 clientExt,
                 originEndpoint,
                 Endpoints.GetEndpointDictionary[popupViewModel.DestinationKey],
                 KeysModel.GetSubstrateKey(),

                 // TODO Add proper decimal management
                 (BigInteger)viewModel.Amount
            );

            var account = await KeysModel.GetAccountAsync();

            if (account is null)
            {
                return;
            }

            string extrinsicId = await clientExt.SubmitExtrinsicAsync(transferMethod, account, token: CancellationToken.None);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
