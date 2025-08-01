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


namespace Mythos.NetApi.Generated.Model.pallet_xcm.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> Unreachable
        /// The desired destination was unreachable, generally because there is a no way of routing
        /// to it.
        /// </summary>
        Unreachable = 0,
        
        /// <summary>
        /// >> SendFailure
        /// There was some other issue (i.e. not to do with routing) in sending the message.
        /// Perhaps a lack of space for buffering the message.
        /// </summary>
        SendFailure = 1,
        
        /// <summary>
        /// >> Filtered
        /// The message execution fails the filter.
        /// </summary>
        Filtered = 2,
        
        /// <summary>
        /// >> UnweighableMessage
        /// The message's weight could not be determined.
        /// </summary>
        UnweighableMessage = 3,
        
        /// <summary>
        /// >> DestinationNotInvertible
        /// The destination `Location` provided cannot be inverted.
        /// </summary>
        DestinationNotInvertible = 4,
        
        /// <summary>
        /// >> Empty
        /// The assets to be sent are empty.
        /// </summary>
        Empty = 5,
        
        /// <summary>
        /// >> CannotReanchor
        /// Could not re-anchor the assets to declare the fees for the destination chain.
        /// </summary>
        CannotReanchor = 6,
        
        /// <summary>
        /// >> TooManyAssets
        /// Too many assets have been attempted for transfer.
        /// </summary>
        TooManyAssets = 7,
        
        /// <summary>
        /// >> InvalidOrigin
        /// Origin is invalid for sending.
        /// </summary>
        InvalidOrigin = 8,
        
        /// <summary>
        /// >> BadVersion
        /// The version of the `Versioned` value used is not able to be interpreted.
        /// </summary>
        BadVersion = 9,
        
        /// <summary>
        /// >> BadLocation
        /// The given location could not be used (e.g. because it cannot be expressed in the
        /// desired version of XCM).
        /// </summary>
        BadLocation = 10,
        
        /// <summary>
        /// >> NoSubscription
        /// The referenced subscription could not be found.
        /// </summary>
        NoSubscription = 11,
        
        /// <summary>
        /// >> AlreadySubscribed
        /// The location is invalid since it already has a subscription from us.
        /// </summary>
        AlreadySubscribed = 12,
        
        /// <summary>
        /// >> CannotCheckOutTeleport
        /// Could not check-out the assets for teleportation to the destination chain.
        /// </summary>
        CannotCheckOutTeleport = 13,
        
        /// <summary>
        /// >> LowBalance
        /// The owner does not own (all) of the asset that they wish to do the operation on.
        /// </summary>
        LowBalance = 14,
        
        /// <summary>
        /// >> TooManyLocks
        /// The asset owner has too many locks on the asset.
        /// </summary>
        TooManyLocks = 15,
        
        /// <summary>
        /// >> AccountNotSovereign
        /// The given account is not an identifiable sovereign account for any location.
        /// </summary>
        AccountNotSovereign = 16,
        
        /// <summary>
        /// >> FeesNotMet
        /// The operation required fees to be paid which the initiator could not meet.
        /// </summary>
        FeesNotMet = 17,
        
        /// <summary>
        /// >> LockNotFound
        /// A remote lock with the corresponding data could not be found.
        /// </summary>
        LockNotFound = 18,
        
        /// <summary>
        /// >> InUse
        /// The unlock operation cannot succeed because there are still consumers of the lock.
        /// </summary>
        InUse = 19,
        
        /// <summary>
        /// >> InvalidAssetUnknownReserve
        /// Invalid asset, reserve chain could not be determined for it.
        /// </summary>
        InvalidAssetUnknownReserve = 21,
        
        /// <summary>
        /// >> InvalidAssetUnsupportedReserve
        /// Invalid asset, do not support remote asset reserves with different fees reserves.
        /// </summary>
        InvalidAssetUnsupportedReserve = 22,
        
        /// <summary>
        /// >> TooManyReserves
        /// Too many assets with different reserve locations have been attempted for transfer.
        /// </summary>
        TooManyReserves = 23,
        
        /// <summary>
        /// >> LocalExecutionIncomplete
        /// Local XCM execution incomplete.
        /// </summary>
        LocalExecutionIncomplete = 24,
    }
    
    /// <summary>
    /// >> 526 - Variant[pallet_xcm.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
