using Kilt.NetApi.Generated.Model.did.did_details;
using Kilt.NetApi.Generated.Model.sp_core.crypto;
using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;

namespace PlutoFramework.Model
{
    public class DidModel
    {
        public static AccountId32 ToAccountId32(Account account)
        {
            var accountId = new AccountId32();
            accountId.Create(Utils.GetPublicKeyFrom(account.Value));
            return accountId;
        }
        public static Method Create(Account account, Account did)
        {
            var details = new DidCreationDetails
            {
                Did = ToAccountId32(did),
                Submitter = ToAccountId32(account),
            };

            var rawSignature = did.Sign(details.Encode());

            EnumDidSignature signature = new EnumDidSignature();
            signature.Create(
                did.KeyType switch
                {
                    KeyType.Sr25519 => DidSignature.Sr25519,
                    KeyType.Ed25519 => DidSignature.Ed25519,
                    _ => throw new Exception("Unsupported KeyType for DID"),
                }
            );

            return Kilt.NetApi.Generated.Storage.DidCalls.Create(details, signature);
        }
    }
}
