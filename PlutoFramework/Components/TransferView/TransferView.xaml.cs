using PlutoFramework.Model;
using PlutoFramework.Components.AssetSelect;
using Substrate.NetApi.Model.Extrinsics;
using System.Numerics;
using PlutoFramework.Types;
using PlutoFramework.Constants;
using PlutoFramework.Components.TransactionAnalyzer;
using Microsoft.Maui.Controls.PlatformConfiguration;
using PlutoFramework.Components.NetworkSelect;

namespace PlutoFramework.Components.TransferView;

public partial class TransferView : ContentView
{
    public TransferView()
    {
        InitializeComponent();

        var viewModel = DependencyService.Get<TransferViewModel>();

        BindingContext = viewModel;
    }

    async void SignAndTransferClicked(System.Object sender, System.EventArgs e)
    {
        // Send the actual transaction

        var viewModel = DependencyService.Get<TransferViewModel>();

        errorLabel.Text = "";

        var clientExt = await Model.SubstrateClientModel.GetMainSubstrateClientAsync(CancellationToken.None);

        var client = clientExt.SubstrateClient;

        try
        {
            var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();

            decimal tempAmount;
            BigInteger amount;
            if (decimal.TryParse(viewModel.Amount, out tempAmount))
            {
                amount = (BigInteger)(tempAmount * (decimal)Math.Pow(10, assetSelectButtonViewModel.Decimals));

                Console.WriteLine(assetSelectButtonViewModel.Decimals);
            }
            else
            {
                errorLabel.Text = "Invalid amount value";
                return;
            }

            Method transfer = assetSelectButtonViewModel.SelectedAssetKey switch
            {
                (EndpointEnum endpointKey, AssetPallet.Native, _) => TransferModel.NativeTransfer(clientExt, viewModel.Address, amount),
                (EndpointEnum endpointKey, AssetPallet.Assets, BigInteger assetId) => TransferModel.AssetsTransfer(clientExt, viewModel.Address, assetId, amount),
                (EndpointEnum endpointKey, AssetPallet.Tokens, BigInteger tokenId) => TransferModel.TokensTransfer(clientExt, viewModel.Address, tokenId, amount),
                (EndpointEnum endpointKey, AssetPallet.ForeignAssets, BigInteger assetId) => TransferModel.ForeignAssetsTransfer(clientExt, viewModel.Address, assetId, amount),
                _ => throw new Exception("Not implemented for this pallet")
            };

            // Hide this layout
            viewModel.SetToDefault();

            var transactionAnalyzerConfirmationViewModel = DependencyService.Get<TransactionAnalyzerConfirmationViewModel>();

            await transactionAnalyzerConfirmationViewModel.LoadAsync(clientExt, transfer, showDAppView: false);
        }
        catch (Exception ex)
        {
            errorLabel.Text = "Exception: " + ex.Message;
            Console.WriteLine(ex);
        }
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        var viewModel = DependencyService.Get<TransferViewModel>();

        viewModel.SetToDefault();
    }
}
