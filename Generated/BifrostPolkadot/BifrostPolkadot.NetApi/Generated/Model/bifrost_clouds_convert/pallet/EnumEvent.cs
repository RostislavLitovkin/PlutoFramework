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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_clouds_convert.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> CloudsConverted
        /// </summary>
        CloudsConverted = 0,
        
        /// <summary>
        /// >> VbncCharged
        /// </summary>
        VbncCharged = 1,
    }
    
    /// <summary>
    /// >> 617 - Variant[bifrost_clouds_convert.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.CloudsConverted);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.VbncCharged);
        }
    }
}
