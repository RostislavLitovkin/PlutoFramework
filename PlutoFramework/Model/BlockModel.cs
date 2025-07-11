using PlutoFramework.Constants;
using PlutoFramework.Model.AjunaExt;

namespace PlutoFramework.Model
{
    public enum Interval
    {
        Hourly,
        Daily,
        Weekly,
    }

    public static class BlockModel
    {
        private const uint SECONDS_IN_HOUR = 3600;

        private const uint SECONDS_IN_DAY = 86400;

        private const uint SECONDS_IN_WEEK = 604800;

        private const uint DEFAULT_BLOCK_TIME = 6;

        public static IEnumerable<uint> GetBlocks(Interval interval, uint lastBlockNumber, uint numberOfBlocks, uint blockTime = DEFAULT_BLOCK_TIME)
        {
            var blockInterval = interval switch
            {
                Interval.Hourly => SECONDS_IN_HOUR,
                Interval.Daily => SECONDS_IN_DAY,
                Interval.Weekly => SECONDS_IN_WEEK,
                _ => throw new ArgumentOutOfRangeException(nameof(interval), interval, null)
            } / blockTime;

            var blocks = new uint[numberOfBlocks];

            for (uint i = 0; i < numberOfBlocks; i++)
            {
                blocks[i] = lastBlockNumber - ((numberOfBlocks - i) * blockInterval);
            }

            return blocks;
        }

        private static Dictionary<EndpointEnum, ulong> blockNumbers = [];

        public static Task<ulong> GetCachedBlockNumberAsync(SubstrateClientExt client, CancellationToken token)
        {
            if (blockNumbers.ContainsKey(client.Endpoint.Key))
            {
                return Task.FromResult(blockNumbers[client.Endpoint.Key]);
            }

            return GetLatestBlockNumberAsync(client, token);
        }

        public static async Task<ulong> GetLatestBlockNumberAsync(SubstrateClientExt client, CancellationToken token)
        {
            var blockHeader = await client.SubstrateClient.Chain.GetHeaderAsync(token);

            var blockNumber = blockHeader.Number.Value;

            blockNumbers[client.Endpoint.Key] = blockNumber;

            return blockNumber;
        }
    }
}
