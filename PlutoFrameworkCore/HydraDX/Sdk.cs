using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using Hydration.NetApi.Generated.Model.sp_core.crypto;
using Hydration.NetApi.Generated.Model.pallet_omnipool.types;
using Hydration.NetApi.Generated.Model.orml_tokens;
using PlutoFramework.Constants;
using Hydration.NetApi.Generated;
using Substrate.NetApi.Model.Types.Base;

namespace PlutoFramework.Model.HydraDX
{
    public class Sdk
    {
        const int SYSTEM_ASSET_ID = 0;

        public static Dictionary<(uint?, string), HydraDXTokenInfo> Assets = new Dictionary<(uint?, string), HydraDXTokenInfo>();

        public static Dictionary<(uint?, uint), HydraDXTokenInfo> AssetsById = new Dictionary<(uint?, uint), HydraDXTokenInfo>();

        public static async Task<IEnumerable<(uint, double?)>> GetRestrospectiveSpotPricesAsync(AjunaExt.SubstrateClientExt client, Interval interval, string symbol, uint steps, CancellationToken token)
        {
            if (client is null || client.Endpoint.Key != EndpointEnum.Hydration)
            {
                Console.WriteLine("This should not have happened");
                return [];
            }

            var blocknumber = await BlockModel.GetCachedBlockNumberAsync(client, token);

            Console.WriteLine(blocknumber);

            var blocks = BlockModel.GetBlocks(interval, (uint)blocknumber, steps);

            // Can be optimised: check if it has been loaded
            await LoadRetrospectiveAssetsAsync(client, blocks, token);

            Console.WriteLine("Loaded retrospective spot prices");

            return blocks.Select(blocknumber => (blocknumber, GetSpotPrice(symbol, blocknumber)));
        }

        public static async Task LoadRetrospectiveAssetsAsync(AjunaExt.SubstrateClientExt client, IEnumerable<uint> blocks, CancellationToken token)
        {
            var tasks = blocks.Select(block => GetAssetsAsync((SubstrateClientExt)client.SubstrateClient, block, token));

            await Task.WhenAll(tasks);
        }

