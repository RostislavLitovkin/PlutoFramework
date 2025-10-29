namespace UniqueryPlus.Nfts
{
    public record NftMarketplaceDetails
    {
        public required bool SpvCreated { get; set; }
        public required uint AssetId { get; set; }
        public required uint Region { get; set; }
        public required string Location { get; set; }
        public required uint Tokens { get; set; }
    }
    public interface INftXcavateNftMarketplace
    {
        public NftMarketplaceDetails? NftMarketplaceDetails { get; set; }
    }
}
