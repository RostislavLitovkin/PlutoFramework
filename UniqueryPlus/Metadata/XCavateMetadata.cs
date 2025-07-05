using System.Text.Json.Serialization;

namespace UniqueryPlus.Metadata
{
    public record XcavateMetadata
    {
        public string LocationName => $"{AddressStreet ?? "Unknown street"}, {AddressTownCity ?? "Unknown town"}";
        public List<string> Images { get; set; } = [];

        [JsonPropertyName("price_per_token")]
        public int PricePerToken { get; init; }

        [JsonPropertyName("title_deed_number")]
        public string TitleDeedNumber { get; init; }

        [JsonPropertyName("outdoor_space")]
        public string OutdoorSpace { get; init; }

        [JsonPropertyName("property_name")]
        public string PropertyName { get; init; }

        [JsonPropertyName("no_of_bathrooms")]
        public string NoOfBathrooms { get; init; }

        [JsonPropertyName("files")]
        public List<string> Files { get; init; }

        [JsonPropertyName("planning_permission_Code")]
        public string PlanningPermissionCode { get; init; }

        [JsonPropertyName("property_number")]
        public string PropertyNumber { get; init; }

        [JsonPropertyName("property_type")]
        public string PropertyType { get; init; }

        [JsonPropertyName("construction_date")]
        public string ConstructionDate { get; init; }

        [JsonPropertyName("no_of_Bedrooms")]
        public string NoOfBedrooms { get; init; }

        [JsonPropertyName("region")]
        public int Region { get; init; }

        [JsonPropertyName("address_street")]
        public string AddressStreet { get; init; }

        [JsonPropertyName("location")]
        public int Location { get; init; }

        [JsonPropertyName("propertyId")]
        public long PropertyId { get; init; }

        [JsonPropertyName("address_town_city")]
        public string AddressTownCity { get; init; }

        [JsonPropertyName("Off_street_parking")]
        public string OffStreetParking { get; init; }

        [JsonPropertyName("property_development_Code")]
        public string PropertyDevelopmentCode { get; init; }

        [JsonPropertyName("post_code")]
        public string PostCode { get; init; }

        [JsonPropertyName("quality")]
        public string Quality { get; init; }

        [JsonPropertyName("estimated_rental_income")]
        public uint EstimatedRentalIncome { get; init; }

        [JsonPropertyName("number_of_tokens")]
        public uint NumberOfTokens { get; init; }

        [JsonPropertyName("accountAddress")]
        public string AccountAddress { get; init; }

        [JsonPropertyName("area")]
        public string Area { get; init; }

        [JsonPropertyName("local_authority")]
        public string LocalAuthority { get; init; }

        [JsonPropertyName("map")]
        public string Map { get; init; }

        [JsonPropertyName("property_description")]
        public string PropertyDescription { get; init; }

        [JsonPropertyName("property_price")]
        public long PropertyPrice { get; init; }

        [JsonPropertyName("fileUrls")]
        public List<string> FileUrls { get; init; }
    }
}
