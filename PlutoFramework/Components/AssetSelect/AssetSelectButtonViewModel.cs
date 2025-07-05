using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Constants;
using PlutoFramework.Types;

using AssetKey = (PlutoFramework.Constants.EndpointEnum, PlutoFramework.Types.AssetPallet, System.Numerics.BigInteger);
using PlutoFramework.Model;
using CommunityToolkit.Mvvm.Input;

namespace PlutoFramework.Components.AssetSelect
{
    public partial class AssetSelectButtonViewModel : ObservableObject
    {
        [ObservableProperty]
        private ImageSource chainIcon;

        private string symbol = "";
        public string Symbol
        {
            get => symbol;
            set
            {
                WidthRequest = value.Length * 13 + 50;

                SetProperty(ref symbol, value);
            }
        }

        [ObservableProperty]
        private int widthRequest;
        public AssetKey SelectedAssetKey { get; set; }
        public int Decimals { get; set; } = 0;

        private IEnumerable<AssetKey>? allowedAssetKeys = null;

        private bool checkOwnership = true;

        /// <summary>
        /// Default native coin
        /// </summary>
        public AssetSelectButtonViewModel()
        {
            ChangeAllowedAssets(null);
        }

        /// <summary>
        /// checkOwnership only works when allowedAssetKeys != null
        /// Also, you need to ensure that at lest the first allowedAsset is present in the AssetsModel.AssetsDict
        /// </summary>
        public void ChangeAllowedAssets(IEnumerable<AssetKey>? allowedAssetKeys, bool checkOwnership = true)
        {
            this.checkOwnership = checkOwnership;

            if (allowedAssetKeys == null)
            {
                SetDefault();

                return;
            }

            if (checkOwnership)
            {
                Console.WriteLine("Checking allowed asset keys: " + allowedAssetKeys.Count());

                var defaultAsset = AssetsModel.GetFirstOwnedAsset(allowedAssetKeys);

                if (defaultAsset == null)
                {
                    SetDefault();
                    return;
                }

                ChainIcon = defaultAsset.ChainIcon;
                Symbol = defaultAsset.Symbol;
                SelectedAssetKey = (defaultAsset.Endpoint.Key, defaultAsset.Pallet, defaultAsset.AssetId);
                Decimals = defaultAsset.Decimals;

                var assetInputViewModel = DependencyService.Get<AssetInputViewModel>();
                assetInputViewModel.CurrencyChanged(defaultAsset.Symbol);

                this.allowedAssetKeys = allowedAssetKeys;
            }
            else
            {
                Asset defaultAsset = AssetsModel.AssetsDict[allowedAssetKeys.First()];

                ChainIcon = defaultAsset.ChainIcon;
                Symbol = defaultAsset.Symbol;
                SelectedAssetKey = (defaultAsset.Endpoint.Key, defaultAsset.Pallet, defaultAsset.AssetId);
                Decimals = defaultAsset.Decimals;

                var assetInputViewModel = DependencyService.Get<AssetInputViewModel>();
                assetInputViewModel.CurrencyChanged(defaultAsset.Symbol);

                this.allowedAssetKeys = allowedAssetKeys;
            }
        }

        private void SetDefault()
        {
            var key = EndpointsModel.GetSelectedEndpointKeys().First();
            var endpoint = Endpoints.GetEndpointDictionary[key];

            ChainIcon = endpoint.Icon;
            Symbol = endpoint.Unit;
            SelectedAssetKey = (key, AssetPallet.Native, 0);
            Decimals = endpoint.Decimals;

            var assetInputViewModel = DependencyService.Get<AssetInputViewModel>();
            assetInputViewModel.CurrencyChanged(endpoint.Unit);

            this.allowedAssetKeys = null;
        }

        [RelayCommand]
        public void ChangeAsset()
        {
            Console.WriteLine("Change asset clicked");

            var viewModel = DependencyService.Get<AssetSelectViewModel>();

            viewModel.Appear(allowedAssetKeys, checkOwnership);
        }
    }
}

