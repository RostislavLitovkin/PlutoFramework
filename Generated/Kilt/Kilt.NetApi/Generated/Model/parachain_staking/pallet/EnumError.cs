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


namespace Kilt.NetApi.Generated.Model.parachain_staking.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> DelegatorNotFound
        /// The account is not part of the delegators set.
        /// </summary>
        DelegatorNotFound = 0,
        
        /// <summary>
        /// >> CandidateNotFound
        /// The account is not part of the collator candidates set.
        /// </summary>
        CandidateNotFound = 1,
        
        /// <summary>
        /// >> DelegatorExists
        /// The account is already part of the delegators set.
        /// </summary>
        DelegatorExists = 2,
        
        /// <summary>
        /// >> CandidateExists
        /// The account is already part of the collator candidates set.
        /// </summary>
        CandidateExists = 3,
        
        /// <summary>
        /// >> ValStakeZero
        /// The account tried to stake more or less with amount zero.
        /// </summary>
        ValStakeZero = 4,
        
        /// <summary>
        /// >> ValStakeBelowMin
        /// The account has not staked enough funds to be added to the collator
        /// candidates set.
        /// </summary>
        ValStakeBelowMin = 5,
        
        /// <summary>
        /// >> ValStakeAboveMax
        /// The account has already staked the maximum amount of funds possible.
        /// </summary>
        ValStakeAboveMax = 6,
        
        /// <summary>
        /// >> DelegationBelowMin
        /// The account has not staked enough funds to delegate a collator
        /// candidate.
        /// </summary>
        DelegationBelowMin = 7,
        
        /// <summary>
        /// >> AlreadyLeaving
        /// The collator candidate has already trigger the process to leave the
        /// set of collator candidates.
        /// </summary>
        AlreadyLeaving = 8,
        
        /// <summary>
        /// >> NotLeaving
        /// The collator candidate wanted to execute the exit but has not
        /// requested to leave before by calling `init_leave_candidates`.
        /// </summary>
        NotLeaving = 9,
        
        /// <summary>
        /// >> CannotLeaveYet
        /// The collator tried to leave before waiting at least for
        /// `ExitQueueDelay` many rounds.
        /// </summary>
        CannotLeaveYet = 10,
        
        /// <summary>
        /// >> CannotJoinBeforeUnlocking
        /// The account has a full list of unstaking requests and needs to
        /// unlock at least one of these before being able to join (again).
        /// NOTE: Can only happen if the account was a candidate or
        /// delegator before and either got kicked or exited voluntarily.
        /// </summary>
        CannotJoinBeforeUnlocking = 11,
        
        /// <summary>
        /// >> AlreadyDelegating
        /// The account is already delegating the collator candidate.
        /// </summary>
        AlreadyDelegating = 12,
        
        /// <summary>
        /// >> NotYetDelegating
        /// The account has not delegated any collator candidate yet, hence it
        /// is not in the set of delegators.
        /// </summary>
        NotYetDelegating = 13,
        
        /// <summary>
        /// >> DelegationsPerRoundExceeded
        /// The delegator has exceeded the number of delegations per round which
        /// is equal to MaxDelegatorsPerCollator.
        /// 
        /// This protects against attacks in which a delegator can re-delegate
        /// from a collator who has already authored a block, to another one
        /// which has not in this round.
        /// </summary>
        DelegationsPerRoundExceeded = 14,
        
        /// <summary>
        /// >> TooManyDelegators
        /// The collator candidate has already reached the maximum number of
        /// delegators.
        /// 
        /// This error is generated in case a new delegation request does not
        /// stake enough funds to replace some other existing delegation.
        /// </summary>
        TooManyDelegators = 15,
        
        /// <summary>
        /// >> TooFewCollatorCandidates
        /// The set of collator candidates would fall below the required minimum
        /// if the collator left.
        /// </summary>
        TooFewCollatorCandidates = 16,
        
        /// <summary>
        /// >> CannotStakeIfLeaving
        /// The collator candidate is in the process of leaving the set of
        /// candidates and cannot perform any other actions in the meantime.
        /// </summary>
        CannotStakeIfLeaving = 17,
        
        /// <summary>
        /// >> CannotDelegateIfLeaving
        /// The collator candidate is in the process of leaving the set of
        /// candidates and thus cannot be delegated to.
        /// </summary>
        CannotDelegateIfLeaving = 18,
        
        /// <summary>
        /// >> MaxCollatorsPerDelegatorExceeded
        /// The delegator has already delegated the maximum number of candidates
        /// allowed.
        /// </summary>
        MaxCollatorsPerDelegatorExceeded = 19,
        
        /// <summary>
        /// >> AlreadyDelegatedCollator
        /// The delegator has already previously delegated the collator
        /// candidate.
        /// </summary>
        AlreadyDelegatedCollator = 20,
        
        /// <summary>
        /// >> DelegationNotFound
        /// The given delegation does not exist in the set of delegations.
        /// </summary>
        DelegationNotFound = 21,
        
        /// <summary>
        /// >> Underflow
        /// The collator delegate or the delegator is trying to un-stake more
        /// funds that are currently staked.
        /// </summary>
        Underflow = 22,
        
        /// <summary>
        /// >> CannotSetAboveMax
        /// The number of selected candidates per staking round is
        /// above the maximum value allowed.
        /// </summary>
        CannotSetAboveMax = 23,
        
        /// <summary>
        /// >> CannotSetBelowMin
        /// The number of selected candidates per staking round is
        /// below the minimum value allowed.
        /// </summary>
        CannotSetBelowMin = 24,
        
        /// <summary>
        /// >> InvalidSchedule
        /// An invalid inflation configuration is trying to be set.
        /// </summary>
        InvalidSchedule = 25,
        
        /// <summary>
        /// >> NoMoreUnstaking
        /// The staking reward being unlocked does not exist.
        /// Max unlocking requests reached.
        /// </summary>
        NoMoreUnstaking = 26,
        
        /// <summary>
        /// >> TooEarly
        /// The reward rate cannot be adjusted yet as an entire year has not
        /// passed.
        /// </summary>
        TooEarly = 27,
        
        /// <summary>
        /// >> StakeNotFound
        /// Provided staked value is zero. Should never be thrown.
        /// </summary>
        StakeNotFound = 28,
        
        /// <summary>
        /// >> UnstakingIsEmpty
        /// Cannot unlock when Unstaked is empty.
        /// </summary>
        UnstakingIsEmpty = 29,
        
        /// <summary>
        /// >> RewardsNotFound
        /// Cannot claim rewards if empty.
        /// </summary>
        RewardsNotFound = 30,
        
        /// <summary>
        /// >> InvalidInput
        /// Invalid input provided. The meaning of this error is
        /// extrinsic-dependent.
        /// </summary>
        InvalidInput = 31,
    }
    
    /// <summary>
    /// >> 296 - Variant[parachain_staking.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
