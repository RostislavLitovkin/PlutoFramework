using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Types;

namespace PlutoFramework.Components.Balance
{
    public partial class UsdBalanceViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<AssetInfo> assets = new ObservableCollection<AssetInfo>();

        [ObservableProperty]
        private string usdSum = "Loading";

        [ObservableProperty]
        private bool reloadIsVisible = false;

        [RelayCommand]
        private async Task ReloadAsync()
        {
            if (!KeysModel.HasSubstrateKey())
            {
                return;
            }

            CancellationToken token = CancellationToken.None;

            UsdSum = "Loading";

            ReloadIsVisible = false;

            
            foreach (var client in Model.SubstrateClientModel.Clients.Values)
            {
                await Model.AssetsModel.GetBalanceAsync(await client, KeysModel.GetSubstrateKey(), token, true);

                UpdateBalances();
            }

            ReloadIsVisible = true;
        }
        public void UpdateBalances()
        {
            var tempAssets = new ObservableCollection<AssetInfo>();

            foreach (Asset a in Model.AssetsModel.AssetsDict.Values)
            {
                if (a.Amount > 0 || a.Pallet == AssetPallet.Native)
                {
                    tempAssets.Add(new AssetInfo
                    {
                        Amount = String.Format("{0:0.00}", a.Amount),
                        Symbol = a.Symbol,
                        UsdValue = ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location) + (a.UsdValue > 0 ? String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * a.UsdValue) : "~"),
                        ChainIcon = Application.Current.UserAppTheme != AppTheme.Dark ? a.ChainIcon : a.DarkChainIcon,
                        IsReserved = a.Pallet == AssetPallet.NativeReserved || a.Pallet == AssetPallet.AssetsReserved || a.Pallet == AssetPallet.TokensReserved,
                        IsFrozen = a.Pallet == AssetPallet.NativeFrozen || a.Pallet == AssetPallet.AssetsFrozen || a.Pallet == AssetPallet.TokensFrozen,
                    });
                }
            }

            Assets = tempAssets;

            UsdSum = $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * Model.AssetsModel.UsdSum)}";
        }
    }

    public record AssetInfo
    {
        public required string Amount { get; set; }
        public required string Symbol { get; set; }
        public required string UsdValue { get; set; }
        public required string ChainIcon { get; set; }
        public required bool IsReserved { get; set; }
        public required bool IsFrozen { get; set; }
    }
}

