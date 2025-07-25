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


namespace Mythos.NetApi.Generated.Model.pallet_marketplace.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> force_set_authority
        /// Sets the authority role, granting owner rights.
        /// 
        /// Only the root origin can execute this function.
        /// 
        /// Parameters:
        /// - `authority`: The account ID of the administrator to be set as the pallet's authority.
        /// 
        /// Emits AuthorityUpdated when successful.
        /// 
        /// Weight: `WeightInfo::force_set_authority` (defined in the `Config` trait).
        /// </summary>
        force_set_authority = 0,
        
        /// <summary>
        /// >> set_fee_signer_address
        /// Sets the fee signer address, allowing the designated account that signs fees.
        /// 
        /// Only an account with the authority role can execute this function.
        /// 
        /// Parameters:
        /// - `fee_signer`: The account ID of the fee signer to be set.
        /// 
        /// Emits `FeeSignerAddressUpdate` event upon successful execution.
        /// 
        /// Weight: `WeightInfo::set_fee_signer_address` (defined in the `Config` trait).
        /// </summary>
        set_fee_signer_address = 1,
        
        /// <summary>
        /// >> set_payout_address
        /// Allows the authority account to set the payout address, which receives fee payments from trades.
        /// 
        /// Only an account with the authority role can execute this function.
        /// 
        /// Parameters:
        /// - `payout_address`: The account ID of the address to be set as the payout address.
        /// 
        /// Emits `PayoutAddressUpdated` event upon successful execution.
        /// 
        /// Weight: `WeightInfo::set_payout_address` (defined in the `Config` trait).
        /// </summary>
        set_payout_address = 2,
        
        /// <summary>
        /// >> create_order
        /// Create an Ask or Bid Order for a specific NFT (collection ID, Item ID).
        /// 
        /// Asks:
        /// - An owner of an NFT can create an ask on the item with a price, expiration, and signature.
        /// - The signature must come from the feeSigner account.
        /// - The expiration must be above `MinOrderDuration`.
        /// - After the ask is created, the NFT is locked so it can't be transferred.
        /// 
        /// Bids:
        /// - A bid can be created on an existing item, with a price to pay, a fee, and expiration.
        /// - The signature must come from the feeSigner account.
        /// - The amount the bidder is willing to pay is locked from the user's Balance.
        /// 
        /// Match Exists:
        /// - If a match between an Ask and Bid exists, the trade is triggered.
        /// - The seller receives the funds, and the bidder receives the unlocked item.
        /// - Fees go to payoutAddress.
        /// 
        /// Parameters:
        /// - `order`: The details of the order to be created (including type, collection, item, price, expiration, fee, and signature).
        /// - `execution`: Execution mode to indicate whether order creation should proceed if a valid match exists.
        /// 
        /// Emits `OrderCreated` event upon successful execution.
        /// 
        /// Weight: `WeightInfo::create_order` (defined in the `Config` trait).
        /// </summary>
        create_order = 3,
        
        /// <summary>
        /// >> cancel_order
        /// Cancellation of an Ask or Bid order.
        /// 
        /// Callable by either the authority or the order creator.
        /// 
        /// If the order is an Ask, the item is unlocked.
        /// If the order is a Bid, the bidder's balance is unlocked.
        /// 
        /// Parameters:
        /// - `order_type`: The type of the order to be canceled (Ask or Bid).
        /// - `collection`: The collection ID of the NFT associated with the order.
        /// - `item`: The item ID of the NFT associated with the order.
        /// - `price`: The price associated with the order (used for Bid orders).
        /// 
        /// Emits `OrderCanceled` event upon successful execution.
        /// 
        /// Weight: `WeightInfo::cancel_order` (defined in the `Config` trait).
        /// </summary>
        cancel_order = 4,
    }
    
    /// <summary>
    /// >> 273 - Variant[pallet_marketplace.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Mythos.NetApi.Generated.Model.account.AccountId20>(Call.force_set_authority);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.account.AccountId20>(Call.set_fee_signer_address);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.account.AccountId20>(Call.set_payout_address);
				AddTypeDecoder<BaseTuple<Mythos.NetApi.Generated.Model.pallet_marketplace.types.Order, Mythos.NetApi.Generated.Model.pallet_marketplace.types.EnumExecution>>(Call.create_order);
				AddTypeDecoder<BaseTuple<Mythos.NetApi.Generated.Model.pallet_marketplace.types.EnumOrderType, Mythos.NetApi.Generated.Model.runtime_common.IncrementableU256, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.cancel_order);
        }
    }
}
