
using PlutoFramework.Constants;
using PlutoFramework.Model.AjunaExt;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using XcavatePaseo.NetApi.Generated.Model.pallet_regions.pallet;

namespace PlutoFramework.Model.Xcavate
{
    public record XcavateRegion
    {
        public required EndpointEnum EndpointKey { get; init; }
        public required uint CollectionId { get; set; }
        public required uint ListingDuration { get; set; }
        public required string Owner { get; set; }
        public required uint Tax { get; set; }
        public required bool HasExpired { get; set; }
    }

    public static class RegionModel
    {
        private static Dictionary<(EndpointEnum, uint), XcavateRegion> regions = new();

        public static Task<XcavateRegion> GetCachedRegionAsync(SubstrateClientExt client, uint regionId, CancellationToken token)
        {
            var key = (client.Endpoint.Key, regionId);
            if (regions.ContainsKey(key))
            {
                return Task.FromResult(regions[key]);
            }
            return GetRegionAsync(client, regionId, token);
        }

        public static async Task<XcavateRegion> GetRegionAsync(SubstrateClientExt client, uint regionId, CancellationToken token)
        {
            uint blockNumber = (uint) await BlockModel.GetCachedBlockNumberAsync(client, token).ConfigureAwait(false);

            return client.SubstrateClient switch
            {
                XcavatePaseo.NetApi.Generated.SubstrateClientExt xcavateClient => ToXcavateRegion(await xcavateClient.RegionsStorage.RegionDetails(new U16((ushort)regionId), null, token), blockNumber, EndpointEnum.XcavatePaseo),
                _ => throw new NotSupportedException("GetRegionAsync: Unsupported client type")
            };
        }

        private static XcavateRegion ToXcavateRegion(RegionInfo regionInfo, uint blockNumber, EndpointEnum endpointKey)
        {
            Console.WriteLine($"{regionInfo.ListingDuration} > {blockNumber}");

            return new XcavateRegion
            {
                EndpointKey = endpointKey,
                CollectionId = regionInfo.CollectionId,
                ListingDuration = regionInfo.ListingDuration,
                Owner = Utils.GetAddressFrom(regionInfo.Owner.Encode()),
                Tax = (uint)regionInfo.Tax.Value,
                HasExpired = regionInfo.ListingDuration < blockNumber
            };
        }
    }
}

