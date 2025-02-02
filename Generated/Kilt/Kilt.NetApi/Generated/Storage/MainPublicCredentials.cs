//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Kilt.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> PublicCredentialsStorage
    /// </summary>
    public sealed class PublicCredentialsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> PublicCredentialsStorage Constructor
        /// </summary>
        public PublicCredentialsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("PublicCredentials", "Credentials"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Kilt.NetApi.Generated.Model.runtime_common.assets.AssetDid, Kilt.NetApi.Generated.Model.primitive_types.H256>), typeof(Kilt.NetApi.Generated.Model.public_credentials.credentials.CredentialEntry)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("PublicCredentials", "CredentialSubjects"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Kilt.NetApi.Generated.Model.primitive_types.H256), typeof(Kilt.NetApi.Generated.Model.runtime_common.assets.AssetDid)));
        }
        
        /// <summary>
        /// >> CredentialsParams
        ///  The map of public credentials already attested.
        ///  It maps from a (subject id + credential id) -> the creation
        ///  details of the credential.
        /// </summary>
        public static string CredentialsParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Kilt.NetApi.Generated.Model.runtime_common.assets.AssetDid, Kilt.NetApi.Generated.Model.primitive_types.H256> key)
        {
            return RequestGenerator.GetStorage("PublicCredentials", "Credentials", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, key.Value);
        }
        
        /// <summary>
        /// >> CredentialsDefault
        /// Default value as hex string
        /// </summary>
        public static string CredentialsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Credentials
        ///  The map of public credentials already attested.
        ///  It maps from a (subject id + credential id) -> the creation
        ///  details of the credential.
        /// </summary>
        public async Task<Kilt.NetApi.Generated.Model.public_credentials.credentials.CredentialEntry> Credentials(Substrate.NetApi.Model.Types.Base.BaseTuple<Kilt.NetApi.Generated.Model.runtime_common.assets.AssetDid, Kilt.NetApi.Generated.Model.primitive_types.H256> key, string blockhash, CancellationToken token)
        {
            string parameters = PublicCredentialsStorage.CredentialsParams(key);
            var result = await _client.GetStorageAsync<Kilt.NetApi.Generated.Model.public_credentials.credentials.CredentialEntry>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> CredentialSubjectsParams
        ///  A reverse index mapping from credential ID to the subject the credential
        ///  was issued to.
        /// 
        ///  It it used to perform efficient lookup of credentials given their ID.
        /// </summary>
        public static string CredentialSubjectsParams(Kilt.NetApi.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("PublicCredentials", "CredentialSubjects", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> CredentialSubjectsDefault
        /// Default value as hex string
        /// </summary>
        public static string CredentialSubjectsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> CredentialSubjects
        ///  A reverse index mapping from credential ID to the subject the credential
        ///  was issued to.
        /// 
        ///  It it used to perform efficient lookup of credentials given their ID.
        /// </summary>
        public async Task<Kilt.NetApi.Generated.Model.runtime_common.assets.AssetDid> CredentialSubjects(Kilt.NetApi.Generated.Model.primitive_types.H256 key, string blockhash, CancellationToken token)
        {
            string parameters = PublicCredentialsStorage.CredentialSubjectsParams(key);
            var result = await _client.GetStorageAsync<Kilt.NetApi.Generated.Model.runtime_common.assets.AssetDid>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> PublicCredentialsCalls
    /// </summary>
    public sealed class PublicCredentialsCalls
    {
        
        /// <summary>
        /// >> add
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Add(Kilt.NetApi.Generated.Model.public_credentials.credentials.Credential credential)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(credential.Encode());
            return new Method(69, "PublicCredentials", 0, "add", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> revoke
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Revoke(Kilt.NetApi.Generated.Model.primitive_types.H256 credential_id, Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumPalletAuthorize> authorization)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(credential_id.Encode());
            byteArray.AddRange(authorization.Encode());
            return new Method(69, "PublicCredentials", 1, "revoke", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> unrevoke
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Unrevoke(Kilt.NetApi.Generated.Model.primitive_types.H256 credential_id, Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumPalletAuthorize> authorization)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(credential_id.Encode());
            byteArray.AddRange(authorization.Encode());
            return new Method(69, "PublicCredentials", 2, "unrevoke", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Remove(Kilt.NetApi.Generated.Model.primitive_types.H256 credential_id, Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumPalletAuthorize> authorization)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(credential_id.Encode());
            byteArray.AddRange(authorization.Encode());
            return new Method(69, "PublicCredentials", 3, "remove", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> reclaim_deposit
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ReclaimDeposit(Kilt.NetApi.Generated.Model.primitive_types.H256 credential_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(credential_id.Encode());
            return new Method(69, "PublicCredentials", 4, "reclaim_deposit", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> change_deposit_owner
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ChangeDepositOwner(Kilt.NetApi.Generated.Model.primitive_types.H256 credential_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(credential_id.Encode());
            return new Method(69, "PublicCredentials", 5, "change_deposit_owner", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_deposit
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method UpdateDeposit(Kilt.NetApi.Generated.Model.primitive_types.H256 credential_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(credential_id.Encode());
            return new Method(69, "PublicCredentials", 6, "update_deposit", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> PublicCredentialsConstants
    /// </summary>
    public sealed class PublicCredentialsConstants
    {
        
        /// <summary>
        /// >> Deposit
        ///  The amount of tokens to reserve when attesting a public credential.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x005C6A51FC4500000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxEncodedClaimsLength
        ///  The maximum length in bytes of the encoded claims of a credential.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxEncodedClaimsLength()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xA0860100");
            return result;
        }
        
        /// <summary>
        /// >> MaxSubjectIdLength
        ///  The maximum length in bytes of the raw credential subject
        ///  identifier.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxSubjectIdLength()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x0C010000");
            return result;
        }
    }
    
    /// <summary>
    /// >> PublicCredentialsErrors
    /// </summary>
    public enum PublicCredentialsErrors
    {
        
        /// <summary>
        /// >> AlreadyAttested
        /// A credential with the same root hash has already issued to the
        /// specified subject.
        /// </summary>
        AlreadyAttested,
        
        /// <summary>
        /// >> NotFound
        /// No credential with the specified root hash has been issued to the
        /// specified subject.
        /// </summary>
        NotFound,
        
        /// <summary>
        /// >> UnableToPayFees
        /// Not enough tokens to pay for the fees or the deposit.
        /// </summary>
        UnableToPayFees,
        
        /// <summary>
        /// >> InvalidInput
        /// The credential input is invalid.
        /// </summary>
        InvalidInput,
        
        /// <summary>
        /// >> NotAuthorized
        /// The caller is not authorized to performed the operation.
        /// </summary>
        NotAuthorized,
        
        /// <summary>
        /// >> Internal
        /// Catch-all for any other errors that should not happen, yet it
        /// happened.
        /// </summary>
        Internal,
    }
}
