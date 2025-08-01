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


namespace BifrostPolkadot.NetApi.Generated.Model.pallet_preimage.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Noted
        /// A preimage has been noted.
        /// </summary>
        Noted = 0,
        
        /// <summary>
        /// >> Requested
        /// A preimage has been requested.
        /// </summary>
        Requested = 1,
        
        /// <summary>
        /// >> Cleared
        /// A preimage has ben cleared.
        /// </summary>
        Cleared = 2,
    }
    
    /// <summary>
    /// >> 539 - Variant[pallet_preimage.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256>(Event.Noted);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256>(Event.Requested);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.primitive_types.H256>(Event.Cleared);
        }
    }
}
