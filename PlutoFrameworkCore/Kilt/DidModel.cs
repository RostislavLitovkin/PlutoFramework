using Kilt.NetApi.Generated.Model.bounded_collections.bounded_btree_set;
using Kilt.NetApi.Generated.Model.did.did_details;
using Kilt.NetApi.Generated.Model.did.service_endpoints;
using Kilt.NetApi.Generated.Model.sp_core.crypto;
using Kilt.NetApi.Generated.Types.Base;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Kilt.NetApi.Generated.Model.primitive_types;
using Substrate.NetApi.Model.Types.Primitive;
using Kilt.NetApi.Generated.Storage;

namespace PlutoFramework.Model
{

    public record DidInfo
    {
        public required string DidAddress { get; init; }
        public required IEnumerable<byte[]> EncryptionKeys { get; init; }
    }
    public static class DidModel
    {
        private static AccountId32 ToAccountId32(this Account account)
        {
            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(account.Value));
            return accountId;
        }

        private static Arr64U8 ToArr64U8(this byte[] bytes)
        {
            var arr = new Arr64U8();
            var p = 0;
            arr.Decode(bytes, ref p);

            return arr;
        }

        public static AccountId32 DidAddressToAccountId32(string didAddress)
        {
            if (didAddress.Contains("did:kilt:"))
            {
                didAddress = didAddress.Remove(0, 9);
            }

            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(didAddress));
            return accountId;
        }

        public static string ToDidAddress(this Account account) => $"did:kilt:{Utils.GetAddressFrom(Utils.GetPublicKeyFrom(account.Value), 38)}";

        public static Method Create(Account account, Account did)
        {
            var details = new DidCreationDetails
            {
                Did = did.ToAccountId32(),
                Submitter = account.ToAccountId32(),

                NewKeyAgreementKeys = new BoundedBTreeSetT1
                {
                    Value = new BTreeSetT1
                    {
                        Value = new BaseVec<EnumDidEncryptionKey>(new EnumDidEncryptionKey[] { }),
                    }
                },

                NewAttestationKey = new BaseOpt<EnumDidVerificationKey>(),
                NewDelegationKey = new BaseOpt<EnumDidVerificationKey>(),
                NewServiceDetails = new BaseVec<DidEndpoint>(new DidEndpoint[] { }),
            };

            var rawSignature = did.Sign(details.Encode());

            EnumDidSignature signature = new EnumDidSignature();
            signature.Create(
                did.KeyType switch
                {
                    KeyType.Sr25519 => DidSignature.Sr25519,
                    KeyType.Ed25519 => DidSignature.Ed25519,
                    _ => throw new Exception("Unsupported KeyType for DID"),
                },
                rawSignature.ToArr64U8()
            );

            return Kilt.NetApi.Generated.Storage.DidCalls.Create(details, signature);
        }

        public static Method Create(Account account, Account did, byte[] x25519PublicKey)
        {
            var encryptionKey = new EnumDidEncryptionKey();
            encryptionKey.Create(DidEncryptionKey.X25519, new Arr32U8
            {
                Value = x25519PublicKey.Select(b => new U8(b)).ToArray()
            });

            var details = new DidCreationDetails
            {
                Did = did.ToAccountId32(),
                Submitter = account.ToAccountId32(),

                NewKeyAgreementKeys = new BoundedBTreeSetT1
                {
                    Value = new BTreeSetT1
                    {
                        Value = new BaseVec<EnumDidEncryptionKey>([
                            encryptionKey
                        ]),
                    }
                },

                NewAttestationKey = new BaseOpt<EnumDidVerificationKey>(),
                NewDelegationKey = new BaseOpt<EnumDidVerificationKey>(),
                NewServiceDetails = new BaseVec<DidEndpoint>(new DidEndpoint[] { }),
            };

            var rawSignature = did.Sign(details.Encode());

            EnumDidSignature signature = new EnumDidSignature();
            signature.Create(
                did.KeyType switch
                {
                    KeyType.Sr25519 => DidSignature.Sr25519,
                    KeyType.Ed25519 => DidSignature.Ed25519,
                    _ => throw new Exception("Unsupported KeyType for DID"),
                },
                rawSignature.ToArr64U8()
            );

            return Kilt.NetApi.Generated.Storage.DidCalls.Create(details, signature);
        }

        public static Method AddEncryptionKey(byte[] x25519PublicKey)
        {
            var encryptionKey = new EnumDidEncryptionKey();
            encryptionKey.Create(DidEncryptionKey.X25519, new Arr32U8
            {
                Value = x25519PublicKey.Select(b => new U8(b)).ToArray()
            });

            return DidCalls.AddKeyAgreementKey(encryptionKey);
        }

        public static string DidAddressToSs58Address(string didAddress)
        {
            if (didAddress.Contains("did:kilt:"))
            {
                return didAddress.Remove(0, 9);
            }

            return didAddress;
        }

        public static async Task<DidInfo> GetDidAsync(Kilt.NetApi.Generated.SubstrateClientExt client, string didAddress, CancellationToken token)
        {
            var ss58Address = DidAddressToSs58Address(didAddress);

            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(ss58Address));

            var did = await client.DidStorage.Did(accountId, null, token);

            var encryptionKeys = did.KeyAgreementKeys.Value.Value.Value.Select(keyHash =>
            {
                var encodedHash = Utils.Bytes2HexString(keyHash.Encode());
                return did.PublicKeys.Value.Value.Value.Where(
                    pair => Utils.Bytes2HexString(((H256)pair.Value[0]).Encode()) == encodedHash
                ).First();
            })
                .Select(pair => (DidPublicKeyDetails)pair.Value[1])
                .Where(details => details.Key.Value == DidPublicKey.PublicEncryptionKey)
                .Select(encryptionKey => ((EnumDidEncryptionKey)encryptionKey.Key.Value2).Value2.Encode());

            return new DidInfo
            {
                DidAddress = $"did:kilt:{ss58Address}",
                EncryptionKeys = encryptionKeys,
            };
        }

        public static async Task<byte[]> GetEncryptionKeyAsync(Kilt.NetApi.Generated.SubstrateClientExt client, string address, CancellationToken token)
        {
            var did = await GetDidAsync(client, address, token);

            return did.EncryptionKeys.First();
        }
    }
}
