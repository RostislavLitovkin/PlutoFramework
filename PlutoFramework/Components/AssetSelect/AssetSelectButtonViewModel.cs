﻿using CommunityToolkit.Mvvm.ComponentModel;
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
	}
}

