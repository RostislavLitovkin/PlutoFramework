using Substrate.NetApi;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlutoFramework.Model
{
    /// <summary>
    /// https://docs.kilt.io/docs/concepts/credentials/ctypes/#properties
    /// </summary>
    [JsonDerivedType(typeof(CTypePrimitiveProperty))]
    [JsonDerivedType(typeof(CTypeReferenceProperty))]
    public interface CTypeProperty;
    public record CTypePrimitiveProperty : CTypeProperty
    {
        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }
    public record CTypeReferenceProperty : CTypeProperty
    {
        [JsonPropertyName("$ref")]
        public required string Ref { get; set; }
    }
    public record CTypeSchema
    {
        [JsonPropertyName("$schema")]
        public required string Schema { get; set; }

        [JsonPropertyName("additionalProperties")]
        public required bool AdditionalProperties { get; set; }

        [JsonPropertyName("properties")]
        public required Dictionary<string, CTypeProperty> Properties { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }

    public record FullCTypeSchema : CTypeSchema
    {
        [JsonPropertyName("$id")]
        public string Id => $"kilt:ctype:{CTypeModel.ComputeCTypeIdHash(this)}";
    }

    public record CredentialsClaim
    {
        public required string CTypeHash { get; set; }
        public required Dictionary<string, object> Contents { get; set; }
        public required string OwnerDid { get; set; }
    }
    public class CTypeModel
    {
        public static string ComputeCTypeIdHash(CTypeSchema schema)
        {
            schema.Properties = CanonicalizeProperties(schema.Properties);
            string json = JsonSerializer.Serialize(schema);

            Console.WriteLine(json);

            var hash = HashExtension.Blake2(Encoding.UTF8.GetBytes(json), 256);

            return Utils.Bytes2HexString(hash).ToLower();
        }

        /// <summary>
        /// https://github.com/KILTprotocol/sdk-js/blob/74f4d5cd6e2a417af4ff53c58bd56acfe2c75dd8/packages/legacy-credentials/src/Claim.ts#L208
        /// </summary>
        public static CredentialsClaim fromCTypeAndClaimContents(
            CTypeSchema ctype,
            Dictionary<string, object> claimContents,
            string claimerDid
            )
        {
            return new CredentialsClaim
            {
                CTypeHash = ComputeCTypeIdHash(ctype),
                Contents = claimContents,
                OwnerDid = claimerDid
            };
        }
        private static Dictionary<string, CTypeProperty> CanonicalizeProperties(Dictionary<string, CTypeProperty> properties)
        {
            var sortedProperties = new Dictionary<string, CTypeProperty>();

            foreach (var kvp in properties.OrderBy(p => p.Key))
            {
                sortedProperties[kvp.Key] = kvp.Value;
            }

            return sortedProperties;
        }

        
    }
}
