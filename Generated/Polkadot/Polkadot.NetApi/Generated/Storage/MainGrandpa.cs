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


namespace Polkadot.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> GrandpaStorage
    /// </summary>
    public sealed class GrandpaStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> GrandpaStorage Constructor
        /// </summary>
        public GrandpaStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Grandpa", "State"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkadot.NetApi.Generated.Model.pallet_grandpa.EnumStoredState)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Grandpa", "PendingChange"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkadot.NetApi.Generated.Model.pallet_grandpa.StoredPendingChange)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Grandpa", "NextForced"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Grandpa", "Stalled"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Grandpa", "CurrentSetId"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U64)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Grandpa", "SetIdSession"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Primitive.U64), typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Grandpa", "Authorities"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Polkadot.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3)));
        }
        
        /// <summary>
        /// >> StateParams
        ///  State of the current authority set.
        /// </summary>
        public static string StateParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "State", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> StateDefault
        /// Default value as hex string
        /// </summary>
        public static string StateDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> State
        ///  State of the current authority set.
        /// </summary>
        public async Task<Polkadot.NetApi.Generated.Model.pallet_grandpa.EnumStoredState> State(string blockhash, CancellationToken token)
        {
            string parameters = GrandpaStorage.StateParams();
            var result = await _client.GetStorageAsync<Polkadot.NetApi.Generated.Model.pallet_grandpa.EnumStoredState>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> PendingChangeParams
        ///  Pending change: (signaled at, scheduled change).
        /// </summary>
        public static string PendingChangeParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "PendingChange", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> PendingChangeDefault
        /// Default value as hex string
        /// </summary>
        public static string PendingChangeDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> PendingChange
        ///  Pending change: (signaled at, scheduled change).
        /// </summary>
        public async Task<Polkadot.NetApi.Generated.Model.pallet_grandpa.StoredPendingChange> PendingChange(string blockhash, CancellationToken token)
        {
            string parameters = GrandpaStorage.PendingChangeParams();
            var result = await _client.GetStorageAsync<Polkadot.NetApi.Generated.Model.pallet_grandpa.StoredPendingChange>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> NextForcedParams
        ///  next block number where we can force a change.
        /// </summary>
        public static string NextForcedParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "NextForced", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NextForcedDefault
        /// Default value as hex string
        /// </summary>
        public static string NextForcedDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> NextForced
        ///  next block number where we can force a change.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> NextForced(string blockhash, CancellationToken token)
        {
            string parameters = GrandpaStorage.NextForcedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> StalledParams
        ///  `true` if we are currently stalled.
        /// </summary>
        public static string StalledParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "Stalled", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> StalledDefault
        /// Default value as hex string
        /// </summary>
        public static string StalledDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Stalled
        ///  `true` if we are currently stalled.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>> Stalled(string blockhash, CancellationToken token)
        {
            string parameters = GrandpaStorage.StalledParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> CurrentSetIdParams
        ///  The number of changes (both in terms of keys and underlying economic responsibilities)
        ///  in the "set" of Grandpa validators from genesis.
        /// </summary>
        public static string CurrentSetIdParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "CurrentSetId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> CurrentSetIdDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrentSetIdDefault()
        {
            return "0x0000000000000000";
        }
        
        /// <summary>
        /// >> CurrentSetId
        ///  The number of changes (both in terms of keys and underlying economic responsibilities)
        ///  in the "set" of Grandpa validators from genesis.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U64> CurrentSetId(string blockhash, CancellationToken token)
        {
            string parameters = GrandpaStorage.CurrentSetIdParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U64>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> SetIdSessionParams
        ///  A mapping from grandpa set ID to the index of the *most recent* session for which its
        ///  members were responsible.
        /// 
        ///  This is only used for validating equivocation proofs. An equivocation proof must
        ///  contains a key-ownership proof for a given session, therefore we need a way to tie
        ///  together sessions and GRANDPA set ids, i.e. we need to validate that a validator
        ///  was the owner of a given key on a given session, and what the active set ID was
        ///  during that session.
        /// 
        ///  TWOX-NOTE: `SetId` is not under user control.
        /// </summary>
        public static string SetIdSessionParams(Substrate.NetApi.Model.Types.Primitive.U64 key)
        {
            return RequestGenerator.GetStorage("Grandpa", "SetIdSession", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SetIdSessionDefault
        /// Default value as hex string
        /// </summary>
        public static string SetIdSessionDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> SetIdSession
        ///  A mapping from grandpa set ID to the index of the *most recent* session for which its
        ///  members were responsible.
        /// 
        ///  This is only used for validating equivocation proofs. An equivocation proof must
        ///  contains a key-ownership proof for a given session, therefore we need a way to tie
        ///  together sessions and GRANDPA set ids, i.e. we need to validate that a validator
        ///  was the owner of a given key on a given session, and what the active set ID was
        ///  during that session.
        /// 
        ///  TWOX-NOTE: `SetId` is not under user control.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> SetIdSession(Substrate.NetApi.Model.Types.Primitive.U64 key, string blockhash, CancellationToken token)
        {
            string parameters = GrandpaStorage.SetIdSessionParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> AuthoritiesParams
        ///  The current list of authorities.
        /// </summary>
        public static string AuthoritiesParams()
        {
            return RequestGenerator.GetStorage("Grandpa", "Authorities", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> AuthoritiesDefault
        /// Default value as hex string
        /// </summary>
        public static string AuthoritiesDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Authorities
        ///  The current list of authorities.
        /// </summary>
        public async Task<Polkadot.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3> Authorities(string blockhash, CancellationToken token)
        {
            string parameters = GrandpaStorage.AuthoritiesParams();
            var result = await _client.GetStorageAsync<Polkadot.NetApi.Generated.Model.bounded_collections.weak_bounded_vec.WeakBoundedVecT3>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> GrandpaCalls
    /// </summary>
    public sealed class GrandpaCalls
    {
        
        /// <summary>
        /// >> report_equivocation
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ReportEquivocation(Polkadot.NetApi.Generated.Model.sp_consensus_grandpa.EquivocationProof equivocation_proof, Polkadot.NetApi.Generated.Model.sp_session.MembershipProof key_owner_proof)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(equivocation_proof.Encode());
            byteArray.AddRange(key_owner_proof.Encode());
            return new Method(11, "Grandpa", 0, "report_equivocation", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> report_equivocation_unsigned
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ReportEquivocationUnsigned(Polkadot.NetApi.Generated.Model.sp_consensus_grandpa.EquivocationProof equivocation_proof, Polkadot.NetApi.Generated.Model.sp_session.MembershipProof key_owner_proof)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(equivocation_proof.Encode());
            byteArray.AddRange(key_owner_proof.Encode());
            return new Method(11, "Grandpa", 1, "report_equivocation_unsigned", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> note_stalled
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method NoteStalled(Substrate.NetApi.Model.Types.Primitive.U32 delay, Substrate.NetApi.Model.Types.Primitive.U32 best_finalized_block_number)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(delay.Encode());
            byteArray.AddRange(best_finalized_block_number.Encode());
            return new Method(11, "Grandpa", 2, "note_stalled", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> GrandpaConstants
    /// </summary>
    public sealed class GrandpaConstants
    {
        
        /// <summary>
        /// >> MaxAuthorities
        ///  Max Authorities in use
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxAuthorities()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xA0860100");
            return result;
        }
        
        /// <summary>
        /// >> MaxNominators
        ///  The maximum number of nominators for each validator.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxNominators()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x00020000");
            return result;
        }
        
        /// <summary>
        /// >> MaxSetIdSessionEntries
        ///  The maximum number of entries to keep in the set id to session index mapping.
        /// 
        ///  Since the `SetIdSession` map is only used for validating equivocations this
        ///  value should relate to the bonding duration of whatever staking system is
        ///  being used (if any). If equivocation handling is not enabled then this value
        ///  can be zero.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 MaxSetIdSessionEntries()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U64();
            result.Create("0xA800000000000000");
            return result;
        }
    }
    
    /// <summary>
    /// >> GrandpaErrors
    /// </summary>
    public enum GrandpaErrors
    {
        
        /// <summary>
        /// >> PauseFailed
        /// Attempt to signal GRANDPA pause when the authority set isn't live
        /// (either paused or already pending pause).
        /// </summary>
        PauseFailed,
        
        /// <summary>
        /// >> ResumeFailed
        /// Attempt to signal GRANDPA resume when the authority set isn't paused
        /// (either live or already pending resume).
        /// </summary>
        ResumeFailed,
        
        /// <summary>
        /// >> ChangePending
        /// Attempt to signal GRANDPA change with one already pending.
        /// </summary>
        ChangePending,
        
        /// <summary>
        /// >> TooSoon
        /// Cannot signal forced change so soon after last.
        /// </summary>
        TooSoon,
        
        /// <summary>
        /// >> InvalidKeyOwnershipProof
        /// A key ownership proof provided as part of an equivocation report is invalid.
        /// </summary>
        InvalidKeyOwnershipProof,
        
        /// <summary>
        /// >> InvalidEquivocationProof
        /// An equivocation proof provided as part of an equivocation report is invalid.
        /// </summary>
        InvalidEquivocationProof,
        
        /// <summary>
        /// >> DuplicateOffenceReport
        /// A given equivocation report is valid but already previously reported.
        /// </summary>
        DuplicateOffenceReport,
    }
}
