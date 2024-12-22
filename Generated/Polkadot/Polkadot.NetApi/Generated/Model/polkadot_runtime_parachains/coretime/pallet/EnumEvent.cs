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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.coretime.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> RevenueInfoRequested
        /// The broker chain has asked for revenue information for a specific block.
        /// </summary>
        RevenueInfoRequested = 0,
        
        /// <summary>
        /// >> CoreAssigned
        /// A core has received a new assignment from the broker chain.
        /// </summary>
        CoreAssigned = 1,
    }
    
    /// <summary>
    /// >> 488 - Variant[polkadot_runtime_parachains.coretime.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.RevenueInfoRequested);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.polkadot_primitives.v7.CoreIndex>(Event.CoreAssigned);
        }
    }
}