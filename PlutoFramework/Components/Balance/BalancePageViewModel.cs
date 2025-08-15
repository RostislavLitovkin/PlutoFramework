using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.SQLite;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.Types;
using System.Collections.ObjectModel;

namespace PlutoFramework.Components.Balance
{
    public partial class BalancePageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FirstName))]
        private XcavateUser? user;

        public string FirstName => User?.FirstName ?? "..";

        [ObservableProperty]
        private ObservableCollection<AssetInfo> assets = new ObservableCollection<AssetInfo>();

        [ObservableProperty]
        private string usdSum = "Loading";

        [ObservableProperty]
        private bool reloadIsVisible = false;

        /*[RelayCommand]
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
        }*/

        public async Task UpdateAsync()
        {
            var tempAssets = new ObservableCollection<AssetInfo>();

            foreach (var a in Model.AssetsModel.AssetsDict.Values)
            {
                if (a.Amount > 0 || a.Pallet == AssetPallet.Native)
                {
                    tempAssets.Add(new AssetInfo
                    {
                        Amount = String.Format((string)Application.Current.Resources["CurrencyFormat"], a.Amount),
                        Symbol = a.Symbol,
                        UsdValue = a.UsdValue > 0 ? a.UsdValue.ToCurrencyString() : "~",
                        ChainIcon = Application.Current.UserAppTheme != AppTheme.Dark ? a.ChainIcon : a.DarkChainIcon,
                        IsReserved = a.Pallet == AssetPallet.NativeReserved || a.Pallet == AssetPallet.AssetsReserved || a.Pallet == AssetPallet.TokensReserved,
                        IsFrozen = a.Pallet == AssetPallet.NativeFrozen || a.Pallet == AssetPallet.AssetsFrozen || a.Pallet == AssetPallet.TokensFrozen,
                    });
                }
            }

            Assets = tempAssets;

            UsdSum = Model.AssetsModel.UsdSum.ToCurrencyString();

            User = await XcavateUserDatabase.GetUserInformationAsync();
        }
    }
}
