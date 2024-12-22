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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_on_demand.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> place_order_allow_death
        /// Create a single on demand core order.
        /// Will use the spot price for the current block and will reap the account if needed.
        /// 
        /// Parameters:
        /// - `origin`: The sender of the call, funds will be withdrawn from this account.
        /// - `max_amount`: The maximum balance to withdraw from the origin to place an order.
        /// - `para_id`: A `ParaId` the origin wants to provide blockspace for.
        /// 
        /// Errors:
        /// - `InsufficientBalance`: from the Currency implementation
        /// - `QueueFull`
        /// - `SpotPriceHigherThanMaxAmount`
        /// 
        /// Events:
        /// - `OnDemandOrderPlaced`
        /// </summary>
        place_order_allow_death = 0,
        
        /// <summary>
        /// >> place_order_keep_alive
        /// Same as the [`place_order_allow_death`](Self::place_order_allow_death) call , but with a
        /// check that placing the order will not reap the account.
        /// 
        /// Parameters:
        /// - `origin`: The sender of the call, funds will be withdrawn from this account.
        /// - `max_amount`: The maximum balance to withdraw from the origin to place an order.
        /// - `para_id`: A `ParaId` the origin wants to provide blockspace for.
        /// 
        /// Errors:
        /// - `InsufficientBalance`: from the Currency implementation
        /// - `QueueFull`
        /// - `SpotPriceHigherThanMaxAmount`
        /// 
        /// Events:
        /// - `OnDemandOrderPlaced`
        /// </summary>
        place_order_keep_alive = 1,
    }
    
    /// <summary>
    /// >> 332 - Variant[polkadot_runtime_parachains.assigner_on_demand.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>>(Call.place_order_allow_death);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>>(Call.place_order_keep_alive);
        }
    }
}
