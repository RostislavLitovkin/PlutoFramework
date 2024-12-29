using Blake2Core;
using Newtonsoft.Json;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using System.Text;

namespace PlutoFramework.Model.Kilt
{
    public class ExpandedContents<T>
    {
        public required string Id { get; set; }
        public Dictionary<string, object> Claims { get; set; } = new();
    }

    public record StatementAndDigest
    {
        public required string Statement { get; set; }

        // Blake2 hash
        public required byte[] Digest { get; set; }
    }
    public record CredentialSubject
    {
        public required string ContextVocab { get; set; }
        /// <summary>
        /// Did string
        /// export type Did =
        /// | `did:kilt:${DidVersion}${KiltAddress}`
        /// | `did:kilt:light:${DidVersion}${AuthenticationKeyType}${KiltAddress}${LightDidDocumentEncodedData}`
        /// </summary>
        public required string Id { get; set; }

        private class ByteArrayComparer : IComparer<byte[]>
        {
            public int Compare(byte[] x, byte[] y)
            {
                if (x == null || y == null) throw new ArgumentNullException();

                for (int i = 0; i < Math.Min(x.Length, y.Length); i++)
                {
                    int comparison = x[i].CompareTo(y[i]);
                    if (comparison != 0) return comparison;
                }

                return x.Length.CompareTo(y.Length);
            }
        }


        /// <summary>
        /// https://github.com/KILTprotocol/sdk-js/blob/ec335d7086fa6673d2da45cd89f54ed02a09a287/packages/credentials/src/V1/KiltAttestationProofV1.ts#L150
        /// </summary>
        public static (List<string> Statements, List<byte[]> Digests) NormalizeClaims<T>(ExpandedContents<T> expandedContents)
        {
            var statements = expandedContents.Claims
                .Select(entry => JsonConvert.SerializeObject(new Dictionary<string, object>
                {
                { entry.Key, entry.Value }
                }))
                .Select(json => json.Normalize(NormalizationForm.FormC))
                .ToList();

            var statementsAndDigests = statements.Select(statement => new StatementAndDigest
            {
                Statement = statement,
                Digest = HashExtension.Blake2(Encoding.UTF8.GetBytes(statement), 256)
            }).ToList();

            var sorted = statementsAndDigests.OrderBy(item => item.Digest, new ByteArrayComparer());

            return (
                Statements: sorted.Select(item => item.Statement).ToList(),
                Digests: sorted.Select(item => item.Digest).ToList()
            );
        }
    }
}



    public record UnissuedCredential
{
    public required string Id { get; set; }

    public required CredentialSubject CredentialSubject { get; set; }
    /// <summary>
    /// Did string
    /// export type Did =
    /// | `did:kilt:${DidVersion}${KiltAddress}`
    /// | `did:kilt:light:${DidVersion}${AuthenticationKeyType}${KiltAddress}${LightDidDocumentEncodedData}`
    /// </summary>
    public required string Issuer { get; set; }
    public bool NonTransferable => true;

    public required string[] Type { get; set; }
    // Missing
    // credentialSchema

    // Missing more maybe



}
}
