﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model;
using PlutoFramework.Model.HydrationModel;

namespace PlutoFramework.Components.HydraDX
{
    public partial class OmnipoolLiquidityViewModel : ObservableObject
	{
		[ObservableProperty]
		private ObservableCollection<AssetLiquidityInfo> assets;

        [ObservableProperty]
        private ObservableCollection<AssetLiquidityInfo> assetsLiquidityMining;

        [ObservableProperty]
		private string usdSum;

        public OmnipoolLiquidityViewModel()
		{
			usdSum = "Loading";
		}

        public async Task GetOmnipoolLiquidityAsync(Hydration.NetApi.Generated.SubstrateClientExt client, CancellationToken token)
        {
            UsdSum = "Loading";

            double tempUsdSum = 0;
            Assets = new ObservableCollection<AssetLiquidityInfo>();

            var omnipoolLiquidities = await HydrationOmnipoolModel.GetOmnipoolLiquiditiesAsync(client, KeysModel.GetSubstrateKey(), token);

            var liquidityMiningInfos = await Model.HydrationModel.HydrationLiquidityMiningModel.GetOmnipoolLiquidityWithLiquidityMining(client, KeysModel.GetSubstrateKey(), token);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var omnipoolLiquidity in omnipoolLiquidities)
                {
                    double usdRatio = Model.HydraDX.Sdk.GetSpotPrice(omnipoolLiquidity.AssetId);

                    double usdValue = usdRatio * omnipoolLiquidity.Amount;

                    tempUsdSum += usdValue;

                    Assets.Add(new AssetLiquidityInfo
                    {
                        Amount = String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, omnipoolLiquidity.Amount),
                        Symbol = omnipoolLiquidity.Symbol,
                        UsdValue = String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, usdValue) + " USD",
                        LiquidityMiningInfos = []
                    });
                }

                foreach (var omnipoolLiquidity in liquidityMiningInfos)
                {
                    double usdRatio = Model.HydraDX.Sdk.GetSpotPrice(omnipoolLiquidity.AssetId);

                    double usdValue = usdRatio * omnipoolLiquidity.Amount;

                    tempUsdSum += usdValue;

                    Assets.Add(new AssetLiquidityInfo
                    {
                        Amount = String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, omnipoolLiquidity.Amount),
                        Symbol = omnipoolLiquidity.Symbol,
                        UsdValue = String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, usdValue) + " USD",
                        LiquidityMiningInfos = omnipoolLiquidity.LiquidityMiningInfos.Select(lm => new LiquidityMiningInfo
                        {
                            Amount = "+ " + String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, lm.RewardAmount),
                            Symbol = lm.RewardSymbol,
                            UsdValue = "+ " + String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, lm.RewardAmount * Model.HydraDX.Sdk.GetSpotPrice(lm.RewardAssetId)) + " USD",
                        }).ToList(),
                    });
                }

                UsdSum = String.Format(DefaultAppConfiguration.CURRENCY_FORMAT, tempUsdSum) + " USD";

                if (Assets.Count() == 0)
                {
                    UsdSum = "None";
                }
            });
        }
    }

	public class AssetLiquidityInfo
	{
		public string Amount { get; set; }
		public string Symbol { get; set; }
		public string UsdValue { get; set; }
        public List<LiquidityMiningInfo> LiquidityMiningInfos { get; set; }
    }

    public class LiquidityMiningInfo
    {
        public string Amount { get; set; }
        public string Symbol { get; set; }
        public string UsdValue { get; set; }
    }
}