        public static async Task GetAssetsAsync(SubstrateClientExt client, uint? blocknumber, CancellationToken token)
        {
            try
            {
                Console.WriteLine("GetAssetsAsync");
                if (client is null)
                {
                    return;
                }

                var blockhash = blocknumber.HasValue ? (await client.Chain.GetBlockHashAsync(new BlockNumber(blocknumber.Value), token)).Value : string.Empty;

                var omnipoolAccount = new AccountId32();
                omnipoolAccount.Create(Utils.GetPublicKeyFrom(PlutoFramework.Constants.HydraDX.OMNIPOOL_ADDRESS));

                var omnipoolAssetsKeyBytes = RequestGenerator.GetStorageKeyBytesHash("Omnipool", "Assets");

                string omnipoolAssetsKeyBytesString = Utils.Bytes2HexString(omnipoolAssetsKeyBytes);
                string tokenAccountsKeyBytesString = Utils.Bytes2HexString(RequestGenerator.GetStorageKeyBytesHash("Tokens", "Accounts"));
                string assetMetadataKeyBytesString = Utils.Bytes2HexString(RequestGenerator.GetStorageKeyBytesHash("AssetRegistry", "Assets"));

                byte[] prefix = omnipoolAssetsKeyBytes;

                byte[] startKey = null;

                var storageKeys = (await client.State.GetKeysPagedAsync(prefix, 1000, startKey, string.Empty, token))
                   .Select(p => p.ToString().ToLower().Replace(Utils.Bytes2HexString(prefix).ToLower(), ""));

                if (storageKeys == null || !storageKeys.Any())
                {
                    return;
                }

                var omnipoolAssetsKeys = storageKeys.Select(p => Utils.HexToByteArray(omnipoolAssetsKeyBytesString + p.ToString())).ToList();

                var tokenAccountsKeys = storageKeys.Select(p => Utils.HexToByteArray(tokenAccountsKeyBytesString +
                    "12649b1d88771b22c15810b80fb0a1a96d6f646c6f6d6e69706f6f6c0000000000000000000000000000000000000000"
                    + Utils.Bytes2HexString(HashExtension.Hash(
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Model.HashModel.GetU32FromBlake2_128Concat(p.ToString()).Bytes
                     ), Utils.HexStringFormat.Pure))).ToList();

                var assetMetadataKeys = storageKeys.Select(p => Utils.HexToByteArray(assetMetadataKeyBytesString
                    + Utils.Bytes2HexString(HashExtension.Hash(
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                        Model.HashModel.GetU32FromBlake2_128Concat(p.ToString()).Bytes
                     ), Utils.HexStringFormat.Pure))).ToList();

                var omnipoolAssetsStorageChangeSets = (await client.State.GetQueryStorageAtAsync(omnipoolAssetsKeys, blockhash, token)).ElementAt(0).Changes;
                var tokenAccountsStorageChangeSets = (await client.State.GetQueryStorageAtAsync(tokenAccountsKeys, blockhash, token)).ElementAt(0).Changes;
                var assetMetadataStorageChangeSets = (await client.State.GetQueryStorageAtAsync(assetMetadataKeys, blockhash, token)).ElementAt(0).Changes;

                if (omnipoolAssetsStorageChangeSets != null)
                {
                    for (int i = 0; i < omnipoolAssetsStorageChangeSets.Length; i++)
                    {
                        try
                        {
                            AssetState asset = new AssetState();
                            asset.Create(omnipoolAssetsStorageChangeSets[i][1]);

                            U32 assetId = Model.HashModel.GetU32FromBlake2_128Concat(omnipoolAssetsStorageChangeSets[i][0].Substring(66));

                            if (assetId.Value != SYSTEM_ASSET_ID)
                            {
                                AccountData omnipoolTokens = new AccountData();
                                omnipoolTokens.Create(tokenAccountsStorageChangeSets[i][1]);

                                var assetMetadata = new Hydration.NetApi.Generated.Model.pallet_asset_registry.types.AssetDetails();

                                assetMetadata.Create(assetMetadataStorageChangeSets[i][1]);

                                string symbol = Model.ToStringModel.VecU8ToString(assetMetadata.Symbol.Value.Value);

                                if (Assets.ContainsKey((blocknumber, symbol)))
                                {
                                    continue;
                                }

                                double poolBalance = (double)(omnipoolTokens.Free.Value - omnipoolTokens.Frozen.Value) / Math.Pow(10, assetMetadata.Decimals.Value);
                                double hubReserveBalance = (double)(asset.HubReserve.Value) / Math.Pow(10, 12);

                                var tokenInfo = new HydraDXTokenInfo
                                {
                                    Symbol = symbol,
                                    PoolBalance = poolBalance,
                                    HubReserve = hubReserveBalance,
                                    Decimals = assetMetadata.Decimals.Value,

                                };

                                Assets.Add((blocknumber, symbol), tokenInfo);

                                AssetsById.Add((blocknumber, assetId.Value), tokenInfo);
                            }
                            else
                            {
                                Endpoint endpoint = Endpoints.GetEndpointDictionary[EndpointEnum.Hydration];

                                var omnipoolTokens = await client.SystemStorage.Account(omnipoolAccount, null, token);

                                string symbol = endpoint.Unit;

                                if (Assets.ContainsKey((blocknumber, symbol)))
                                {
                                    continue;
                                }

                                double poolBalance = (double)(omnipoolTokens.Data.Free.Value - omnipoolTokens.Data.Frozen.Value) / Math.Pow(10, endpoint.Decimals);
                                double hubReserveBalance = (double)(asset.HubReserve.Value) / Math.Pow(10, 12);

                                var tokenInfo = new HydraDXTokenInfo
                                {
                                    Symbol = symbol,
                                    PoolBalance = poolBalance,
                                    HubReserve = hubReserveBalance,
                                    Decimals = endpoint.Decimals,
                                };

                                Assets.Add((blocknumber, symbol), tokenInfo);

                                AssetsById.Add((blocknumber, assetId.Value), tokenInfo);
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ex:");
                Console.WriteLine(ex);
            }
        }

        public static double? GetSpotPrice(string tokenSymbol, uint? blocknumber = null)
        {
            if (tokenSymbol.Equals("USDC", StringComparison.CurrentCultureIgnoreCase))
            {
                return 1;
            }

            if (tokenSymbol.Equals("USDT", StringComparison.CurrentCultureIgnoreCase))
            {
                return 1;
            }

            if (tokenSymbol.Equals("USD", StringComparison.CurrentCultureIgnoreCase))
            {
                return 1;
            }

            if (tokenSymbol.Equals("XCAV", StringComparison.CurrentCultureIgnoreCase))
            {
                return 0.1;
            }

            if (!Assets.ContainsKey((blocknumber, tokenSymbol)))
            {
                return null;
            }

            if (!Assets.ContainsKey((blocknumber, PlutoFramework.Constants.HydraDX.STABLE_TOKEN)))
            {
                return null;
            }

            HydraDXTokenInfo token = Assets[(blocknumber, tokenSymbol)];
            HydraDXTokenInfo usdToken = Assets[(blocknumber, PlutoFramework.Constants.HydraDX.STABLE_TOKEN)];

            double price_a = token.HubReserve / token.PoolBalance;
            double price_b = usdToken.PoolBalance / usdToken.HubReserve;

            double result = price_a * price_b;

            return result;
        }

        public static double GetSpotPrice(uint assetId, uint? blocknumber = null)
        {
            if (!AssetsById.ContainsKey((blocknumber, assetId)))
            {
                return 2;
            }

            if (!Assets.ContainsKey((blocknumber, PlutoFramework.Constants.HydraDX.STABLE_TOKEN)))
            {

                return 5;
            }

            HydraDXTokenInfo token = AssetsById[(blocknumber, assetId)];
            HydraDXTokenInfo usdToken = Assets[(blocknumber, PlutoFramework.Constants.HydraDX.STABLE_TOKEN)];

            double price_a = token.HubReserve / token.PoolBalance;
            double price_b = usdToken.PoolBalance / usdToken.HubReserve;

            double result = price_a * price_b;

            return result;
        }
    }

    public class HydraDXTokenInfo
    {
        public double PoolBalance { get; set; }
        public double HubReserve { get; set; }
        public string Symbol { get; set; }
        public int Decimals { get; set; }
    }
}

