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


namespace Mythos.NetApi.Generated.Model.pallet_dmarket.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> ItemNotFound
        /// The item was not found.
        /// </summary>
        ItemNotFound = 0,
        
        /// <summary>
        /// >> SellerNotItemOwner
        /// Item can only be operated by the Item owner.
        /// </summary>
        SellerNotItemOwner = 1,
        
        /// <summary>
        /// >> BidAlreadyExecuted
        /// The bid with the provided parameters has already been executed
        /// </summary>
        BidAlreadyExecuted = 2,
        
        /// <summary>
        /// >> AskAlreadyExecuted
        /// The ask with the provided parameters has already been executed
        /// </summary>
        AskAlreadyExecuted = 3,
        
        /// <summary>
        /// >> BuyerBalanceTooLow
        /// Buyer balance is not enough to pay for trade costs
        /// </summary>
        BuyerBalanceTooLow = 4,
        
        /// <summary>
        /// >> BidExpired
        /// Bid expiration timestamp must be in the future
        /// </summary>
        BidExpired = 5,
        
        /// <summary>
        /// >> AskExpired
        /// Ask expiration timestamp must be in the future
        /// </summary>
        AskExpired = 6,
        
        /// <summary>
        /// >> InvalidBuyerSignature
        /// The signature provided by the buyer is invalid
        /// </summary>
        InvalidBuyerSignature = 7,
        
        /// <summary>
        /// >> InvalidSellerSignature
        /// The signature provided by the seller is invalid
        /// </summary>
        InvalidSellerSignature = 8,
        
        /// <summary>
        /// >> BuyerIsSeller
        /// Same buyer and seller not allowed.
        /// </summary>
        BuyerIsSeller = 9,
        
        /// <summary>
        /// >> BadSignedMessage
        /// Invalid Signed message
        /// </summary>
        BadSignedMessage = 10,
        
        /// <summary>
        /// >> CollectionAlreadyInUse
        /// Dmarket collection already set to the provided value.
        /// </summary>
        CollectionAlreadyInUse = 11,
        
        /// <summary>
        /// >> CollectionNotSet
        /// Dmarket collection has not been set
        /// </summary>
        CollectionNotSet = 12,
        
        /// <summary>
        /// >> CollectionNotFound
        /// The provided Dmarket collect was not found
        /// </summary>
        CollectionNotFound = 13,
    }
    
    /// <summary>
    /// >> 455 - Variant[pallet_dmarket.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
