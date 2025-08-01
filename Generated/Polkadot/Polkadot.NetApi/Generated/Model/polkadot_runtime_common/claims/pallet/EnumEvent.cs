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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_common.claims.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Claimed
        /// Someone claimed some DOTs.
        /// </summary>
        Claimed = 0,
    }
    
    /// <summary>
    /// >> 467 - Variant[polkadot_runtime_common.claims.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Polkadot.NetApi.Generated.Model.polkadot_runtime_common.claims.EthereumAddress, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Claimed);
        }
    }
}
