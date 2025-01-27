﻿using Substrate.NetApi;
using System.Runtime.CompilerServices;

namespace UniqueryPlus
{
    public class RecursionHelper
    {
        public static async IAsyncEnumerable<T> ToIAsyncEnumerableAsync<K, T>(
            Func<K?, CancellationToken, Task<RecursiveReturn<K?, T>>> getter,
            uint limit,
            [EnumeratorCancellation] CancellationToken token = default
        )
        {
            K? lastId = default;

            while (true)
            {
                RecursiveReturn<K?, T> recursiveReturn;
                try
                {
                    recursiveReturn = await getter.Invoke(lastId, token);
                }
                catch
                {
                    break;
                }

                foreach (var item in recursiveReturn.Items)
                {
                    yield return item;
                }

                if (recursiveReturn.Items.Count() != limit)
                {
                    break;
                }


                lastId = recursiveReturn.LastKey;
            }
        }

        public static async IAsyncEnumerable<T> ToIAsyncEnumerableAsync<T>(
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
                        RecursiveReturn<T> recursiveReturn;
                        try
                        {
                            recursiveReturn = await getter.Invoke(client, nftType, lastKey, token);
                        }
                        catch
                        {
                            break;
                        }

                        foreach (var item in recursiveReturn.Items)
                        {
                            yield return item;
                        }

                        if (recursiveReturn.Items.Count() != limit)
                        {
                            break;
                        }


                        lastKey = recursiveReturn.LastKey;
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
                        IEnumerable<T> items;
                        try
                        {
                            items = await getter.Invoke(client, nftType, limit, offset, token);
                        }
                        catch
                        {
                            break;
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
                            try
                            {
                                var nfts = await onChainFallbackGetter.Invoke(client, nftType, lastKey, token);

                                items = nfts.Items;
                                lastKey = nfts.LastKey;
                            }
                            catch
                            {
                                items = [];
                                lastKey = null;
                            }
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
                Opal.NetApi.Generated.SubstrateClientExt => [NftTypeEnum.Opal],
                Mythos.NetApi.Generated.SubstrateClientExt => [NftTypeEnum.Mythos],
                XCavatePaseo.NetApi.Generated.SubstrateClientExt => [NftTypeEnum.XCavatePaseo],
                _ => []
            };
        }
    }
}
