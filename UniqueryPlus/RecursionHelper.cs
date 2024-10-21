﻿using Org.BouncyCastle.Utilities;
using Substrate.NetApi;
using System.Runtime.CompilerServices;

namespace UniqueryPlus
{
    internal class RecursionHelper
    {
        internal static async IAsyncEnumerable<T> ToIAsyncEnumerableAsync<T>(
            IEnumerable<SubstrateClient> clients,
            Func<SubstrateClient, NftTypeEnum, byte[]?, CancellationToken, Task<RecursiveReturn<T>>> getter,
            uint limit,
            [EnumeratorCancellation] CancellationToken token = default
        )
        {
            foreach (var client in clients)
            {
                foreach (var nftType in GetNftTypeForClient(client))
                {
                    byte[]? lastKey = null;

                    while (true)
                    {
                        var nfts = await getter.Invoke(client, nftType, lastKey, token);

                        foreach (var item in nfts.Items)
                        {
                            yield return item;
                        }

                        if (nfts.Items.Count() != limit)
                        {
                            break;
                        }


                        lastKey = nfts.LastKey;
                    }
                }
            }
        }
        internal static async IAsyncEnumerable<T> ToIAsyncEnumerableAsync<T>(
            IEnumerable<SubstrateClient> clients,
            Func<SubstrateClient, NftTypeEnum, int, int, CancellationToken, Task<IEnumerable<T>>> getter,
            int limit,
            [EnumeratorCancellation] CancellationToken token = default
        )
        {
            foreach (var client in clients)
            {
                foreach (var nftType in GetNftTypeForClient(client))
                {
                    int offset = 0;

                    while (true)
                    {
                        var items = await getter.Invoke(client, nftType, limit, offset, token);

                        foreach (var item in items)
                        {
                            yield return item;
                        }

                        if (items.Count() != limit)
                        {
                            break;
                        }

                        offset += items.Count();
                    }
                }
            }
        }

        internal static async IAsyncEnumerable<T> ToIAsyncEnumerableAsync<T>(
            IEnumerable<SubstrateClient> clients,
            Func<SubstrateClient, NftTypeEnum, int, int, CancellationToken, Task<IEnumerable<T>>> getter,
            Func<SubstrateClient, NftTypeEnum, byte[]?, CancellationToken, Task<RecursiveReturn<T>>> onChainFallbackGetter,
            int limit,
            [EnumeratorCancellation] CancellationToken token = default
        )
        {
            foreach (var client in clients)
            {
                foreach (var nftType in GetNftTypeForClient(client))
                {
                    int offset = 0;
                    byte[]? lastKey = null;

                    while (true)
                    {
                        IEnumerable<T> items;

                        try
                        {
                            items = await getter.Invoke(client, nftType, limit, offset, token);
                        }
                        catch
                        {
                            // Fallback to on-chain query
                            var nfts = await onChainFallbackGetter.Invoke(client, nftType, lastKey, token);

                            items = nfts.Items;
                            lastKey = nfts.LastKey;
                        }

                        foreach (var item in items)
                        {
                            yield return item;
                        }

                        if (items.Count() != limit)
                        {
                            break;
                        }

                        offset += items.Count();
                    }
                }
            }
        }
        private static IEnumerable<NftTypeEnum> GetNftTypeForClient(SubstrateClient client)
        {
            return client switch
            {
                PolkadotAssetHub.NetApi.Generated.SubstrateClientExt => [NftTypeEnum.PolkadotAssetHub_NftsPallet],
                KusamaAssetHub.NetApi.Generated.SubstrateClientExt => [NftTypeEnum.KusamaAssetHub_NftsPallet],
                Unique.NetApi.Generated.SubstrateClientExt => [NftTypeEnum.Unique],
                _ => []
            };
        }
    }
}