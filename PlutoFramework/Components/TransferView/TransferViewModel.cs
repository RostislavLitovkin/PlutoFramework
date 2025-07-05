using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Components.AssetSelect;
using PlutoFramework.Components.Buttons;
using PlutoFramework.Constants;
using PlutoFramework.Model;
using PlutoFramework.Model.HydraDX;
using PlutoFramework.Types;

namespace PlutoFramework.Components.TransferView
{
    public partial class TransferViewModel : ObservableObject, IPopup, ISetToDefault
    {
        [ObservableProperty]
        private ButtonStateEnum confirmButtonState;

        private string address;

        public string Address { get => address; set { SetProperty(ref address, value); CheckCorrectInput(); } }

        [ObservableProperty]
        private string addressInput;

        private string amount;

        public string Amount { get => amount; set { Console.WriteLine("Setting amount: " + value); SetProperty(ref amount, value); CheckCorrectInput(); } }

        [ObservableProperty]
        private string fee;

        [ObservableProperty]
        private bool isVisible;

        public TransferViewModel()
        {
            SetToDefault();
        }

        public void CheckCorrectInput()
        {
            if (Address.Length == 48 && decimal.TryParse(Amount, out decimal decimalAmount) && decimalAmount > 0)
            {
                ConfirmButtonState = ButtonStateEnum.Enabled;
            }
            else
            {
                ConfirmButtonState = ButtonStateEnum.Disabled;
            }
        }

        public async Task GetFeeAsync()
        {
            Fee = "Estimated fee: Loading";

            var mainClient = await Model.SubstrateClientModel.GetMainSubstrateClientAsync(CancellationToken.None);
            if (mainClient is null || !await mainClient.IsConnectedAsync())
            {
                Fee = "Estimated fee: Failed";

                return;
            }

            var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();

            assetSelectButtonViewModel.ChangeAllowedAssets(null);

            /*try
            {
                var feeAsset = assetSelectButtonViewModel.SelectedAssetKey switch
                {
                    (EndpointEnum endpointKey, AssetPallet.Native, _) => await FeeModel.GetNativeTransferFeeAsync(mainClient),
                    (EndpointEnum endpointKey, AssetPallet.Assets, _) => await FeeModel.GetAssetsTransferFeeAsync(mainClient),
                    _ => throw new Exception("Not implemented")
                };

                Fee = FeeModel.GetEstimatedFeeString(feeAsset);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Estimated fee error: ");

                Console.WriteLine(ex);
                Fee = "Estimated fee: Unsupported";
            }*/
        }

        public void SetToDefault()
        {
            Address = "";
            AddressInput = "";
            Amount = "";
            IsVisible = false;
            Fee = "Estimated fee: Loading";
            ConfirmButtonState = ButtonStateEnum.Disabled;

            var assetInputViewModel = DependencyService.Get<AssetInputViewModel>();

            assetInputViewModel.Amount = "";
            assetInputViewModel.UsdAmount = "";
        }
    }
}

