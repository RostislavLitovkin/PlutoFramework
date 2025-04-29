using CommunityToolkit.Mvvm.ComponentModel;
using PlutoFramework.Components.Balance;
using PlutoFramework.Model;
using PlutoFramework.Model.Currency;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.Types;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UniqueryPlus.Nfts;
using AssetKey = (PlutoFramework.Constants.EndpointEnum, PlutoFramework.Types.AssetPallet, System.Numerics.BigInteger);
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using XcavatePropertyKey = (PlutoFramework.Constants.EndpointEnum, uint);

namespace PlutoFramework.Components.TransactionAnalyzer
{
    public partial class AnalyzedOutcomeViewModel : ObservableObject, ISetToDefault
    {

        [ObservableProperty]
        private ObservableCollection<AssetInfoExpanded> assets = new ObservableCollection<AssetInfoExpanded>();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NftsIsVisible))]
        private ObservableCollection<NftAssetWrapperExpanded> nfts = new ObservableCollection<NftAssetWrapperExpanded>();

        public bool NftsIsVisible => Nfts.Count() > 0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(XcavatePropertiesIsVisible))]
        private ObservableCollection<PropertyTokenOwnershipChangeInfo> xcavateProperties = new ObservableCollection<PropertyTokenOwnershipChangeInfo>();

        public bool XcavatePropertiesIsVisible => XcavateProperties.Count() > 0;

        [ObservableProperty]
        private string loading = "Loading";

        public void UpdateAssetChanges(Dictionary<string, Dictionary<AssetKey, Asset>> assetChanges)
        {
            var tempAssets = new ObservableCollection<AssetInfoExpanded>();

            var walletAddress = Model.KeysModel.GetSubstrateKey();

            if (!assetChanges.ContainsKey(walletAddress))
            {
                return;
            }

            foreach (Asset a in assetChanges[walletAddress].Values)
            {
                Console.WriteLine(a.Symbol);

                double spotPrice = Model.HydraDX.Sdk.GetSpotPrice(a.Symbol);
                a.UsdValue = a.Amount * spotPrice;
                tempAssets.Add(new AssetInfoExpanded
                {
                    Amount = a.Amount switch
                    {
                        > 0 => "+" + String.Format("{0:0.00}", a.Amount),
                        _ => String.Format("{0:0.00}", a.Amount)
                    },
                    Symbol = a.Symbol,
                    UsdValue = a.UsdValue switch
                    {
                        > 0 => $"+{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * a.UsdValue)}",
                        _ => $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * a.UsdValue)}",
                    },
                    UsdColor = a.UsdValue switch
                    {
                        > 0 => Colors.Green,
                        < 0 => Colors.Red,
                        _ => Colors.Gray,
                    },
                    ChainIcon = Application.Current.UserAppTheme != AppTheme.Dark ? a.ChainIcon : a.DarkChainIcon,
                    IsFrozen = false,
                    IsReserved = false,
                });

            }

            Assets = tempAssets;
        }

        public void UpdateNftChanges(Dictionary<string, Dictionary<NftKey, NftAssetWrapper>> nftChanges)
        {
            var tempNfts = new ObservableCollection<NftAssetWrapperExpanded>();

            var walletAddress = Model.KeysModel.GetSubstrateKey();

            if (!nftChanges.ContainsKey(walletAddress))
            {
                return;
            }

            foreach (var nft in nftChanges[walletAddress].Values)
            {
                double spotPrice = Model.HydraDX.Sdk.GetSpotPrice(nft.AssetPrice.Symbol);
                nft.AssetPrice.UsdValue = nft.AssetPrice.Amount * spotPrice;
                tempNfts.Add(new NftAssetWrapperExpanded
                {
                    NftBase = nft.NftBase,
                    Endpoint = nft.Endpoint,
                    Favourite = nft.Favourite,
                    Price = new AssetInfoExpanded
                    {
                        IsReserved = false,
                        IsFrozen = false,
                        Amount = nft.AssetPrice.Amount switch
                        {
                            > 0 => "+" + String.Format("{0:0.00}", nft.AssetPrice.Amount),
                            _ => String.Format("{0:0.00}", nft.AssetPrice.Amount)
                        },
                        Symbol = nft.AssetPrice.Symbol,
                        UsdValue = nft.AssetPrice.UsdValue switch
                        {
                            > 0 => $"+{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * nft.AssetPrice.UsdValue)}",
                            _ => $"{ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)}{String.Format("{0:0.00}", ExchangeRateModel.GetExchangeRate("USDT", ExchangeRateModel.GetCurrencyInLocation(AppConfigurationModel.Location)) * nft.AssetPrice.UsdValue)}",
                        },
                        UsdColor = nft.Operation switch
                        {
                            NftOperation.Received => Colors.Green,
                            NftOperation.Sent => Colors.Red,
                            _ => Colors.Gray,
                        },
                        ChainIcon = Application.Current.UserAppTheme != AppTheme.Dark ? nft.AssetPrice.ChainIcon : nft.AssetPrice.DarkChainIcon,
                    },
                    Operation = nft.Operation,
                });

            }

            Nfts = tempNfts;
        }


        public async Task UpdateXcavatePropertyChanges(Dictionary<string, Dictionary<XcavatePropertyKey, PropertyTokenOwnershipChangeInfo>> propertyChanges)
        {
            var tempProperties = new ObservableCollection<PropertyTokenOwnershipChangeInfo>();

            var walletAddress = Model.KeysModel.GetSubstrateKey();

            if (!propertyChanges.ContainsKey(walletAddress))
            {
                return;
            }

            foreach (var property in propertyChanges[walletAddress].Values)
            {
                tempProperties.Add(new PropertyTokenOwnershipChangeInfo
                {
                    NftBase = (await PlutoFramework.Components.XcavateProperty.XcavatePropertyModel.ToNftWrapperAsync((XcavatePaseoNftsPalletNft)property.NftBase)).NftBase,
                    Operation = property.Operation,
                    Amount = property.Amount,
                });
            }

            XcavateProperties = tempProperties;
        }
        public void SetToDefault()
        {
            Loading = "Loading";
            Assets = new ObservableCollection<AssetInfoExpanded>();
            Nfts = new ObservableCollection<NftAssetWrapperExpanded>();
            XcavateProperties = new();
        }
    }

    public record AssetInfoExpanded : AssetInfo
    {
        public Color UsdColor { get; set; }
    }
    public class NftAssetWrapperExpanded : NftWrapper
    {
        public NftOperation Operation { get; set; }
        public AssetInfoExpanded Price { get; set; }
    }
}
