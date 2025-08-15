﻿using PlutoFramework.Constants;
using PlutoFramework.Model.AjunaExt;
using PlutoFramework.Model.Xcavate;
using PlutoFramework.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Numerics;
using UniqueryPlus;
using UniqueryPlus.Nfts;
using AssetKey = (PlutoFramework.Constants.EndpointEnum, PlutoFramework.Types.AssetPallet, System.Numerics.BigInteger);
using NftKey = (UniqueryPlus.NftTypeEnum, System.Numerics.BigInteger, System.Numerics.BigInteger);
using XcavatePropertyKey = (PlutoFramework.Constants.EndpointEnum, uint);

namespace PlutoFramework.Model
{
    public enum ExtrinsicResult
    {
        Unknown,
        Success,
        Failed,
    }

    public enum NftOperation
    {
        // Has to be there due to binding
        None,

        Sent,
        Received,
    }

    public class TransactionAnalyzerModel
    {
        public static ExtrinsicResult GetExtrinsicResult(IEnumerable<ExtrinsicEvent> events) {
            if (events.Count() == 0)
                return ExtrinsicResult.Unknown;
            else
                return events.Last() switch
                {
                    ExtrinsicEvent { PalletName: "System", EventName: "ExtrinsicSuccess" } => ExtrinsicResult.Success,
                    ExtrinsicEvent { PalletName: "System", EventName: "ExtrinsicFailed" } => ExtrinsicResult.Failed,
                    _ => ExtrinsicResult.Unknown,
                };
        }

        public static string GetExtrinsicFailedMessage(IEnumerable<ExtrinsicEvent> events) => events.Last() switch
        {
            ExtrinsicEvent { PalletName: "System", EventName: "ExtrinsicFailed" } => events.Last().Parameters[0].Value,
            _ => string.Empty,
        };

