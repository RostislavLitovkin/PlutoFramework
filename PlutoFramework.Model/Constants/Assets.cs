using PlutoFramework.Constants;
using System.Collections.ObjectModel;

namespace PlutoFramework.Model.Constants
{
    public static class Assets
    {
        public static string GetAssetIcon(string assetSymbol)
        {
            var lowercaseAssetSymbol = assetSymbol.ToLower();

            if(AssetIcons.ContainsKey(lowercaseAssetSymbol))
            {
                return AssetIcons[lowercaseAssetSymbol];
            }

            return "unknown.png";
        } 

        public static readonly ReadOnlyDictionary<string, string> AssetIcons = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>()
        {
            { "usdc", "usdc.png" },
            { "usdt", "usdt.png" },
            { "dot", "polkadot.png" },
            { "ksm", "kusama.png" },
            { "xcav", "xcavate.png" },
            { "hdx", "hydration.png" },
            { "kilt", "kilt.png" },
            { "glmr", "moonbeam.png" },
            { "ajun", "ajuna.png" },
        });
    }
}
