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
        public List<string> Images { get; set; } = [];

        [JsonPropertyName("attributes")] public required PropertyAttributes Attributes { get; set; }

        [JsonPropertyName("buildingControlCode")] public string? BuildingControlCode { get; set; }

        [JsonPropertyName("status")] public string? Status { get; set; }

        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }

        [JsonPropertyName("address")] public required PropertyAddress Address { get; set; }

        [JsonPropertyName("company")] public PropertyCompany? Company { get; set; }

        [JsonPropertyName("propertyDescription")] public string? PropertyDescription { get; set; }

        [JsonPropertyName("financials")] public required PropertyFinancials Financials { get; set; }

        [JsonPropertyName("propertyType")] public string? PropertyType { get; set; }

        [JsonPropertyName("map")] public string? Map { get; set; }

        [JsonPropertyName("developerAddress")] public string? DeveloperAddress { get; set; }

        [JsonPropertyName("propertyName")] public string? PropertyName { get; set; }

        [JsonPropertyName("planningCode")] public string? PlanningCode { get; set; }

        [JsonPropertyName("propertyId")] public string? PropertyId { get; set; }

        [JsonPropertyName("files")] public List<string>? Files { get; set; }

        [JsonPropertyName("id")] public Guid Id { get; set; }

        [JsonPropertyName("accountAddress")] public string? AccountAddress { get; set; }

        [JsonPropertyName("updatedAt")] public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("legalRepresentative")] public string? LegalRepresentative { get; set; }

        [JsonPropertyName("fileUrls")] public List<string> FileUrls { get; set; } = [];

        public string LocationName => $"{Address?.Street ?? "Unknown street"}, {Address?.TownCity ?? "Unknown town"}";
    }

    public record PropertyAttributes
    {
        [JsonPropertyName("area")] public string? Area { get; set; }

        [JsonPropertyName("offStreetParking")] public string? OffStreetParking { get; set; }

        [JsonPropertyName("outdoorSpace")] public string? OutdoorSpace { get; set; }

        [JsonPropertyName("numberOfBedrooms")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int NumberOfBedrooms { get; set; }

        [JsonPropertyName("constructionDate")] public string? ConstructionDate { get; set; }

        [JsonPropertyName("numberOfBathrooms")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int NumberOfBathrooms { get; set; }

        [JsonPropertyName("quality")] public string? Quality { get; set; }
    }

    public record PropertyAddress
    {
        [JsonPropertyName("postCode")] public string? PostCode { get; set; }

        [JsonPropertyName("flatOrUnit")] public string? FlatOrUnit { get; set; }

        [JsonPropertyName("localAuthority")] public string? LocalAuthority { get; set; }

        [JsonPropertyName("street")] public string? Street { get; set; }

        [JsonPropertyName("townCity")] public string? TownCity { get; set; }
    }

    public record PropertyCompany
    {
        [JsonPropertyName("name")] public string? Name { get; set; }

        [JsonPropertyName("logo")] public string? Logo { get; set; }
    }

    public record PropertyFinancials
    {
        [JsonPropertyName("stampDutyTax")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal StampDutyTax { get; set; }

        [JsonPropertyName("isAnnualServiceChargePaid")] public bool IsAnnualServiceChargePaid { get; set; }

        [JsonPropertyName("estimatedRentalIncome")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal EstimatedRentalIncome { get; set; }

        [JsonPropertyName("pricePerToken")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal PricePerToken { get; set; }

        [JsonPropertyName("numberOfTokens")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int NumberOfTokens { get; set; }

        [JsonPropertyName("isStampDutyPaid")] public bool IsStampDutyPaid { get; set; }

        [JsonPropertyName("propertyPrice")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal PropertyPrice { get; set; }

        [JsonPropertyName("annualServiceCharge")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public decimal AnnualServiceCharge { get; set; }
    }
}
