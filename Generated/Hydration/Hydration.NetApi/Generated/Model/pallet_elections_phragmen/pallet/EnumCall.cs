//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Hydration.NetApi.Generated.Model.pallet_elections_phragmen.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> vote
        /// Vote for a set of candidates for the upcoming round of election. This can be called to
        /// set the initial votes, or update already existing votes.
        /// 
        /// Upon initial voting, `value` units of `who`'s balance is locked and a deposit amount is
        /// reserved. The deposit is based on the number of votes and can be updated over time.
        /// 
        /// The `votes` should:
        ///   - not be empty.
        ///   - be less than the number of possible candidates. Note that all current members and
        ///     runners-up are also automatically candidates for the next round.
        /// 
        /// If `value` is more than `who`'s free balance, then the maximum of the two is used.
        /// 
        /// The dispatch origin of this call must be signed.
        /// 
        /// ### Warning
        /// 
        /// It is the responsibility of the caller to **NOT** place all of their balance into the
        /// lock and keep some for further operations.
        /// </summary>
        vote = 0,
        
        /// <summary>
        /// >> remove_voter
        /// Remove `origin` as a voter.
        /// 
        /// This removes the lock and returns the deposit.
        /// 
        /// The dispatch origin of this call must be signed and be a voter.
        /// </summary>
        remove_voter = 1,
        
        /// <summary>
        /// >> submit_candidacy
        /// Submit oneself for candidacy. A fixed amount of deposit is recorded.
        /// 
        /// All candidates are wiped at the end of the term. They either become a member/runner-up,
        /// or leave the system while their deposit is slashed.
        /// 
        /// The dispatch origin of this call must be signed.
        /// 
        /// ### Warning
        /// 
        /// Even if a candidate ends up being a member, they must call [`Call::renounce_candidacy`]
        /// to get their deposit back. Losing the spot in an election will always lead to a slash.
        /// 
        /// The number of current candidates must be provided as witness data.
        /// ## Complexity
        /// O(C + log(C)) where C is candidate_count.
        /// </summary>
        submit_candidacy = 2,
        
        /// <summary>
        /// >> renounce_candidacy
        /// Renounce one's intention to be a candidate for the next election round. 3 potential
        /// outcomes exist:
        /// 
        /// - `origin` is a candidate and not elected in any set. In this case, the deposit is
        ///   unreserved, returned and origin is removed as a candidate.
        /// - `origin` is a current runner-up. In this case, the deposit is unreserved, returned and
        ///   origin is removed as a runner-up.
        /// - `origin` is a current member. In this case, the deposit is unreserved and origin is
        ///   removed as a member, consequently not being a candidate for the next round anymore.
        ///   Similar to [`remove_member`](Self::remove_member), if replacement runners exists, they
        ///   are immediately used. If the prime is renouncing, then no prime will exist until the
        ///   next round.
        /// 
        /// The dispatch origin of this call must be signed, and have one of the above roles.
        /// The type of renouncing must be provided as witness data.
        /// 
        /// ## Complexity
        ///   - Renouncing::Candidate(count): O(count + log(count))
        ///   - Renouncing::Member: O(1)
        ///   - Renouncing::RunnerUp: O(1)
        /// </summary>
        renounce_candidacy = 3,
        
        /// <summary>
        /// >> remove_member
        /// Remove a particular member from the set. This is effective immediately and the bond of
        /// the outgoing member is slashed.
        /// 
        /// If a runner-up is available, then the best runner-up will be removed and replaces the
        /// outgoing member. Otherwise, if `rerun_election` is `true`, a new phragmen election is
        /// started, else, nothing happens.
        /// 
        /// If `slash_bond` is set to true, the bond of the member being removed is slashed. Else,
        /// it is returned.
        /// 
        /// The dispatch origin of this call must be root.
        /// 
        /// Note that this does not affect the designated block number of the next election.
        /// 
        /// ## Complexity
        /// - Check details of remove_and_replace_member() and do_phragmen().
        /// </summary>
        remove_member = 4,
        
        /// <summary>
        /// >> clean_defunct_voters
        /// Clean all voters who are defunct (i.e. they do not serve any purpose at all). The
        /// deposit of the removed voters are returned.
        /// 
        /// This is an root function to be used only for cleaning the state.
        /// 
        /// The dispatch origin of this call must be root.
        /// 
        /// ## Complexity
        /// - Check is_defunct_voter() details.
        /// </summary>
        clean_defunct_voters = 5,
    }
    
    /// <summary>
    /// >> 337 - Variant[pallet_elections_phragmen.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.vote);
				AddTypeDecoder<BaseVoid>(Call.remove_voter);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(Call.submit_candidacy);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.pallet_elections_phragmen.EnumRenouncing>(Call.renounce_candidacy);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.Bool, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.remove_member);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.clean_defunct_voters);
        }
    }
}
