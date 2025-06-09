
using PlutoFramework.Constants;
using PlutoFramework.Model.AjunaExt;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;

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

        public static async Task<XcavateRegion> GetRegionAsync(SubstrateClientExt client, uint regionId, CancellationToken token) =>
            client.SubstrateClient switch
            {
                XcavatePaseo.NetApi.Generated.SubstrateClientExt xcavateClient => ToXcavateRegion(await xcavateClient.NftMarketplaceStorage.Regions(new U32(regionId), null, token), EndpointEnum.XcavatePaseo),
                _ => throw new NotSupportedException("GetRegionAsync: Unsupported client type")
            };


        private static XcavateRegion ToXcavateRegion(XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.types.RegionInfo regionInfo, EndpointEnum endpointKey) =>
            new XcavateRegion
            {
                EndpointKey = endpointKey,
                CollectionId = regionInfo.CollectionId,
                ListingDuration = regionInfo.ListingDuration,
                Owner = Utils.GetAddressFrom(regionInfo.Owner.Encode()),
                Tax = (uint)regionInfo.Tax.Value,
                HasExpired = regionInfo.ListingDuration != 0 || regionInfo.ListingDuration < (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds // Assuming ListingDuration will get updated to timestamp
            };
    }
}

