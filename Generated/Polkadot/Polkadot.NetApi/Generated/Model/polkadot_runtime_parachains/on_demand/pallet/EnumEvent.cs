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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.on_demand.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> OnDemandOrderPlaced
        /// An order was placed at some spot price amount by orderer ordered_by
        /// </summary>
        OnDemandOrderPlaced = 0,
        
        /// <summary>
        /// >> SpotPriceSet
        /// The value of the spot price has likely changed
        /// </summary>
        SpotPriceSet = 1,
        
        /// <summary>
        /// >> AccountCredited
        /// An account was given credits.
        /// </summary>
        AccountCredited = 2,
    }
    
    /// <summary>
    /// >> 493 - Variant[polkadot_runtime_parachains.on_demand.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128, Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.OnDemandOrderPlaced);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.SpotPriceSet);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.AccountCredited);
        }
    }
}
