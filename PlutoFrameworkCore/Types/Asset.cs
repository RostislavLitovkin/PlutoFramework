using System;
using System.Numerics;
using PlutoFramework.Constants;

namespace PlutoFramework.Types
{
    public class AssetMetadata : ICloneable
    {
        public string Symbol { get; set; }
        public string ChainIcon { get; set; }
        public string DarkChainIcon { get; set; }
        public Endpoint Endpoint { get; set; }
        public AssetPallet Pallet { get; set; }
        public BigInteger AssetId { get; set; }
        public int Decimals { get; set; }

        public object Clone()
        {
            return new AssetMetadata
            {
                Symbol = Symbol,
                ChainIcon = ChainIcon,
                DarkChainIcon = DarkChainIcon,
                Endpoint = Endpoint,
                Pallet = Pallet,
                AssetId = AssetId,
                Decimals = Decimals
            };
        }

        public Asset ToAsset()
        {
            return new Asset
            {
                Symbol = Symbol,
                ChainIcon = ChainIcon,
                DarkChainIcon = DarkChainIcon,
                Endpoint = Endpoint,
                Pallet = Pallet,
                AssetId = AssetId,
                Decimals = Decimals,
                Amount = 0,
                UsdValue = 0
            };
        }
    }
	public class Asset : AssetMetadata
	{
        public double Amount { get; set; }
        public double UsdValue { get; set; }
    }

    public enum AssetPallet
    {
        Native,
        NativeReserved,
        NativeFrozen,
        Assets,
        AssetsReserved,
        AssetsFrozen,
        ForeignAssets,
        ForeignAssetsReserved,
        ForeignAssetsFrozen,
        Tokens,
        TokensReserved,
        TokensFrozen,
    }

    public static class AssetPalletModel
    {
        public static AssetPallet ToBaseAssetPallet(this AssetPallet pallet) => pallet switch
        {
            AssetPallet.Native => AssetPallet.Native,
            AssetPallet.NativeReserved => AssetPallet.Native,
            AssetPallet.NativeFrozen => AssetPallet.Native,

            AssetPallet.Assets => AssetPallet.Assets,
            AssetPallet.AssetsReserved => AssetPallet.Assets,
            AssetPallet.AssetsFrozen => AssetPallet.Assets,

            AssetPallet.ForeignAssets => AssetPallet.ForeignAssets,
            AssetPallet.ForeignAssetsReserved => AssetPallet.ForeignAssets,
            AssetPallet.ForeignAssetsFrozen => AssetPallet.ForeignAssets,

            AssetPallet.Tokens => AssetPallet.Tokens,
            AssetPallet.TokensReserved => AssetPallet.Tokens,
            AssetPallet.TokensFrozen => AssetPallet.Tokens,

            _ => throw new ArgumentOutOfRangeException(nameof(pallet), pallet, "Unknown AssetPallet")
        };
    }
}

