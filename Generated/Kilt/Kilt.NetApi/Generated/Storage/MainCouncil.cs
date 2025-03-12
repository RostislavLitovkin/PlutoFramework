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
    /// >> CouncilStorage
    /// </summary>
    public sealed class CouncilStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> CouncilStorage Constructor
        /// </summary>
        public CouncilStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Council", "Proposals"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT33)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Council", "ProposalOf"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Kilt.NetApi.Generated.Model.primitive_types.H256), typeof(Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Council", "Voting"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, typeof(Kilt.NetApi.Generated.Model.primitive_types.H256), typeof(Kilt.NetApi.Generated.Model.pallet_collective.Votes)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Council", "ProposalCount"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Council", "Members"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Council", "Prime"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32)));
        }
        
        /// <summary>
        /// >> ProposalsParams
        ///  The hashes of the active proposals.
        /// </summary>
        public static string ProposalsParams()
        {
            return RequestGenerator.GetStorage("Council", "Proposals", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ProposalsDefault
        /// Default value as hex string
        /// </summary>
        public static string ProposalsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Proposals
        ///  The hashes of the active proposals.
        /// </summary>
        public async Task<Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT33> Proposals(string blockhash, CancellationToken token)
        {
            string parameters = CouncilStorage.ProposalsParams();
            var result = await _client.GetStorageAsync<Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT33>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> ProposalOfParams
        ///  Actual proposal for a given hash, if it's current.
        /// </summary>
        public static string ProposalOfParams(Kilt.NetApi.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Council", "ProposalOf", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ProposalOfDefault
        /// Default value as hex string
        /// </summary>
        public static string ProposalOfDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ProposalOf
        ///  Actual proposal for a given hash, if it's current.
        /// </summary>
        public async Task<Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall> ProposalOf(Kilt.NetApi.Generated.Model.primitive_types.H256 key, string blockhash, CancellationToken token)
        {
            string parameters = CouncilStorage.ProposalOfParams(key);
            var result = await _client.GetStorageAsync<Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> VotingParams
        ///  Votes on a given proposal, if it is ongoing.
        /// </summary>
        public static string VotingParams(Kilt.NetApi.Generated.Model.primitive_types.H256 key)
        {
            return RequestGenerator.GetStorage("Council", "Voting", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Identity}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> VotingDefault
        /// Default value as hex string
        /// </summary>
        public static string VotingDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Voting
        ///  Votes on a given proposal, if it is ongoing.
        /// </summary>
        public async Task<Kilt.NetApi.Generated.Model.pallet_collective.Votes> Voting(Kilt.NetApi.Generated.Model.primitive_types.H256 key, string blockhash, CancellationToken token)
        {
            string parameters = CouncilStorage.VotingParams(key);
            var result = await _client.GetStorageAsync<Kilt.NetApi.Generated.Model.pallet_collective.Votes>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> ProposalCountParams
        ///  Proposals so far.
        /// </summary>
        public static string ProposalCountParams()
        {
            return RequestGenerator.GetStorage("Council", "ProposalCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ProposalCountDefault
        /// Default value as hex string
        /// </summary>
        public static string ProposalCountDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> ProposalCount
        ///  Proposals so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ProposalCount(string blockhash, CancellationToken token)
        {
            string parameters = CouncilStorage.ProposalCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> MembersParams
        ///  The current members of the collective. This is stored sorted (just by value).
        /// </summary>
        public static string MembersParams()
        {
            return RequestGenerator.GetStorage("Council", "Members", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> MembersDefault
        /// Default value as hex string
        /// </summary>
        public static string MembersDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Members
        ///  The current members of the collective. This is stored sorted (just by value).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32>> Members(string blockhash, CancellationToken token)
        {
            string parameters = CouncilStorage.MembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> PrimeParams
        ///  The prime member that helps determine the default vote behavior in case of absentations.
        /// </summary>
        public static string PrimeParams()
        {
            return RequestGenerator.GetStorage("Council", "Prime", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> PrimeDefault
        /// Default value as hex string
        /// </summary>
        public static string PrimeDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Prime
        ///  The prime member that helps determine the default vote behavior in case of absentations.
        /// </summary>
        public async Task<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32> Prime(string blockhash, CancellationToken token)
        {
            string parameters = CouncilStorage.PrimeParams();
            var result = await _client.GetStorageAsync<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> CouncilCalls
    /// </summary>
    public sealed class CouncilCalls
    {
        
        /// <summary>
        /// >> set_members
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SetMembers(Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32> new_members, Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32> prime, Substrate.NetApi.Model.Types.Primitive.U32 old_count)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(new_members.Encode());
            byteArray.AddRange(prime.Encode());
            byteArray.AddRange(old_count.Encode());
            return new Method(31, "Council", 0, "set_members", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> execute
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Execute(Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall proposal, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> length_bound)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(proposal.Encode());
            byteArray.AddRange(length_bound.Encode());
            return new Method(31, "Council", 1, "execute", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> propose
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Propose(Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> threshold, Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall proposal, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> length_bound)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(threshold.Encode());
            byteArray.AddRange(proposal.Encode());
            byteArray.AddRange(length_bound.Encode());
            return new Method(31, "Council", 2, "propose", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> vote
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Vote(Kilt.NetApi.Generated.Model.primitive_types.H256 proposal, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> index, Substrate.NetApi.Model.Types.Primitive.Bool approve)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(proposal.Encode());
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(approve.Encode());
            return new Method(31, "Council", 3, "vote", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> disapprove_proposal
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method DisapproveProposal(Kilt.NetApi.Generated.Model.primitive_types.H256 proposal_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(proposal_hash.Encode());
            return new Method(31, "Council", 5, "disapprove_proposal", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> close
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Close(Kilt.NetApi.Generated.Model.primitive_types.H256 proposal_hash, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> index, Kilt.NetApi.Generated.Model.sp_weights.weight_v2.Weight proposal_weight_bound, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> length_bound)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(proposal_hash.Encode());
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(proposal_weight_bound.Encode());
            byteArray.AddRange(length_bound.Encode());
            return new Method(31, "Council", 6, "close", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> CouncilConstants
    /// </summary>
    public sealed class CouncilConstants
    {
        
        /// <summary>
        /// >> MaxProposalWeight
        ///  The maximum weight of a dispatch call that can be proposed and executed.
        /// </summary>
        public Kilt.NetApi.Generated.Model.sp_weights.weight_v2.Weight MaxProposalWeight()
        {
            var result = new Kilt.NetApi.Generated.Model.sp_weights.weight_v2.Weight();
            result.Create("0x07004429353A0200A000");
            return result;
        }
    }
    
    /// <summary>
    /// >> CouncilErrors
    /// </summary>
    public enum CouncilErrors
    {
        
        /// <summary>
        /// >> NotMember
        /// Account is not a member
        /// </summary>
        NotMember,
        
        /// <summary>
        /// >> DuplicateProposal
        /// Duplicate proposals not allowed
        /// </summary>
        DuplicateProposal,
        
        /// <summary>
        /// >> ProposalMissing
        /// Proposal must exist
        /// </summary>
        ProposalMissing,
        
        /// <summary>
        /// >> WrongIndex
        /// Mismatched index
        /// </summary>
        WrongIndex,
        
        /// <summary>
        /// >> DuplicateVote
        /// Duplicate vote ignored
        /// </summary>
        DuplicateVote,
        
        /// <summary>
        /// >> AlreadyInitialized
        /// Members are already initialized!
        /// </summary>
        AlreadyInitialized,
        
        /// <summary>
        /// >> TooEarly
        /// The close call was made too early, before the end of the voting.
        /// </summary>
        TooEarly,
        
        /// <summary>
        /// >> TooManyProposals
        /// There can only be a maximum of `MaxProposals` active proposals.
        /// </summary>
        TooManyProposals,
        
        /// <summary>
        /// >> WrongProposalWeight
        /// The given weight bound for the proposal was too low.
        /// </summary>
        WrongProposalWeight,
        
        /// <summary>
        /// >> WrongProposalLength
        /// The given length bound for the proposal was too low.
        /// </summary>
        WrongProposalLength,
        
        /// <summary>
        /// >> PrimeAccountNotMember
        /// Prime account is not a member
        /// </summary>
        PrimeAccountNotMember,
    }
}
