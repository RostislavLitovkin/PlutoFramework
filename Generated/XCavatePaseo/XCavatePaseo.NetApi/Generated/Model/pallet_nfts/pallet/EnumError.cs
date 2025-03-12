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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_nfts.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NoPermission
        /// The signing account has no permission to do the operation.
        /// </summary>
        NoPermission = 0,
        
        /// <summary>
        /// >> UnknownCollection
        /// The given item ID is unknown.
        /// </summary>
        UnknownCollection = 1,
        
        /// <summary>
        /// >> AlreadyExists
        /// The item ID has already been used for an item.
        /// </summary>
        AlreadyExists = 2,
        
        /// <summary>
        /// >> ApprovalExpired
        /// The approval had a deadline that expired, so the approval isn't valid anymore.
        /// </summary>
        ApprovalExpired = 3,
        
        /// <summary>
        /// >> WrongOwner
        /// The owner turned out to be different to what was expected.
        /// </summary>
        WrongOwner = 4,
        
        /// <summary>
        /// >> BadWitness
        /// The witness data given does not match the current state of the chain.
        /// </summary>
        BadWitness = 5,
        
        /// <summary>
        /// >> CollectionIdInUse
        /// Collection ID is already taken.
        /// </summary>
        CollectionIdInUse = 6,
        
        /// <summary>
        /// >> ItemsNonTransferable
        /// Items within that collection are non-transferable.
        /// </summary>
        ItemsNonTransferable = 7,
        
        /// <summary>
        /// >> NotDelegate
        /// The provided account is not a delegate.
        /// </summary>
        NotDelegate = 8,
        
        /// <summary>
        /// >> WrongDelegate
        /// The delegate turned out to be different to what was expected.
        /// </summary>
        WrongDelegate = 9,
        
        /// <summary>
        /// >> Unapproved
        /// No approval exists that would allow the transfer.
        /// </summary>
        Unapproved = 10,
        
        /// <summary>
        /// >> Unaccepted
        /// The named owner has not signed ownership acceptance of the collection.
        /// </summary>
        Unaccepted = 11,
        
        /// <summary>
        /// >> ItemLocked
        /// The item is locked (non-transferable).
        /// </summary>
        ItemLocked = 12,
        
        /// <summary>
        /// >> LockedItemAttributes
        /// Item's attributes are locked.
        /// </summary>
        LockedItemAttributes = 13,
        
        /// <summary>
        /// >> LockedCollectionAttributes
        /// Collection's attributes are locked.
        /// </summary>
        LockedCollectionAttributes = 14,
        
        /// <summary>
        /// >> LockedItemMetadata
        /// Item's metadata is locked.
        /// </summary>
        LockedItemMetadata = 15,
        
        /// <summary>
        /// >> LockedCollectionMetadata
        /// Collection's metadata is locked.
        /// </summary>
        LockedCollectionMetadata = 16,
        
        /// <summary>
        /// >> MaxSupplyReached
        /// All items have been minted.
        /// </summary>
        MaxSupplyReached = 17,
        
        /// <summary>
        /// >> MaxSupplyLocked
        /// The max supply is locked and can't be changed.
        /// </summary>
        MaxSupplyLocked = 18,
        
        /// <summary>
        /// >> MaxSupplyTooSmall
        /// The provided max supply is less than the number of items a collection already has.
        /// </summary>
        MaxSupplyTooSmall = 19,
        
        /// <summary>
        /// >> UnknownItem
        /// The given item ID is unknown.
        /// </summary>
        UnknownItem = 20,
        
        /// <summary>
        /// >> UnknownSwap
        /// Swap doesn't exist.
        /// </summary>
        UnknownSwap = 21,
        
        /// <summary>
        /// >> MetadataNotFound
        /// The given item has no metadata set.
        /// </summary>
        MetadataNotFound = 22,
        
        /// <summary>
        /// >> AttributeNotFound
        /// The provided attribute can't be found.
        /// </summary>
        AttributeNotFound = 23,
        
        /// <summary>
        /// >> NotForSale
        /// Item is not for sale.
        /// </summary>
        NotForSale = 24,
        
        /// <summary>
        /// >> BidTooLow
        /// The provided bid is too low.
        /// </summary>
        BidTooLow = 25,
        
        /// <summary>
        /// >> ReachedApprovalLimit
        /// The item has reached its approval limit.
        /// </summary>
        ReachedApprovalLimit = 26,
        
        /// <summary>
        /// >> DeadlineExpired
        /// The deadline has already expired.
        /// </summary>
        DeadlineExpired = 27,
        
        /// <summary>
        /// >> WrongDuration
        /// The duration provided should be less than or equal to `MaxDeadlineDuration`.
        /// </summary>
        WrongDuration = 28,
        
        /// <summary>
        /// >> MethodDisabled
        /// The method is disabled by system settings.
        /// </summary>
        MethodDisabled = 29,
        
        /// <summary>
        /// >> WrongSetting
        /// The provided setting can't be set.
        /// </summary>
        WrongSetting = 30,
        
        /// <summary>
        /// >> InconsistentItemConfig
        /// Item's config already exists and should be equal to the provided one.
        /// </summary>
        InconsistentItemConfig = 31,
        
        /// <summary>
        /// >> NoConfig
        /// Config for a collection or an item can't be found.
        /// </summary>
        NoConfig = 32,
        
        /// <summary>
        /// >> RolesNotCleared
        /// Some roles were not cleared.
        /// </summary>
        RolesNotCleared = 33,
        
        /// <summary>
        /// >> MintNotStarted
        /// Mint has not started yet.
        /// </summary>
        MintNotStarted = 34,
        
        /// <summary>
        /// >> MintEnded
        /// Mint has already ended.
        /// </summary>
        MintEnded = 35,
        
        /// <summary>
        /// >> AlreadyClaimed
        /// The provided Item was already used for claiming.
        /// </summary>
        AlreadyClaimed = 36,
        
        /// <summary>
        /// >> IncorrectData
        /// The provided data is incorrect.
        /// </summary>
        IncorrectData = 37,
        
        /// <summary>
        /// >> WrongOrigin
        /// The extrinsic was sent by the wrong origin.
        /// </summary>
        WrongOrigin = 38,
        
        /// <summary>
        /// >> WrongSignature
        /// The provided signature is incorrect.
        /// </summary>
        WrongSignature = 39,
        
        /// <summary>
        /// >> IncorrectMetadata
        /// The provided metadata might be too long.
        /// </summary>
        IncorrectMetadata = 40,
        
        /// <summary>
        /// >> MaxAttributesLimitReached
        /// Can't set more attributes per one call.
        /// </summary>
        MaxAttributesLimitReached = 41,
        
        /// <summary>
        /// >> WrongNamespace
        /// The provided namespace isn't supported in this call.
        /// </summary>
        WrongNamespace = 42,
        
        /// <summary>
        /// >> CollectionNotEmpty
        /// Can't delete non-empty collections.
        /// </summary>
        CollectionNotEmpty = 43,
        
        /// <summary>
        /// >> WitnessRequired
        /// The witness data should be provided.
        /// </summary>
        WitnessRequired = 44,
    }
    
    /// <summary>
    /// >> 482 - Variant[pallet_nfts.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
