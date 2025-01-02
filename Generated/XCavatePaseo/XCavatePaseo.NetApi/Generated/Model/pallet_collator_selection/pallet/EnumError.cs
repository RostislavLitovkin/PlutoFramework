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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_collator_selection.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> TooManyCandidates
        /// The pallet has too many candidates.
        /// </summary>
        TooManyCandidates = 0,
        
        /// <summary>
        /// >> TooFewEligibleCollators
        /// Leaving would result in too few candidates.
        /// </summary>
        TooFewEligibleCollators = 1,
        
        /// <summary>
        /// >> AlreadyCandidate
        /// Account is already a candidate.
        /// </summary>
        AlreadyCandidate = 2,
        
        /// <summary>
        /// >> NotCandidate
        /// Account is not a candidate.
        /// </summary>
        NotCandidate = 3,
        
        /// <summary>
        /// >> TooManyInvulnerables
        /// There are too many Invulnerables.
        /// </summary>
        TooManyInvulnerables = 4,
        
        /// <summary>
        /// >> AlreadyInvulnerable
        /// Account is already an Invulnerable.
        /// </summary>
        AlreadyInvulnerable = 5,
        
        /// <summary>
        /// >> NotInvulnerable
        /// Account is not an Invulnerable.
        /// </summary>
        NotInvulnerable = 6,
        
        /// <summary>
        /// >> NoAssociatedValidatorId
        /// Account has no associated validator ID.
        /// </summary>
        NoAssociatedValidatorId = 7,
        
        /// <summary>
        /// >> ValidatorNotRegistered
        /// Validator ID is not yet registered.
        /// </summary>
        ValidatorNotRegistered = 8,
        
        /// <summary>
        /// >> InsertToCandidateListFailed
        /// Could not insert in the candidate list.
        /// </summary>
        InsertToCandidateListFailed = 9,
        
        /// <summary>
        /// >> RemoveFromCandidateListFailed
        /// Could not remove from the candidate list.
        /// </summary>
        RemoveFromCandidateListFailed = 10,
        
        /// <summary>
        /// >> DepositTooLow
        /// New deposit amount would be below the minimum candidacy bond.
        /// </summary>
        DepositTooLow = 11,
        
        /// <summary>
        /// >> UpdateCandidateListFailed
        /// Could not update the candidate list.
        /// </summary>
        UpdateCandidateListFailed = 12,
        
        /// <summary>
        /// >> InsufficientBond
        /// Deposit amount is too low to take the target's slot in the candidate list.
        /// </summary>
        InsufficientBond = 13,
        
        /// <summary>
        /// >> TargetIsNotCandidate
        /// The target account to be replaced in the candidate list is not a candidate.
        /// </summary>
        TargetIsNotCandidate = 14,
        
        /// <summary>
        /// >> IdenticalDeposit
        /// The updated deposit amount is equal to the amount already reserved.
        /// </summary>
        IdenticalDeposit = 15,
        
        /// <summary>
        /// >> InvalidUnreserve
        /// Cannot lower candidacy bond while occupying a future collator slot in the list.
        /// </summary>
        InvalidUnreserve = 16,
    }
    
    /// <summary>
    /// >> 452 - Variant[pallet_collator_selection.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
