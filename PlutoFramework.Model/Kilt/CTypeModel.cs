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

    public class CTypeModel
    {
        public static string ComputeCTypeId(CTypeSchema schema)
        {
            schema.Properties = CanonicalizeProperties(schema.Properties);
            string json = JsonSerializer.Serialize(schema);

            Console.WriteLine(json);

            var hash = HashExtension.Blake2(Encoding.UTF8.GetBytes(json), 256);

            return $"kilt:ctype:{Utils.Bytes2HexString(hash).ToLower()}";
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
