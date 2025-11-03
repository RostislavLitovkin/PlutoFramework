using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;
using Substrate.NetApi;
using Substrate.NetApi.Extensions;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using UniqueryPlus;
using XcavatePaseo.NetApi.Generated;
using XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_btree_map;
using XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec;
using XcavatePaseo.NetApi.Generated.Model.pallet_bucket.types;
using XcavatePaseo.NetApi.Generated.Model.sp_core.crypto;
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

    public record AssetDidCommBucket : AssetDidCommBucketInput
    {
        public required U128 BucketId { get; set; }
        public required U128 NamespaceId { get; set; }
    }

    public record StorageUploadRequest
    {
        [JsonPropertyName("data")]
        public required string Data { get; set; }

        [JsonPropertyName("contentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("filename")]
        public string? Filename { get; set; }
    }

    public record StorageUploadResponse
    {
        [JsonPropertyName("success")]
        public required bool Success { get; set; }

        [JsonPropertyName("data")]
        public StorageUploadResponseData? Data { get; set; }
    }

    public record StorageUploadResponseData
    {
        [JsonPropertyName("cid")]
        public required string Cid { get; set; }

        [JsonPropertyName("size")]
        public required int Size { get; set; }

        [JsonPropertyName("filename")]
        public required string Filename { get; set; }
    }

    public record JWK
    {
        [JsonPropertyName("kty")]
        public required string Kty { get; set; }

        [JsonPropertyName("crv")]
        public required string Crv { get; set; }

        [JsonPropertyName("x")]
        public required string X { get; set; }

        [JsonPropertyName("d")]
        public string? D { get; set; }

        [JsonPropertyName("use")]
        public required string Use { get; set; }
    }
    public record KeySharingMessage
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("createdTime")]
        public ulong? CreatedTime { get; set; }

        [JsonPropertyName("expiresTime")]
        public ulong? ExpiresTime { get; set; }

        [JsonPropertyName("to")]
        public List<string>? To { get; set; }

        [JsonPropertyName("from")]
        public string? From { get; set; }

        [JsonPropertyName("keys")]
        public required List<JWK> Keys { get; set; }
    }


    public class AssetDidCommModel
    {
        private const string API_URL = "https://gr4wnsrwnk.execute-api.eu-west-1.amazonaws.com/prod";
        public static (Method, U128) CreateNamespace(AssetDidCommNamespaceInput name)
        {
            var namespaceId = new U128();
            namespaceId.Create(new byte[16].Populate());

            // POST /api/v1/extrinsics/create-namespace

            var metadata = new NamespaceMetadataInput
            {
                Name = name.NameVec,
                SchemaUri = new BaseOpt<BoundedVecT20>(),
                Properties = new BoundedBTreeMapT3
                {
                    Value = new BTreeMapT6()
                    {
                        Value = new BaseVec<BaseTuple<BoundedVecT21, BoundedVecT22>>([])
                    }
                }
            };

            var createNamespaceMethod =  BucketsCalls.CreateNamespace(
                namespaceId,
                metadata
            );

            return (createNamespaceMethod, namespaceId);
        }

        public static Method CreateBucket(U128 namespaceId, AssetDidCommBucketInput bucket)
        {
            // POST /api/v1/extrinsics/create-bucket

            var metadata = new BucketMetadataInput
            {
                Name = bucket.NameVec,
                Category = new BoundedVecT23
                {
                    Value = new BaseVec<U8>([])
                },
                Properties = new BoundedBTreeMapT3
                {
                    Value = new BTreeMapT6()
                    {
                        Value = new BaseVec<BaseTuple<BoundedVecT21, BoundedVecT22>>([])
                    }
                }
            };

            return BucketsCalls.CreateBucket(
                namespaceId,
                metadata
            );
        }

        /// <summary>
        /// Called by Manager
        /// </summary>
        public static Method AddAdmin(U128 namespaceId, U128 bucketId, string admin)
        {
            // POST /api/v1/extrinsics/add-admin

            AccountId32 adminAccount = new AccountId32();
            adminAccount.Create(Utils.GetPublicKeyFrom(admin));

            return BucketsCalls.AddAdmin(
                namespaceId,
                bucketId,
                adminAccount
            );
        }

        /// <summary>
        /// Called by Admin
        /// </summary>
        public static Method AddContributor(U128 namespaceId, U128 bucketId, string contributor)
        {
            // POST /api/v1/extrinsics/add-contributor

            AccountId32 contributorAccount = new AccountId32();
            contributorAccount.Create(Utils.GetPublicKeyFrom(contributor));

            return BucketsCalls.AddContributor(
                namespaceId,
                bucketId,
                contributorAccount
            );
        }

        public static Method SetBucketKey(U128 namespaceId, U128 bucketId, byte[] publicKey)
        {
            // POST /api/v1/extrinsics/set-bucket-key

            var p = 0;
            var bucketPublicKey = new BucketPublicKey();
            bucketPublicKey.Decode(publicKey, ref p);

            return BucketsCalls.ResumeWriting(
                namespaceId,
                bucketId,
                bucketPublicKey
            );
        }

        public static Method CreateTag(U128 bucketId, string tag)
        {
            var tagVec = new BoundedVecT11
            {
                Value = new BaseVec<U8>(
                        Encoding.UTF8.GetBytes(tag).Select(b => new U8(b)).ToArray()
                    )
            };

            return BucketsCalls.CreateTag(
                bucketId,
                tagVec
            );
        }

        public static async Task<Method> ShareBucketKeyAsync(Kilt.NetApi.Generated.SubstrateClientExt client, U128 namespaceId, U128 bucketId, X25519KeyPair keyPair, string signerAddress, IEnumerable<string> dids, CancellationToken token)
        {
            var queryEncryptionKeysTasks = dids
                .Select(DidModel.DidAddressToSs58Address)
                .Select(did => DidModel.GetEncryptionKeyAsync(client, did, token));

            var recipientEncryptionKeys = (await Task.WhenAll(queryEncryptionKeysTasks));

            var randomId = new U64();
            randomId.Create(new byte[8].Populate());

            var message = new KeySharingMessage
            {
                Id = randomId.Value.ToString(),
                From = signerAddress,
                To = dids.ToList(),
                Keys = [
                    new JWK
                    {
                        Kty = "OKP",
                        Crv = "X25519",
                        X = Convert.ToBase64String(keyPair.PublicKey),
                        D = Convert.ToBase64String(keyPair.PrivateKey),
                        Use = "enc"
                    }
                ]
            };

            var plaintextBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

            var jwe = JweModel.Encrypt(plaintextBytes, recipientEncryptionKeys);

            var writeMethod = await WriteMessageAsync(namespaceId, bucketId, jwe, "didcomm/key-sharing-v1", token);

            return writeMethod;
        }


        public static Task<Method> WriteMessageAsync(U128 namespaceId, U128 bucketId, string message, string tag, CancellationToken token = default)
        {
            var base64message = Convert.ToBase64String(Encoding.UTF8.GetBytes(message));

            var upload = new StorageUploadRequest
            {
                Data = base64message,
                ContentType = "application/text",
                Filename = "test.txt"
            };

            return UploadAsync(namespaceId, bucketId, upload, tag, token);
        }

        public static async Task<Method> UploadAsync(U128 namespaceId, U128 bucketId, StorageUploadRequest upload, string tag, CancellationToken token)
        {
            var serialized = JsonSerializer.Serialize(upload);

            HttpContent content = new StringContent(
                serialized,
                Encoding.UTF8,
                "application/json"
            );

            var client = new HttpClient();

            // POST /api/v1/storage/upload
            var response = await client.PostAsync($"{API_URL}/api/v1/storage/upload", content, token);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var uploadResponse = JsonSerializer.Deserialize<StorageUploadResponse>(await response.Content.ReadAsStringAsync());

            if (!uploadResponse?.Success ?? true)
            {
                throw new Exception("Upload was not successful");
            }

            if (uploadResponse is null || uploadResponse.Data is null)
            {
                throw new Exception("Upload response is null");
            }

            var messageInput = new MessageInput
            {
                Reference = new BoundedVecT11
                {
                    Value = new BaseVec<U8>(
                        Encoding.UTF8.GetBytes(uploadResponse.Data.Cid).Select(b => new U8(b)).ToArray()
                    )
                },
                Tag = new BaseOpt<BoundedVecT11>(
                    new BoundedVecT11
                    {
                        Value = new BaseVec<U8>(
                            Encoding.UTF8.GetBytes(tag).Select(b => new U8(b)).ToArray()
                        )
                    }
                ),
                MetadataInput = new MessageMetadataInput
                {
                    Description = new BoundedVecT19
                    {
                        Value = new BaseVec<U8>(
                            Encoding.UTF8.GetBytes(upload.Filename ?? "").Select(b => new U8(b)).ToArray()
                        )
                    },
                    ContentType = new BoundedVecT23
                    {
                        Value = new BaseVec<U8>(
                            Encoding.UTF8.GetBytes(upload.ContentType ?? "").Select(b => new U8(b)).ToArray()
                        )
                    },
                    Properties = new BoundedBTreeMapT3
                    {
                        Value = new BTreeMapT6()
                        {
                            Value = new BaseVec<BaseTuple<BoundedVecT21, BoundedVecT22>>([])
                        }
                    }
                }
            };

            return BucketsCalls.Write(
                namespaceId,
                bucketId,
                messageInput
            );
        }

        public static async Task<byte[]> GetPublicKeyAsync(U128 namespaceId, U128 bucketId)
        {
            // GET /api/v1/buckets/{id}?entityId={id}

            var client = new HttpClient();

            var response = await client.GetAsync($"{API_URL}/api/v1/buckets/{bucketId.Value}?entityId={namespaceId.Value}");

            Console.WriteLine(response);

            // TODO
            return [];
        }

        public static async Task<RecursiveReturn<AssetDidCommBucket>> GetAllBucketsInNamespaceAsync(SubstrateClientExt client, U128 namespaceId, uint limit, byte[]? lastKey, CancellationToken token)
        {
            // 0x + Twox64 pallet + Twox64 storage + Blake2_128Concat U128
            var keyPrefixLength = 130;

            var keyPrefix = Utils.HexToByteArray(BucketsStorage.BucketsParams(new BaseTuple<U128, U128>(namespaceId, new U128(0))).Substring(0, keyPrefixLength));

            var fullKeys = await client.State.GetKeysPagedAsync(keyPrefix, limit, lastKey, string.Empty, token).ConfigureAwait(false);

            // No more nfts found
            if (fullKeys == null || !fullKeys.Any())
            {
                return new RecursiveReturn<AssetDidCommBucket>
                {
                    Items = [],
                    LastKey = lastKey,
                };
            }

            var idKeys = fullKeys.Select(p => p.ToString().Substring(keyPrefixLength));

            var storageChangeSets = await client.State.GetQueryStorageAtAsync(fullKeys.Select(p => Utils.HexToByteArray(p.ToString())).ToList(), string.Empty, token).ConfigureAwait(false);

            var buckets = new List<AssetDidCommBucket>();

            foreach (var change in storageChangeSets.First().Changes)
            {
                if (change[1] == null)
                {
                    continue;
                }

                var bucket = new Bucket();
                bucket.Create(change[1]);


                int p = 32 + 16;
                var namespaceIdDecoded = new U128();
                namespaceIdDecoded.Decode(Utils.HexToByteArray(change[0]), ref p);

                p = 32 + 48;
                var bucketIdDecoded = new U128();
                bucketIdDecoded.Decode(Utils.HexToByteArray(change[0]), ref p);

                Console.WriteLine(change[0]);

                buckets.Add(new AssetDidCommBucket
                {
                    Name = Encoding.UTF8.GetString(bucket.Metadata.Name.Value.Value.Select(u8 => u8.Value).ToArray()),
                    NamespaceId = namespaceIdDecoded,
                    BucketId = bucketIdDecoded,
                });
            }

            return new RecursiveReturn<AssetDidCommBucket>
            {
                Items = buckets,
                LastKey = Utils.HexToByteArray(fullKeys.Last().ToString())
            };
        }
    }
}
