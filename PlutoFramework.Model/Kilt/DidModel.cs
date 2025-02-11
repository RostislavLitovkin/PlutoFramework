using Kilt.NetApi.Generated.Model.bounded_collections.bounded_btree_set;
using Kilt.NetApi.Generated.Model.did.did_details;
using Kilt.NetApi.Generated.Model.did.service_endpoints;
using Kilt.NetApi.Generated.Model.sp_core.crypto;
using Kilt.NetApi.Generated.Types.Base;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace PlutoFramework.Model
{
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
                        Value = new BaseVec<EnumDidEncryptionKey>(new EnumDidEncryptionKey[] {}),
                    }
                },

                NewAttestationKey = new BaseOpt<EnumDidVerificationKey>(),
                NewDelegationKey = new BaseOpt<EnumDidVerificationKey>(),
                NewServiceDetails = new BaseVec<DidEndpoint>(new DidEndpoint[] {}),
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
                did.KeyType switch {
                    KeyType.Sr25519 => new Kilt.NetApi.Generated.Model.sp_core.sr25519.Signature { Value = rawSignature.ToArr64U8() },
                    KeyType.Ed25519 => new Kilt.NetApi.Generated.Model.sp_core.ed25519.Signature { Value = rawSignature.ToArr64U8() },
                    _ => throw new Exception("Unsupported KeyType for DID"),
                }
            );

            return Kilt.NetApi.Generated.Storage.DidCalls.Create(details, signature);
        }
    }
}