        /// <summary>
        /// Analyze the events and return the currency changes for each address
        /// </summary>
        /// <returns></returns>
        public static async Task<Dictionary<string, Dictionary<AssetKey, Asset>>> AnalyzeCurrencyChangesInEventsAsync(
            SubstrateClientExt client,
            IEnumerable<ExtrinsicEvent> events,
            Endpoint endpoint,
            CancellationToken token,
            Dictionary<string, Dictionary<AssetKey, Asset>>? existingCurrencyChanges = null)
        {
            var result = existingCurrencyChanges ?? new Dictionary<string, Dictionary<AssetKey, Asset>>();

            foreach (var e in events)
            {
                IEnumerable<(string, AssetKey, BigInteger)> evaluated = e switch
                {
                    // Balances
                    ExtrinsicEvent { PalletName: "Balances", EventName: "Transfer" } => [
                        // From negative
                        (e.Parameters[0].Value, (endpoint.Key, AssetPallet.Native, 0), -BigInteger.Parse(e.Parameters[2].Value)),
                        // To positive
                        (e.Parameters[1].Value, (endpoint.Key, AssetPallet.Native, 0), BigInteger.Parse(e.Parameters[2].Value))
                    ],
                    ExtrinsicEvent { PalletName: "Balances", EventName: "Deposit" } => [(e.Parameters[0].Value, (endpoint.Key, AssetPallet.Native, 0), BigInteger.Parse(e.Parameters[1].Value))],
                    ExtrinsicEvent { PalletName: "Balances", EventName: "Withdraw" } => [(e.Parameters[0].Value, (endpoint.Key, AssetPallet.Native, 0), -BigInteger.Parse(e.Parameters[1].Value))],
                    ExtrinsicEvent { PalletName: "Balances", EventName: "Minted" } => [(e.Parameters[0].Value, (endpoint.Key, AssetPallet.Native, 0), BigInteger.Parse(e.Parameters[1].Value))],
                    ExtrinsicEvent { PalletName: "Balances", EventName: "Burned" } => [(e.Parameters[0].Value, (endpoint.Key, AssetPallet.Native, 0), -BigInteger.Parse(e.Parameters[1].Value))],

                    // Tokens
                    ExtrinsicEvent { PalletName: "Tokens", EventName: "Transfer" } => [
                        // From negative
                        (e.Parameters[1].Value, (endpoint.Key, AssetPallet.Tokens, BigInteger.Parse(e.Parameters[0].Value)), -BigInteger.Parse(e.Parameters[3].Value)),
                        // To positive
                        (e.Parameters[2].Value, (endpoint.Key, AssetPallet.Tokens, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[3].Value))
                    ],
                    ExtrinsicEvent { PalletName: "Tokens", EventName: "Deposited" } => [(e.Parameters[1].Value, (endpoint.Key, AssetPallet.Tokens, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[2].Value))],
                    ExtrinsicEvent { PalletName: "Tokens", EventName: "Withdrawn" } => [(e.Parameters[1].Value, (endpoint.Key, AssetPallet.Tokens, BigInteger.Parse(e.Parameters[0].Value)), -BigInteger.Parse(e.Parameters[2].Value))],

                    // Assets
                    ExtrinsicEvent { PalletName: "Assets", EventName: "Transferred" } => [
                        // From negative
                        (e.Parameters[1].Value, (endpoint.Key, AssetPallet.Assets, BigInteger.Parse(e.Parameters[0].Value)), -BigInteger.Parse(e.Parameters[3].Value)),
                        // To positive
                        (e.Parameters[2].Value, (endpoint.Key, AssetPallet.Assets, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[3].Value))
                    ],
                    ExtrinsicEvent { PalletName: "Assets", EventName: "Issued" } => [(e.Parameters[1].Value, (endpoint.Key, AssetPallet.Assets, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[2].Value))],
                    ExtrinsicEvent { PalletName: "Assets", EventName: "Burned" } => [(e.Parameters[1].Value, (endpoint.Key, AssetPallet.Assets, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[2].Value))],
                    ExtrinsicEvent { PalletName: "AssetsFreezer", EventName: "Frozen" } => [(e.Parameters[0].Value, (endpoint.Key, AssetPallet.AssetsFrozen, BigInteger.Parse(e.Parameters[1].Value)), -BigInteger.Parse(e.Parameters[2].Value) * 1_000_000)],// Has to be * 10^6 on Xcavate blockchain

                    // ForeignAssets
                    ExtrinsicEvent { PalletName: "ForeignAssets", EventName: "Transferred" } => [
                        // From negative
                        (e.Parameters[1].Value, (endpoint.Key, AssetPallet.ForeignAssets, BigInteger.Parse(e.Parameters[0].Value)), -BigInteger.Parse(e.Parameters[3].Value)),
                        // To positive
                        (e.Parameters[2].Value, (endpoint.Key, AssetPallet.ForeignAssets, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[3].Value))
                    ],
                    ExtrinsicEvent { PalletName: "ForeignAssets", EventName: "Issued" } => [(e.Parameters[1].Value, (endpoint.Key, AssetPallet.ForeignAssets, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[2].Value))],
                    ExtrinsicEvent { PalletName: "ForeignAssets", EventName: "Burned" } => [(e.Parameters[1].Value, (endpoint.Key, AssetPallet.ForeignAssets, BigInteger.Parse(e.Parameters[0].Value)), BigInteger.Parse(e.Parameters[2].Value))],

                    // Fees
                    ExtrinsicEvent { PalletName: "TransactionPayment", EventName: "TransactionFeePaid" } => [("fee", (endpoint.Key, AssetPallet.Native, 0), -BigInteger.Parse(e.Parameters[1].Value) - BigInteger.Parse(e.Parameters[2].Value))],
                    ExtrinsicEvent { PalletName: "XcmPallet", EventName: "FeesPaid" } => EvaluateXcmPalletFeesPaid(e, endpoint),

                    // Handle more events ...
                    _ => []
                };

                foreach (var (address, key, amount) in evaluated)
                {
                    if (!result.ContainsKey(address))
                    {
                        result[address] = new Dictionary<AssetKey, Asset>();
                    }

                    if (!result[address].ContainsKey(key))
                    {
                        result[address][key] = key.Item2 switch
                        {
                            AssetPallet.Native => new Asset
                            {
                                Amount = 0,
                                Pallet = key.Item2,
                                Symbol = endpoint.Unit,
                                ChainIcon = endpoint.Icon,
                                DarkChainIcon = endpoint.DarkIcon,
                                AssetId = key.Item3,
                                Endpoint = endpoint,
                                Decimals = endpoint.Decimals
                            },
                            _ => (await AssetsMetadataModel.GetAssetMetadataAsync(client, key.Item2, key.Item3, token)).ToAsset()
                        };
                    }

                    result[address][key].Amount += (double)amount / Math.Pow(10, result[address][key].Decimals);
                }
            }

            // Remove emptry values
            foreach (var address in result.Keys)
            {
                foreach (var assetKey in result[address].Keys)
                {
                    if (result[address][assetKey].Amount == 0)
                    {
                        result[address].Remove(assetKey);
                    }
                }

                if (result[address].Keys.Count() == 0)
                {
                    result.Remove(address);
                }
            }

            return result;
        }

