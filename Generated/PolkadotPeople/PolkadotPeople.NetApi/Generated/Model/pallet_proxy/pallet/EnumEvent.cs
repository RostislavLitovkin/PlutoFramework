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


namespace PolkadotPeople.NetApi.Generated.Model.pallet_proxy.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> ProxyExecuted
        /// A proxy was executed correctly, with the given.
        /// </summary>
        ProxyExecuted = 0,
        
        /// <summary>
        /// >> PureCreated
        /// A pure account has been created by new proxy with given
        /// disambiguation index and proxy type.
        /// </summary>
        PureCreated = 1,
        
        /// <summary>
        /// >> Announced
        /// An announcement was placed to make a call in the future.
        /// </summary>
        Announced = 2,
        
        /// <summary>
        /// >> ProxyAdded
        /// A proxy was added.
        /// </summary>
        ProxyAdded = 3,
        
        /// <summary>
        /// >> ProxyRemoved
        /// A proxy was removed.
        /// </summary>
        ProxyRemoved = 4,
    }
    
    /// <summary>
    /// >> 143 - Variant[pallet_proxy.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Types.Base.EnumResult>(Event.ProxyExecuted);
				AddTypeDecoder<BaseTuple<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U16>>(Event.PureCreated);
				AddTypeDecoder<BaseTuple<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.primitive_types.H256>>(Event.Announced);
				AddTypeDecoder<BaseTuple<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.ProxyAdded);
				AddTypeDecoder<BaseTuple<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32, PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime.EnumProxyType, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.ProxyRemoved);
        }
    }
}
