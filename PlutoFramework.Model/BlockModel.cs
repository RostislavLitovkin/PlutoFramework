using PlutoFramework.Constants;
using System.Numerics;
using PlutoFramework.Model.AjunaExt;

namespace PlutoFramework.Model
{
    public static class BlockModel
    {
        private static Dictionary<EndpointEnum, BigInteger> blockNumbers = [];

        public static Task<BigInteger> GetCachedBlockNumberAsync(SubstrateClientExt client, CancellationToken token)
        {
            if (blockNumbers.ContainsKey(client.Endpoint.Key))
            {
                return Task.FromResult(blockNumbers[client.Endpoint.Key]);
            }

            return GetLatestBlockNumberAsync(client, token);
        }

        public static async Task<BigInteger> GetLatestBlockNumberAsync(SubstrateClientExt client, CancellationToken token)
        {
            var block = await client.SubstrateClient.Chain.GetBlockAsync(token);

            var blockNumber = block.Block.Header.Number.Value;

            blockNumbers[client.Endpoint.Key] = blockNumber;

            return blockNumber;
        }
    }
}