        /// <summary>
        /// Analyze the events and return the nft changes for each address
        /// </summary>
        /// <returns></returns>
        public static async Task<Dictionary<string, Dictionary<NftKey, NftAssetWrapper>>> AnalyzeNftChangesInEventsAsync(
            SubstrateClientExt client,
            IEnumerable<ExtrinsicEvent> events,
            Endpoint endpoint,
            CancellationToken token,
            Dictionary<string, Dictionary<NftKey, NftAssetWrapper>>? existingNftChanges = null)
        {
            var result = existingNftChanges ?? new Dictionary<string, Dictionary<NftKey, NftAssetWrapper>>();

            var cache = new Dictionary<NftKey, NftAssetWrapper>();

            foreach (var e in events)
            {
                IEnumerable<(string, NftKey, NftOperation)> evaluated = e switch
                {
                    // Nfts
                    ExtrinsicEvent { PalletName: "Nfts", EventName: "Transferred" } => [(e.Parameters[2].Value, (GetNftTypeEnumNftsPalletForEndpoint(endpoint.Key), BigInteger.Parse(e.Parameters[0].Value), BigInteger.Parse(e.Parameters[1].Value)), NftOperation.Sent),
                                                                                        (e.Parameters[3].Value, (GetNftTypeEnumNftsPalletForEndpoint(endpoint.Key), BigInteger.Parse(e.Parameters[0].Value), BigInteger.Parse(e.Parameters[1].Value)), NftOperation.Received)],

                    // Handle more events ...
                    _ => []
                };

                foreach (var (address, key, operation) in evaluated)
                {
                    if (!result.ContainsKey(address))
                    {
                        result[address] = new Dictionary<NftKey, NftAssetWrapper>();
                    }

                    if (!cache.ContainsKey(key))
                    {
                        var nftBase = await UniqueryPlus.Nfts.NftModel.GetNftByIdAsync(client.SubstrateClient, key.Item1, key.Item2, key.Item3, token);

                        if (nftBase is null)
                        {
                            continue;
                        }

                        cache[key] = await Model.NftModel.ToNftNativeAssetWrapperAsync(nftBase, endpoint, token);
                    }

                    result[address][key] = new NftAssetWrapper
                    {
                        NftBase = cache[key].NftBase,
                        Endpoint = cache[key].Endpoint,
                        Operation = operation,
                        AssetPrice = new Asset
                        {
                            Amount = (operation == NftOperation.Sent ? -1 : 1) * (cache[key].AssetPrice?.Amount ?? 0),
                            Pallet = AssetPallet.Native,
                            Symbol = endpoint.Unit,
                            ChainIcon = endpoint.Icon,
                            DarkChainIcon = endpoint.DarkIcon,
                            AssetId = 0,
                            Endpoint = endpoint,
                            Decimals = endpoint.Decimals
                        },
                    };
                }
            }

            return result;
        }

