﻿using PlutoFramework.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using PlutoFramework.Types;

namespace PlutoFramework.Components.AssetSelect
{
	public class AssetSelect : Asset
	{
		public bool IsSelected { get; set; }
		public (string, string) ChainIcons { get; set; }
	}

	public partial class AssetSelectViewModel : ObservableObject, IPopup
    {
		[ObservableProperty]
		private bool isVisible;

		[ObservableProperty]
		private ObservableCollection<AssetSelect> assets = new ObservableCollection<AssetSelect>();

        public AssetSelectViewModel()
		{
			isVisible = false;
		}

		public void Appear()
		{
			IsVisible = true;

			var assetSelectButtonViewModel = DependencyService.Get<AssetSelectButtonViewModel>();

            List<AssetSelect> tempAssets = new List<AssetSelect>();

			foreach(var valuePair in Model.AssetsModel.AssetsDict)
			{
				if (!SubstrateClientModel.Clients.ContainsKey(valuePair.Key.Item1))
				{
					continue;
				}

				var a = valuePair.Value;

				if (a.Amount == 0)
                {
                    continue;
                }

                // Ignore reserved and frozen assets
                if (!(a.Pallet == AssetPallet.Native || a.Pallet == AssetPallet.Assets || a.Pallet == AssetPallet.Tokens))
                {
                    continue;
                }

                bool isSelected = assetSelectButtonViewModel.SelectedAssetKey == (a.Endpoint.Key, a.Pallet, a.AssetId);

                tempAssets.Add(new AssetSelect
				{
					Amount = a.Amount,
					UsdValue = a.UsdValue,
					ChainIcon = a.ChainIcon,
					DarkChainIcon = a.DarkChainIcon,
					ChainIcons = (a.ChainIcon, a.DarkChainIcon),
					Pallet = a.Pallet,
					AssetId = a.AssetId,
					Endpoint = a.Endpoint,
					Symbol = a.Symbol,
					IsSelected = isSelected,
					Decimals = a.Decimals,
                });
			}

            Assets = new ObservableCollection<AssetSelect>(tempAssets);
        }
	}
}

