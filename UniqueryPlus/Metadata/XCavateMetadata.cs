using System.Text.Json.Serialization;

namespace UniqueryPlus.Metadata
{
    public record XcavateNftMetadata
    {
        [JsonPropertyName("data")] public required PropertyMetadata Data { get; set; }
    }

    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public record PropertyMetadata
    {
        [JsonPropertyName("price_per_token")] public decimal PricePerToken { get; set; }

        [JsonPropertyName("status")] public string Status { get; set; }

        [JsonPropertyName("title_deed_number")] public string TitleDeedNumber { get; set; }

        [JsonPropertyName("outdoor_space")] public string? OutdoorSpace { get; set; }

        [JsonPropertyName("property_name")] public string PropertyName { get; set; }

        [JsonPropertyName("no_of_bathrooms")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)] 
        public int NoOfBathrooms { get; set; }

        [JsonPropertyName("files")] public List<string>? Files { get; set; }

        [JsonPropertyName("planning_permission_Code")] public string PlanningPermissionCode { get; set; }

        [JsonPropertyName("property_number")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)] 
        public int PropertyNumber { get; set; }

        [JsonPropertyName("property_type")] public string PropertyType { get; set; }

        [JsonPropertyName("construction_date")] public string ConstructionDate { get; set; }

        [JsonPropertyName("no_of_Bedrooms")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int NoOfBedrooms { get; set; }

        [JsonPropertyName("address_street")] public string? AddressStreet { get; set; }

        [JsonPropertyName("id")] public Guid Id { get; set; }

        [JsonPropertyName("propertyId")] public string PropertyId { get; set; }

        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonPropertyName("address_town_city")] public string? AddressTownCity { get; set; }

        [JsonPropertyName("Off_street_parking")] public string OffStreetParking { get; set; }

        [JsonPropertyName("property_development_Code")] public string PropertyDevelopmentCode { get; set; }

        [JsonPropertyName("post_code")] public string PostCode { get; set; }

        [JsonPropertyName("quality")] public string Quality { get; set; }

        [JsonPropertyName("estimated_rental_income")] public decimal EstimatedRentalIncome { get; set; }

        [JsonPropertyName("number_of_tokens")] public int NumberOfTokens { get; set; }

        [JsonPropertyName("accountAddress")] public string AccountAddress { get; set; }

        [JsonPropertyName("area")] public string Area { get; set; }

        [JsonPropertyName("local_authority")] public string LocalAuthority { get; set; }

        [JsonPropertyName("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("map")] public string Map { get; set; }

        [JsonPropertyName("property_description")] public string PropertyDescription { get; set; }

        [JsonPropertyName("property_price")] public decimal PropertyPrice { get; set; }

        [JsonPropertyName("fileUrls")] public List<string> FileUrls { get; set; }
        public string LocationName => $"{AddressStreet ?? "Unknown street"}, {AddressTownCity ?? "Unknown town"}";

        public List<string> Images { get; set; } = [];
    }
}