        /// <summary>
        /// Analyze the events and return the Xcavate property changes for each address
        /// </summary>
        /// <returns></returns>
        public static async Task<Dictionary<string, Dictionary<XcavatePropertyKey, PropertyTokenOwnershipChangeInfo>>> AnalyzeXcavatePropertyChangesInEventsAsync(
            SubstrateClientExt client,
            IEnumerable<ExtrinsicEvent> events,
            Endpoint endpoint,
            CancellationToken token,
            Dictionary<string, Dictionary<XcavatePropertyKey, PropertyTokenOwnershipChangeInfo>>? existingPropertyChanges = null)
        {
            var result = existingPropertyChanges ?? new Dictionary<string, Dictionary<XcavatePropertyKey, PropertyTokenOwnershipChangeInfo>>();

            if (client.SubstrateClient is not XcavatePaseo.NetApi.Generated.SubstrateClientExt)
            {
                return result;
            }

            var cache = new Dictionary<XcavatePropertyKey, INftBase>();

            foreach (var e in events)
            {
                IEnumerable<(string, XcavatePropertyKey, XcavatePropertyOperation, uint)> evaluated = e switch
                {
                    // Nfts
                    ExtrinsicEvent { PalletName: "NftMarketplace", EventName: "PropertyTokenBought" } => [(e.Parameters[2].Value, (endpoint.Key, uint.Parse(e.Parameters[0].Value)), XcavatePropertyOperation.Buy, uint.Parse(e.Parameters[3].Value))],

                    // Handle more events ...
                    _ => []
                };

                foreach (var (address, key, operation, amount) in evaluated)
                {
                    if (!result.ContainsKey(address))
                    {
                        result[address] = new Dictionary<XcavatePropertyKey, PropertyTokenOwnershipChangeInfo>();
                    }

                    if (!cache.ContainsKey(key))
                    {
                        var nftBase = await PropertyMarketplaceModel.GetPropertyByIdAsync((XcavatePaseo.NetApi.Generated.SubstrateClientExt)client.SubstrateClient, key.Item2, token);

                        if (nftBase is null)
                        {
                            continue;
                        }

                        cache[key] = nftBase;
                    }

                    result[address][key] = new PropertyTokenOwnershipChangeInfo
                    {
                        NftBase = cache[key],
                        Operation = operation,
                        Amount = amount,
                        Favourite = false
                    };
                }
            }

            return result;
        }

        public static NftTypeEnum GetNftTypeEnumNftsPalletForEndpoint(EndpointEnum key)
        {
            return key switch
            {
                EndpointEnum.PolkadotAssetHub => NftTypeEnum.PolkadotAssetHub_NftsPallet,
                EndpointEnum.KusamaAssetHub => NftTypeEnum.KusamaAssetHub_NftsPallet,
                _ => throw new NotImplementedException()
            };
        }

        private static IEnumerable<(string, AssetKey, BigInteger)> EvaluateXcmPalletFeesPaid(ExtrinsicEvent e, Endpoint endpoint)
        {
            var feeAssets = new Polkadot.NetApi.Generated.Model.staging_xcm.v4.asset.Assets();
            int p = 0;
            feeAssets.Decode(e.Parameters[1].EncodedValue, ref p);

            return feeAssets.Value.Value.Select((asset) =>
            {
                var assetKey = XcmModel.GetAssetFromXcmLocation(asset.Id.Value, endpoint);

                if (assetKey == null)
                {
                    // Bad
                    return ("fee", (endpoint.Key, AssetPallet.Native, (BigInteger)0), 0);
                }

                return ("fee", (endpoint.Key, AssetPallet.Native, (BigInteger)0), -(BigInteger)((BaseCom<U128>)asset.Fun.Value2).Value);
            });
        }
    }
}
