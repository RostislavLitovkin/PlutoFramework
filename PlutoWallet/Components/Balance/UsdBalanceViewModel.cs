using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoWallet.Model;
using PlutoWallet.Types;

namespace PlutoWallet.Components.Balance
{
    public partial class UsdBalanceViewModel : ObservableObject
    {
        public bool DoNotReload { get; set; } = false;

        [ObservableProperty]
        private ObservableCollection<AssetInfo> assets;

        [ObservableProperty]
        private string usdSum;

        [ObservableProperty]
        private bool reloadIsVisible;

        public UsdBalanceViewModel()
        {
            assets = new ObservableCollection<AssetInfo>();
            usdSum = "Loading";
            reloadIsVisible = false;
        }

        [RelayCommand]
        private async Task ReloadAsync()
        {
            CancellationToken token = CancellationToken.None;
            Console.WriteLine("Reload clicked");

            UsdSum = "Loading";

            ReloadIsVisible = false;

            
            foreach (var client in Model.SubstrateClientModel.Clients.Values)
            {
                Console.WriteLine("Reload ...");
                await Model.AssetsModel.GetBalanceAsync(await client, KeysModel.GetSubstrateKey(), token, true);

                UpdateBalances();
            }

            ReloadIsVisible = true;
            Console.WriteLine("Reload Done");
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
                        UsdValue = a.UsdValue > 0 ? String.Format("{0:0.00}", a.UsdValue) + " USD" : "~ USD",
                        ChainIcon = Application.Current.UserAppTheme != AppTheme.Dark ? a.ChainIcon : a.DarkChainIcon,
                    });
                }
            }

            Assets = tempAssets;

            UsdSum = String.Format("{0:0.00}", Model.AssetsModel.UsdSum) + " USD";
        }
    }

    public class AssetInfo
    {
        public string Amount { get; set; }
        public string Symbol { get; set; }
        public string UsdValue { get; set; }
        public string ChainIcon { get; set; }
    }
}

