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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_common.auctions.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> AuctionInProgress
        /// This auction is already in progress.
        /// </summary>
        AuctionInProgress = 0,
        
        /// <summary>
        /// >> LeasePeriodInPast
        /// The lease period is in the past.
        /// </summary>
        LeasePeriodInPast = 1,
        
        /// <summary>
        /// >> ParaNotRegistered
        /// Para is not registered
        /// </summary>
        ParaNotRegistered = 2,
        
        /// <summary>
        /// >> NotCurrentAuction
        /// Not a current auction.
        /// </summary>
        NotCurrentAuction = 3,
        
        /// <summary>
        /// >> NotAuction
        /// Not an auction.
        /// </summary>
        NotAuction = 4,
        
        /// <summary>
        /// >> AuctionEnded
        /// Auction has already ended.
        /// </summary>
        AuctionEnded = 5,
        
        /// <summary>
        /// >> AlreadyLeasedOut
        /// The para is already leased out for part of this range.
        /// </summary>
        AlreadyLeasedOut = 6,
    }
    
    /// <summary>
    /// >> 829 - Variant[polkadot_runtime_common.auctions.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
