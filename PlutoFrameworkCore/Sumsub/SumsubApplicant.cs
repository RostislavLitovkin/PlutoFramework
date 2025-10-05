using System.Globalization;
using System.Text.Json.Serialization;

namespace PlutoFramework.Model.Sumsub
{
    public record SumsubApplicant
    {
        [JsonPropertyName("id")] public required string Id { get; init; }
        [JsonPropertyName("createdAt")] public required string CreatedAt { get; init; }
        public DateTime CreatedAtDateTime => DateTime.ParseExact(
            CreatedAt,
            "yyyy-MM-dd HH:mm:ss",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
        );

        [JsonPropertyName("createdBy")] public string? CreatedBy { get; init; }
        [JsonPropertyName("key")] public required string Key { get; init; }
        [JsonPropertyName("clientId")] public required string ClientId { get; init; }
        [JsonPropertyName("inspectionId")] public required string InspectionId { get; init; }
        [JsonPropertyName("externalUserId")] public required string ExternalUserId { get; init; }
        [JsonPropertyName("email")] public required string Email { get; init; }
        [JsonPropertyName("phone")] public required string Phone { get; init; }
        [JsonPropertyName("applicantPlatform")] public required string ApplicantPlatform { get; init; }
        [JsonPropertyName("requiredIdDocs")] public required RequiredIdDocs RequiredIdDocs { get; init; }
        [JsonPropertyName("review")] public required Review Review { get; init; }
        [JsonPropertyName("lang")] public required string Lang { get; init; }
        [JsonPropertyName("type")] public required string Type { get; init; }
    }

    public record RequiredIdDocs
    {
        [JsonPropertyName("docSets")] public required List<DocSet> DocSets { get; init; }
    }

    public record DocSet
    {
        [JsonPropertyName("idDocSetType")] public string? IdDocSetType { get; init; }
        [JsonPropertyName("types")] public List<string>? Types { get; init; }
        [JsonPropertyName("videoRequired")] public string? VideoRequired { get; init; }
    }

    public record Review
    {
        [JsonPropertyName("reviewId")] public required string ReviewId { get; init; }
        [JsonPropertyName("attemptId")] public required string AttemptId { get; init; }
        [JsonPropertyName("attemptCnt")] public required int AttemptCnt { get; init; }
        [JsonPropertyName("levelName")] public required string LevelName { get; init; }
        [JsonPropertyName("levelAutoCheckMode")] public string? LevelAutoCheckMode { get; init; }
        [JsonPropertyName("createDate")] public required string CreateDate { get; init; }
        [JsonPropertyName("reviewStatus")] public required string ReviewStatus { get; init; }
        [JsonPropertyName("priority")] public required int Priority { get; init; }
    }

}
