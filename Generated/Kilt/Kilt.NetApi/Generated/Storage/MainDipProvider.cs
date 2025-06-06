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
    /// >> DipProviderStorage
    /// </summary>
    public sealed class DipProviderStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> DipProviderStorage Constructor
        /// </summary>
        public DipProviderStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("DipProvider", "IdentityCommitments"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16>), typeof(Kilt.NetApi.Generated.Model.primitive_types.H256)));
        }
        
        /// <summary>
        /// >> IdentityCommitmentsParams
        ///  The pallet contains a single storage element, the `IdentityCommitments`
        ///  double map. Its first key is the `Identifier` of subjects, while the
        ///  second key is the commitment version. The values are identity
        ///  commitments.
        /// </summary>
        public static string IdentityCommitmentsParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16> key)
        {
            return RequestGenerator.GetStorage("DipProvider", "IdentityCommitments", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat,
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, key.Value);
        }
        
        /// <summary>
        /// >> IdentityCommitmentsDefault
        /// Default value as hex string
        /// </summary>
        public static string IdentityCommitmentsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> IdentityCommitments
        ///  The pallet contains a single storage element, the `IdentityCommitments`
        ///  double map. Its first key is the `Identifier` of subjects, while the
        ///  second key is the commitment version. The values are identity
        ///  commitments.
        /// </summary>
        public async Task<Kilt.NetApi.Generated.Model.primitive_types.H256> IdentityCommitments(Substrate.NetApi.Model.Types.Base.BaseTuple<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U16> key, string blockhash, CancellationToken token)
        {
            string parameters = DipProviderStorage.IdentityCommitmentsParams(key);
            var result = await _client.GetStorageAsync<Kilt.NetApi.Generated.Model.primitive_types.H256>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> DipProviderCalls
    /// </summary>
    public sealed class DipProviderCalls
    {
        
        /// <summary>
        /// >> commit_identity
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method CommitIdentity(Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32 identifier, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U16> version)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(identifier.Encode());
            byteArray.AddRange(version.Encode());
            return new Method(71, "DipProvider", 0, "commit_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> delete_identity_commitment
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method DeleteIdentityCommitment(Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32 identifier, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U16> version)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(identifier.Encode());
            byteArray.AddRange(version.Encode());
            return new Method(71, "DipProvider", 1, "delete_identity_commitment", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> DipProviderConstants
    /// </summary>
    public sealed class DipProviderConstants
    {
    }
    
    /// <summary>
    /// >> DipProviderErrors
    /// </summary>
    public enum DipProviderErrors
    {
        
        /// <summary>
        /// >> CommitmentNotFound
        /// The specified commitment cannot be found.
        /// </summary>
        CommitmentNotFound,
        
        /// <summary>
        /// >> IdentityProvider
        /// Error when retrieving the identity details of the provided subject.
        /// </summary>
        IdentityProvider,
        
        /// <summary>
        /// >> IdentityCommitmentGenerator
        /// Error when generating a commitment for the retrieved identity.
        /// </summary>
        IdentityCommitmentGenerator,
        
        /// <summary>
        /// >> Hook
        /// Error inside the external hook logic.
        /// </summary>
        Hook,
    }
}
