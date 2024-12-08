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


namespace PolkadotAssetHub.NetApi.Generated.Model.pallet_uniques.pallet
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
        /// >> WrongOwner
        /// The owner turned out to be different to what was expected.
        /// </summary>
        WrongOwner = 3,
        
        /// <summary>
        /// >> BadWitness
        /// Invalid witness data given.
        /// </summary>
        BadWitness = 4,
        
        /// <summary>
        /// >> InUse
        /// The item ID is already taken.
        /// </summary>
        InUse = 5,
        
        /// <summary>
        /// >> Frozen
        /// The item or collection is frozen.
        /// </summary>
        Frozen = 6,
        
        /// <summary>
        /// >> WrongDelegate
        /// The delegate turned out to be different to what was expected.
        /// </summary>
        WrongDelegate = 7,
        
        /// <summary>
        /// >> NoDelegate
        /// There is no delegate approved.
        /// </summary>
        NoDelegate = 8,
        
        /// <summary>
        /// >> Unapproved
        /// No approval exists that would allow the transfer.
        /// </summary>
        Unapproved = 9,
        
        /// <summary>
        /// >> Unaccepted
        /// The named owner has not signed ownership of the collection is acceptable.
        /// </summary>
        Unaccepted = 10,
        
        /// <summary>
        /// >> Locked
        /// The item is locked.
        /// </summary>
        Locked = 11,
        
        /// <summary>
        /// >> MaxSupplyReached
        /// All items have been minted.
        /// </summary>
        MaxSupplyReached = 12,
        
        /// <summary>
        /// >> MaxSupplyAlreadySet
        /// The max supply has already been set.
        /// </summary>
        MaxSupplyAlreadySet = 13,
        
        /// <summary>
        /// >> MaxSupplyTooSmall
        /// The provided max supply is less to the amount of items a collection already has.
        /// </summary>
        MaxSupplyTooSmall = 14,
        
        /// <summary>
        /// >> UnknownItem
        /// The given item ID is unknown.
        /// </summary>
        UnknownItem = 15,
        
        /// <summary>
        /// >> NotForSale
        /// Item is not for sale.
        /// </summary>
        NotForSale = 16,
        
        /// <summary>
        /// >> BidTooLow
        /// The provided bid is too low.
        /// </summary>
        BidTooLow = 17,
    }
    
    /// <summary>
    /// >> 422 - Variant[pallet_uniques.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
