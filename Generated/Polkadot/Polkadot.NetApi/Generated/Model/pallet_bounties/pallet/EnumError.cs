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


namespace Polkadot.NetApi.Generated.Model.pallet_bounties.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> InsufficientProposersBalance
        /// Proposer's balance is too low.
        /// </summary>
        InsufficientProposersBalance = 0,
        
        /// <summary>
        /// >> InvalidIndex
        /// No proposal or bounty at that index.
        /// </summary>
        InvalidIndex = 1,
        
        /// <summary>
        /// >> ReasonTooBig
        /// The reason given is just too big.
        /// </summary>
        ReasonTooBig = 2,
        
        /// <summary>
        /// >> UnexpectedStatus
        /// The bounty status is unexpected.
        /// </summary>
        UnexpectedStatus = 3,
        
        /// <summary>
        /// >> RequireCurator
        /// Require bounty curator.
        /// </summary>
        RequireCurator = 4,
        
        /// <summary>
        /// >> InvalidValue
        /// Invalid bounty value.
        /// </summary>
        InvalidValue = 5,
        
        /// <summary>
        /// >> InvalidFee
        /// Invalid bounty fee.
        /// </summary>
        InvalidFee = 6,
        
        /// <summary>
        /// >> PendingPayout
        /// A bounty payout is pending.
        /// To cancel the bounty, you must unassign and slash the curator.
        /// </summary>
        PendingPayout = 7,
        
        /// <summary>
        /// >> Premature
        /// The bounties cannot be claimed/closed because it's still in the countdown period.
        /// </summary>
        Premature = 8,
        
        /// <summary>
        /// >> HasActiveChildBounty
        /// The bounty cannot be closed because it has active child bounties.
        /// </summary>
        HasActiveChildBounty = 9,
        
        /// <summary>
        /// >> TooManyQueued
        /// Too many approvals are already queued.
        /// </summary>
        TooManyQueued = 10,
    }
    
    /// <summary>
    /// >> 681 - Variant[pallet_bounties.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
