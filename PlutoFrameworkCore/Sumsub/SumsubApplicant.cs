using System.Globalization;
using System.Text.Json.Serialization;

namespace PlutoFramework.Model.Sumsub
{
    public record SumsubApplicant
    {
        [JsonPropertyName("id")] public string? Id { get; init; }

        [JsonPropertyName("createdAt")] public string? CreatedAt { get; init; }
        public DateTime CreatedAtDateTime => DateTime.ParseExact(
            CreatedAt,
            "yyyy-MM-dd HH:mm:ss",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
        );

        [JsonPropertyName("createdBy")] public string? CreatedBy { get; init; }
        [JsonPropertyName("key")] public required string Key { get; init; }
        [JsonPropertyName("clientId")] public string? ClientId { get; init; }
        [JsonPropertyName("inspectionId")] public string? InspectionId { get; init; }
        [JsonPropertyName("externalUserId")] public string? ExternalUserId { get; init; }
        [JsonPropertyName("email")] public string? Email { get; init; }
        [JsonPropertyName("phone")] public string? Phone { get; init; }
        [JsonPropertyName("applicantPlatform")] public required string ApplicantPlatform { get; init; }
        [JsonPropertyName("requiredIdDocs")] public SumsubRequiredIdDocs? RequiredIdDocs { get; init; }
        [JsonPropertyName("review")] public SumsubReview? Review { get; init; }
        [JsonPropertyName("lang")] public string? Lang { get; init; }
        [JsonPropertyName("type")] public string? Type { get; init; }
    }

    public record SumsubRequiredIdDocs
    {
        [JsonPropertyName("docSets")] public required List<SumsubDocSet> DocSets { get; init; }
    }

    public record SumsubDocSet
    {
        [JsonPropertyName("idDocSetType")] public string? IdDocSetType { get; init; }
        [JsonPropertyName("types")] public List<string>? Types { get; init; }
        [JsonPropertyName("videoRequired")] public string? VideoRequired { get; init; }
    }

    public record SumsubReview
    {
        [JsonPropertyName("reviewId")] public string? ReviewId { get; init; }
        [JsonPropertyName("attemptId")] public string? AttemptId { get; init; }
        [JsonPropertyName("attemptCnt")] public int? AttemptCnt { get; init; }
        [JsonPropertyName("levelName")] public string? LevelName { get; init; }
        [JsonPropertyName("levelAutoCheckMode")] public string? LevelAutoCheckMode { get; init; }
        [JsonPropertyName("createDate")] public string? CreateDate { get; init; }
        [JsonPropertyName("reviewStatus")] public string? ReviewStatus { get; init; }
        [JsonPropertyName("priority")] public int? Priority { get; init; }
    }
}
