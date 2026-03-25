using Kilt.NetApi.Generated;
using PlutoFramework.Model;
using PlutoFramework.Model.Sumsub;
using PlutoFramework.Templates.PageTemplate;
using System.Text.Json.Serialization;

namespace PlutoFramework.Components.Kilt;

public partial class DidManagementPage : PageTemplate
{
    public DidManagementPage(string? secret)
    {
        InitializeComponent();

        BindingContext = new DidManagementViewModel
        {
            Did = Preferences.Get(PreferencesModel.PUBLIC_KEY + "kilt1", ""),
            Mnemonics = secret ?? "No mnemonics found",
        };
    }

    private async Task LoadAsync()
    {
        CancellationToken token = CancellationToken.None;

        var viewModel = (DidManagementViewModel)BindingContext;
        var client = await SubstrateClientModel.GetOrAddSubstrateClientAsync(Constants.EndpointEnum.Kilt, token);

        var didDetails = await ((SubstrateClientExt)client.SubstrateClient).DidStorage.Did(
            DidModel.DidAddressToAccountId32(viewModel.Did),
            null,
            token
        );

        if (didDetails is null)
        {
            return;
        }

        viewModel.DidVerification = DidVerificationEnum.Full;

        Preferences.Set(PreferencesModel.DID_VERIFICATION + "kilt1", DidVerificationEnum.Full.ToString());
    }
}

public record SumsubApplicant
{
    [JsonPropertyName("id")] public required string Id { get; init; }
    [JsonPropertyName("createdAt")] public required string CreatedAt { get; init; }
    [JsonPropertyName("createdBy")] public string? CreatedBy { get; init; }
    [JsonPropertyName("key")] public required string Key { get; init; }
    [JsonPropertyName("clientId")] public required string ClientId { get; init; }
    [JsonPropertyName("inspectionId")] public required string InspectionId { get; init; }
    [JsonPropertyName("externalUserId")] public required string ExternalUserId { get; init; }
    [JsonPropertyName("email")] public string? Email { get; init; }
    [JsonPropertyName("phone")] public string? Phone { get; init; }
    [JsonPropertyName("applicantPlatform")] public string? ApplicantPlatform { get; init; }
    [JsonPropertyName("requiredIdDocs")] public SumsubRequiredIdDocs? RequiredIdDocs { get; init; }
    [JsonPropertyName("review")] public SumsubReview? Review { get; init; }
    [JsonPropertyName("lang")] public string? Lang { get; init; }
    [JsonPropertyName("type")] public string? Type { get; init; }
    [JsonPropertyName("info")] public SumsubApplicantInfo? Info { get; init; }
}

public record SumsubApplicantInfo
{
    [JsonPropertyName("firstName")] public string? FirstName { get; init; }
    [JsonPropertyName("firstNameEn")] public string? FirstNameEn { get; init; }
    [JsonPropertyName("middleName")] public string? MiddleName { get; init; }
}