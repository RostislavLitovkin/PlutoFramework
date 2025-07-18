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


namespace BifrostPolkadot.NetApi.Generated.Model.orml_oracle.module
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> NewFeedData
        /// New feed data is submitted.
        /// </summary>
        NewFeedData = 0,
        
        /// <summary>
        /// >> FeedValueReachingLimit
        /// </summary>
        FeedValueReachingLimit = 1,
    }
    
    /// <summary>
    /// >> 612 - Variant[orml_oracle.module.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>>>>(Event.NewFeedData);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.orml_oracle.module.TimestampedValue, BifrostPolkadot.NetApi.Generated.Model.orml_oracle.module.TimestampedValue>>(Event.FeedValueReachingLimit);
        }
    }
}
