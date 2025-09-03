using PlutoFramework.Model.AjunaExt;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Text;
using System.Text.Json.Serialization;
using XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_btree_map;
using XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec;
using XcavatePaseo.NetApi.Generated.Model.pallet_bucket.types;
using XcavatePaseo.NetApi.Generated.Storage;
using XcavatePaseo.NetApi.Generated.Types.Base;

namespace PlutoFrameworkCore.AssetDidComm
{
    public record AssetDidCommNamespaceInput
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        public BoundedVecT19 NameVec
        {
            get
            {
                var name = new BoundedVecT19();

                var vec = new BaseVec<U8>(
                    Encoding.UTF8.GetBytes(Name).Select(b => new U8(b)).ToArray()
                );

                int p = 0;

                name.Decode(vec.Encode(), ref p);

                return name;
            }
        }
    }

    public record AssetDidCommBucketInput
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        public BoundedVecT19 NameVec
        {
            get
            {
                var name = new BoundedVecT19();

                var vec = new BaseVec<U8>(
                    Encoding.UTF8.GetBytes(Name).Select(b => new U8(b)).ToArray()
                );

                int p = 0;

                name.Decode(vec.Encode(), ref p);

                return name;
            }
        }
    }

    public record AssetDidCommNamespace : AssetDidCommNamespaceInput
    {
        [JsonPropertyName("createdAt")]
        public required uint CreatedAt { get; set; }
    }

    public class AssetDidCommNamespaceModel
    {
        public static Task CreateNamespaceAsync(SubstrateClientExt client, Account account, Action<string, ExtrinsicStatus> callback, AssetDidCommNamespaceInput name, CancellationToken token)
        {
            var namespaceId = new U128();
            namespaceId.Create(new byte[16].Populate());

            // POST /api/v1/extrinsics/create-namespace

            var metadata = new NamespaceMetadataInput
            {
                Name = name.NameVec,
                SchemaUri = new BaseOpt<BoundedVecT20>(),
                Properties = new BoundedBTreeMapT1
                {
                    Value = new BTreeMapT4()
                    {
                        Value = new BaseVec<BaseTuple<BoundedVecT21, BoundedVecT22>>([])
                    }
                }
            };

            var method = BucketsCalls.CreateNamespace(
                namespaceId,
                metadata
            );

            return client.SubmitExtrinsicAsync(method, account, callback, token: token);
        }

        public static Task CreateBucketAsync(SubstrateClientExt client, Account account, Action<string, ExtrinsicStatus> callback, U128 namespaceId, AssetDidCommBucketInput bucket, CancellationToken token)
        {
            // POST /api/v1/extrinsics/create-bucket

            var metadata = new BucketMetadataInput
            {
                Name = bucket.NameVec,
                Category = new BoundedVecT23
                {
                    Value = new BaseVec<U8>([])
                },
                Properties = new BoundedBTreeMapT1
                {
                    Value = new BTreeMapT4()
                    {
                        Value = new BaseVec<BaseTuple<BoundedVecT21, BoundedVecT22>>([])
                    }
                }
            };

            var method = BucketsCalls.CreateBucket(
                namespaceId,
                metadata
            );

            return client.SubmitExtrinsicAsync(method, account, callback, token: token);
        }
    }
}
