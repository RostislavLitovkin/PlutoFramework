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


namespace PolkadotPeople.NetApi.Generated.Model.pallet_identity.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> TooManySubAccounts
        /// Too many subs-accounts.
        /// </summary>
        TooManySubAccounts = 0,
        
        /// <summary>
        /// >> NotFound
        /// Account isn't found.
        /// </summary>
        NotFound = 1,
        
        /// <summary>
        /// >> NotNamed
        /// Account isn't named.
        /// </summary>
        NotNamed = 2,
        
        /// <summary>
        /// >> EmptyIndex
        /// Empty index.
        /// </summary>
        EmptyIndex = 3,
        
        /// <summary>
        /// >> FeeChanged
        /// Fee is changed.
        /// </summary>
        FeeChanged = 4,
        
        /// <summary>
        /// >> NoIdentity
        /// No identity found.
        /// </summary>
        NoIdentity = 5,
        
        /// <summary>
        /// >> StickyJudgement
        /// Sticky judgement.
        /// </summary>
        StickyJudgement = 6,
        
        /// <summary>
        /// >> JudgementGiven
        /// Judgement given.
        /// </summary>
        JudgementGiven = 7,
        
        /// <summary>
        /// >> InvalidJudgement
        /// Invalid judgement.
        /// </summary>
        InvalidJudgement = 8,
        
        /// <summary>
        /// >> InvalidIndex
        /// The index is invalid.
        /// </summary>
        InvalidIndex = 9,
        
        /// <summary>
        /// >> InvalidTarget
        /// The target is invalid.
        /// </summary>
        InvalidTarget = 10,
        
        /// <summary>
        /// >> TooManyRegistrars
        /// Maximum amount of registrars reached. Cannot add any more.
        /// </summary>
        TooManyRegistrars = 11,
        
        /// <summary>
        /// >> AlreadyClaimed
        /// Account ID is already named.
        /// </summary>
        AlreadyClaimed = 12,
        
        /// <summary>
        /// >> NotSub
        /// Sender is not a sub-account.
        /// </summary>
        NotSub = 13,
        
        /// <summary>
        /// >> NotOwned
        /// Sub-account isn't owned by sender.
        /// </summary>
        NotOwned = 14,
        
        /// <summary>
        /// >> JudgementForDifferentIdentity
        /// The provided judgement was for a different identity.
        /// </summary>
        JudgementForDifferentIdentity = 15,
        
        /// <summary>
        /// >> JudgementPaymentFailed
        /// Error that occurs when there is an issue paying for judgement.
        /// </summary>
        JudgementPaymentFailed = 16,
        
        /// <summary>
        /// >> InvalidSuffix
        /// The provided suffix is too long.
        /// </summary>
        InvalidSuffix = 17,
        
        /// <summary>
        /// >> NotUsernameAuthority
        /// The sender does not have permission to issue a username.
        /// </summary>
        NotUsernameAuthority = 18,
        
        /// <summary>
        /// >> NoAllocation
        /// The authority cannot allocate any more usernames.
        /// </summary>
        NoAllocation = 19,
        
        /// <summary>
        /// >> InvalidSignature
        /// The signature on a username was not valid.
        /// </summary>
        InvalidSignature = 20,
        
        /// <summary>
        /// >> RequiresSignature
        /// Setting this username requires a signature, but none was provided.
        /// </summary>
        RequiresSignature = 21,
        
        /// <summary>
        /// >> InvalidUsername
        /// The username does not meet the requirements.
        /// </summary>
        InvalidUsername = 22,
        
        /// <summary>
        /// >> UsernameTaken
        /// The username is already taken.
        /// </summary>
        UsernameTaken = 23,
        
        /// <summary>
        /// >> NoUsername
        /// The requested username does not exist.
        /// </summary>
        NoUsername = 24,
        
        /// <summary>
        /// >> NotExpired
        /// The username cannot be forcefully removed because it can still be accepted.
        /// </summary>
        NotExpired = 25,
        
        /// <summary>
        /// >> TooEarly
        /// The username cannot be removed because it's still in the grace period.
        /// </summary>
        TooEarly = 26,
        
        /// <summary>
        /// >> NotUnbinding
        /// The username cannot be removed because it is not unbinding.
        /// </summary>
        NotUnbinding = 27,
        
        /// <summary>
        /// >> AlreadyUnbinding
        /// The username cannot be unbound because it is already unbinding.
        /// </summary>
        AlreadyUnbinding = 28,
        
        /// <summary>
        /// >> InsufficientPrivileges
        /// The action cannot be performed because of insufficient privileges (e.g. authority
        /// trying to unbind a username provided by the system).
        /// </summary>
        InsufficientPrivileges = 29,
    }
    
    /// <summary>
    /// >> 427 - Variant[pallet_identity.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
