using System.Text.Json.Serialization;

namespace UniqueryPlus.Metadata
{
    public record File
    {

    }
    public record XCavateMetadata
    {
        [JsonPropertyName("property_name")] public required string PropertyName;
        [JsonPropertyName("address_street")] public required string AddressStreet;
        [JsonPropertyName("address_town_city")] public required string AddressTownCity;
        [JsonPropertyName("post_code")] public required string PostCode;
        [JsonPropertyName("property_type")] public required string PropertyType;
        [JsonPropertyName("property_number")] public required string PropertyNumber;
        [JsonPropertyName("local_authority")] public required string LocalAuthority;
        [JsonPropertyName("planning_permission_code")] public string? PlanningPermissionCode;
        [JsonPropertyName("map")] public required string Map;
        [JsonPropertyName("floor_plan")] public required File FloorPlan;
        [JsonPropertyName("sales_agreement")] public required File SalesAgreement;
        [JsonPropertyName("region")] public required int Region;
        [JsonPropertyName("location")] public required int Location;
        [JsonPropertyName("number_of_tokens")] public required string NumberOfTokens;
        [JsonPropertyName("price_per_token")] public required string PricePerToken;
        [JsonPropertyName("property_price")] public required string PropertyPrice;
        [JsonPropertyName("estimated_rental_income")] public required string EstimatedRentalIncome;
        [JsonPropertyName("area")] public required string Area;
        [JsonPropertyName("quality")] public required string Quality;
        [JsonPropertyName("outdoor_space")] public required string OutdoorSpace;
        [JsonPropertyName("no_of_bedrooms")] public required string NoOfBedrooms;
        [JsonPropertyName("construction_date")] public required string ConstructionDate;
        [JsonPropertyName("no_of_bathrooms")] public required string NoOfBathrooms;
        [JsonPropertyName("off_street_parking")] public required string OffStreetParking;
        [JsonPropertyName("property_description")] public required string PropertyDescription;
        [JsonPropertyName("property_development_code")] public string? PropertyDevelopmentCode;
        [JsonPropertyName("title_deed_number")] public required string TitleDeedNumber;
        [JsonPropertyName("property_images")] public required List<File> PropertyImages;
    }
}
