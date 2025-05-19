using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Constants;
using PlutoFramework.Types;

using AssetKey = (PlutoFramework.Constants.EndpointEnum, PlutoFramework.Types.AssetPallet, System.Numerics.BigInteger);
using PlutoFramework.Model;

namespace PlutoFramework.Components.AssetSelect
{
	public partial class AssetSelectButtonViewModel : ObservableObject
	{
		[ObservableProperty]
		private ImageSource chainIcon;

		private string symbol;
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
        public int Decimals { get; set; }

		/// <summary>
		/// Default native coin
		/// </summary>
        public AssetSelectButtonViewModel()
		{
			var key = EndpointsModel.GetSelectedEndpointKeys().First();
			var endpoint = Endpoints.GetEndpointDictionary[key];

			ChainIcon = endpoint.Icon;
			Symbol = endpoint.Unit;
			SelectedAssetKey = (key, AssetPallet.Native, 0);
			Decimals = endpoint.Decimals;

            var assetInputViewModel = DependencyService.Get<AssetInputViewModel>();
            assetInputViewModel.CurrencyChanged(endpoint.Unit);
        }

        /// <summary>
        /// Default any asset according to the asset key
        /// </summary>
        public AssetSelectButtonViewModel(IEnumerable<AssetKey> defaultAssetKeys)
        {
			var defaultAsset = AssetsModel.GetFirstOwnedAsset(defaultAssetKeys);

            ChainIcon = defaultAsset.ChainIcon;
			Symbol = defaultAsset.Symbol;
            SelectedAssetKey = (defaultAsset.Endpoint.Key, defaultAsset.Pallet, defaultAsset.AssetId);
            Decimals = defaultAsset.Decimals;

            var assetInputViewModel = DependencyService.Get<AssetInputViewModel>();
            assetInputViewModel.CurrencyChanged(defaultAsset.Symbol);
        }
    }
}

