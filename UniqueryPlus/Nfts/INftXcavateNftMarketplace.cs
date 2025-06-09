namespace UniqueryPlus.Nfts
{
    public record NftMarketplaceDetails
    {
        public bool SpvCreated { get; set; }
        public uint AssetId { get; set; }
        public uint Region { get; set; }
        public string Location { get; set; }
        public uint? Listed { get; set; }
    }
    public interface INftXcavateNftMarketplace
    {
        public NftMarketplaceDetails? NftMarketplaceDetails { get; set; }
    }
}
