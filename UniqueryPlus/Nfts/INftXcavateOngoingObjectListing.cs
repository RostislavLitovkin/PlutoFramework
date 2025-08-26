using Substrate.NetApi.Model.Types.Primitive;

namespace UniqueryPlus.Nfts
{
    public record XcavateOngoingObjectListingDetails
    {
        public required string RealEstateDeveloper { get; set; }
        public required bool TaxPaidByDeveloper { get; set; }

        /// <summary>
        /// Listing expiry in Block numbers
        /// </summary>
        public required uint ListingExpiry { get; set; } 

        public required uint ListedTokens { get; set; }

        public required U32 AssetId { get; set; }

        public required U32 CollectionId { get; set; }

        public required U32 ItemId { get; set; }
    }

    public interface INftXcavateOngoingObjectListing
    {
        public XcavateOngoingObjectListingDetails? OngoingObjectListingDetails { get; set; }
    }
}
