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
    }

    public interface INftXcavateOngoingObjectListing
    {
        public XcavateOngoingObjectListingDetails? OngoingObjectListingDetails { get; set; }
    }
}
