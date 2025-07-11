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


namespace Mythos.NetApi.Generated.Model.pallet_collator_staking.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> set_invulnerables
        /// Set the list of invulnerable (fixed) collators. These collators must:
        ///   - Have registered session keys.
        ///   - Not currently be collator candidates (the call will fail if an entry is already a candidate).
        /// 
        /// If the provided list is empty, it also ensures that the total number of eligible collators
        /// does not fall below the configured minimum.
        /// 
        /// This call does not inherently maintain mutual exclusivity with `Candidates`, but in practice,
        /// accounts that are already candidates will be rejected. If you need to convert a candidate
        /// to be invulnerable, remove them from the set of candidates first, then call this function.
        /// 
        /// Must be called by the `UpdateOrigin`.
        /// </summary>
        set_invulnerables = 0,
        
        /// <summary>
        /// >> set_desired_candidates
        /// Set the ideal number of collators. If lowering this number, then the
        /// number of running collators could be higher than this figure. Aside from that edge case,
        /// there should be no other way to have more candidates than the desired number.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        set_desired_candidates = 1,
        
        /// <summary>
        /// >> set_min_candidacy_bond
        /// Set the candidacy bond amount, which represents the required amount to reserve for an
        /// account to become a candidate. The candidacy bond does not count as stake.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        set_min_candidacy_bond = 2,
        
        /// <summary>
        /// >> register_as_candidate
        /// Register this account as a collator candidate. The account must (a) already have
        /// registered session keys and (b) be able to reserve the `CandidacyBond`.
        /// The `CandidacyBond` amount is automatically reserved from the balance of the caller.
        /// 
        /// This call is not available to `Invulnerable` collators.
        /// </summary>
        register_as_candidate = 3,
        
        /// <summary>
        /// >> leave_intent
        /// Deregister `origin` as a collator candidate. No rewards will be delivered to this
        /// candidate and its stakers after this moment.
        /// 
        /// This call will fail if the total number of candidates would drop below `MinEligibleCollators`.
        /// </summary>
        leave_intent = 4,
        
        /// <summary>
        /// >> add_invulnerable
        /// Add a new account `who` to the list of `Invulnerables` collators. `who` must have
        /// registered session keys. If `who` is a candidate, the operation will be aborted.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        add_invulnerable = 5,
        
        /// <summary>
        /// >> remove_invulnerable
        /// Remove an account `who` from the list of `Invulnerables` collators. `Invulnerables` must
        /// be sorted.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        remove_invulnerable = 6,
        
        /// <summary>
        /// >> stake
        /// Allows a user to stake on a set of collator candidates.
        /// 
        /// The call will fail if:
        ///     - `origin` does not have the at least [`MinStake`] deposited in the candidate.
        ///     - one of the `targets` is not in the [`Candidates`] map.
        ///     - the user does not have sufficient locked balance to stake.
        ///     - zero targets are passed.
        /// </summary>
        stake = 7,
        
        /// <summary>
        /// >> unstake_from
        /// Removes stake from a collator candidate.
        /// 
        /// The amount unstaked will remain locked if the stake was removed from a candidate.
        /// </summary>
        unstake_from = 8,
        
        /// <summary>
        /// >> unstake_all
        /// Removes all stake of a user from all candidates.
        /// 
        /// The amount unstaked from candidates will remain locked.
        /// </summary>
        unstake_all = 9,
        
        /// <summary>
        /// >> release
        /// Releases all pending [`ReleaseRequest`] and candidacy bond for a given account.
        /// 
        /// This will unlock all funds in [`ReleaseRequest`] that have already expired.
        /// </summary>
        release = 10,
        
        /// <summary>
        /// >> set_autocompound_percentage
        /// Sets the percentage of rewards that should be auto-compounded.
        /// 
        /// This operation will also claim all pending rewards.
        /// Rewards will be autocompounded when calling the `claim_rewards` extrinsic.
        /// </summary>
        set_autocompound_percentage = 11,
        
        /// <summary>
        /// >> set_collator_reward_percentage
        /// Sets the percentage of rewards that collators will take for producing blocks.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        set_collator_reward_percentage = 12,
        
        /// <summary>
        /// >> set_extra_reward
        /// Sets the extra rewards for producing blocks. Once the session finishes, the provided amount times
        /// the total number of blocks produced during the session will be transferred from the given account
        /// to the pallet's pot account to be distributed as rewards.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        set_extra_reward = 13,
        
        /// <summary>
        /// >> set_minimum_stake
        /// Sets minimum amount that can be staked on a candidate.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        set_minimum_stake = 14,
        
        /// <summary>
        /// >> stop_extra_reward
        /// Stops the extra rewards.
        /// 
        /// The origin for this call must be the `UpdateOrigin`.
        /// </summary>
        stop_extra_reward = 15,
        
        /// <summary>
        /// >> top_up_extra_rewards
        /// Transfers funds to the extra reward pot account for distribution.
        /// 
        /// **Parameters**:
        /// - `origin`: Signed account initiating the transfer.
        /// - `amount`: Amount to transfer.
        /// 
        /// **Errors**:
        /// - `Error::<T>::InvalidFundingAmount`: Amount is zero.
        /// </summary>
        top_up_extra_rewards = 16,
        
        /// <summary>
        /// >> lock
        /// Locks free balance from the caller to be used for staking.
        /// 
        /// **Parameters**:
        /// - `origin`: Signed account initiating the lock.
        /// - `amount`: Amount to lock.
        /// 
        /// **Errors**:
        /// - `Error::<T>::InvalidFundingAmount`: Amount is zero.
        /// </summary>
        @lock = 17,
        
        /// <summary>
        /// >> unlock
        /// Adds staked funds to the [`ReleaseRequest`] queue.
        /// 
        /// Funds will actually be released after [`StakeUnlockDelay`].
        /// </summary>
        unlock = 18,
        
        /// <summary>
        /// >> update_candidacy_bond
        /// Updates the candidacy bond for this candidate.
        /// 
        /// For this operation to succeed, the caller must:
        ///   - Be a candidate.
        ///   - Have sufficient free balance to be locked.
        /// </summary>
        update_candidacy_bond = 19,
        
        /// <summary>
        /// >> claim_rewards
        /// Claims all pending rewards for stakers and candidates.
        /// 
        /// Distributes rewards accumulated over previous sessions
        /// and ensures that rewards are only claimable for sessions where the
        /// caller has participated. Rewards for the current session cannot be claimed.
        /// 
        /// **Errors**:
        /// - `Error::<T>::NoPendingClaim`: Caller has no rewards to claim.
        /// </summary>
        claim_rewards = 20,
    }
    
    /// <summary>
    /// >> 293 - Variant[pallet_collator_staking.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Mythos.NetApi.Generated.Model.account.AccountId20>>(Call.set_invulnerables);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.set_desired_candidates);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Call.set_min_candidacy_bond);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Call.register_as_candidate);
				AddTypeDecoder<BaseVoid>(Call.leave_intent);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.account.AccountId20>(Call.add_invulnerable);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.account.AccountId20>(Call.remove_invulnerable);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT11>(Call.stake);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.account.AccountId20>(Call.unstake_from);
				AddTypeDecoder<BaseVoid>(Call.unstake_all);
				AddTypeDecoder<BaseVoid>(Call.release);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.sp_arithmetic.per_things.Percent>(Call.set_autocompound_percentage);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.sp_arithmetic.per_things.Percent>(Call.set_collator_reward_percentage);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Call.set_extra_reward);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Call.set_minimum_stake);
				AddTypeDecoder<BaseVoid>(Call.stop_extra_reward);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Call.top_up_extra_rewards);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Call.@lock);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>>(Call.unlock);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Call.update_candidacy_bond);
				AddTypeDecoder<BaseVoid>(Call.claim_rewards);
        }
    }
}
