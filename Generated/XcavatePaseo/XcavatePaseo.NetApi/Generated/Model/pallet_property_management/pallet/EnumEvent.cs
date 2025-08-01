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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_property_management.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> LettingAgentAdded
        /// A new letting agent got set.
        /// </summary>
        LettingAgentAdded = 0,
        
        /// <summary>
        /// >> Deposited
        /// A letting agent deposited the necessary funds.
        /// </summary>
        Deposited = 1,
        
        /// <summary>
        /// >> LettingAgentAddedToLocation
        /// A letting agent has been added to a location.
        /// </summary>
        LettingAgentAddedToLocation = 2,
        
        /// <summary>
        /// >> LettingAgentSet
        /// A letting agent has been added to a property.
        /// </summary>
        LettingAgentSet = 3,
        
        /// <summary>
        /// >> IncomeDistributed
        /// The rental income has been distributed.
        /// </summary>
        IncomeDistributed = 4,
        
        /// <summary>
        /// >> WithdrawFunds
        /// A user withdrew funds.
        /// </summary>
        WithdrawFunds = 5,
    }
    
    /// <summary>
    /// >> 183 - Variant[pallet_property_management.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.LettingAgentAdded);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.Deposited);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9>>(Event.LettingAgentAddedToLocation);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.LettingAgentSet);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.IncomeDistributed);
				AddTypeDecoder<BaseTuple<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.WithdrawFunds);
        }
    }
}
