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


namespace Hydration.NetApi.Generated.Model.pallet_circuit_breaker.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> TradeVolumeLimitChanged
        /// Trade volume limit of an asset was changed.
        /// </summary>
        TradeVolumeLimitChanged = 0,
        
        /// <summary>
        /// >> AddLiquidityLimitChanged
        /// Add liquidity limit of an asset was changed.
        /// </summary>
        AddLiquidityLimitChanged = 1,
        
        /// <summary>
        /// >> RemoveLiquidityLimitChanged
        /// Remove liquidity limit of an asset was changed.
        /// </summary>
        RemoveLiquidityLimitChanged = 2,
    }
    
    /// <summary>
    /// >> 430 - Variant[pallet_circuit_breaker.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>(Event.TradeVolumeLimitChanged);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>>(Event.AddLiquidityLimitChanged);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>>(Event.RemoveLiquidityLimitChanged);
        }
    }
}
