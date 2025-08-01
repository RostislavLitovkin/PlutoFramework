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


namespace Hydration.NetApi.Generated.Model.pallet_dca.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> ExecutionStarted
        /// The DCA execution is started
        /// </summary>
        ExecutionStarted = 0,
        
        /// <summary>
        /// >> Scheduled
        /// The DCA is scheduled for next execution
        /// </summary>
        Scheduled = 1,
        
        /// <summary>
        /// >> ExecutionPlanned
        /// The DCA is planned for blocknumber
        /// </summary>
        ExecutionPlanned = 2,
        
        /// <summary>
        /// >> TradeExecuted
        /// The DCA trade is successfully executed
        /// </summary>
        TradeExecuted = 3,
        
        /// <summary>
        /// >> TradeFailed
        /// The DCA trade execution is failed
        /// </summary>
        TradeFailed = 4,
        
        /// <summary>
        /// >> Terminated
        /// The DCA is terminated and completely removed from the chain
        /// </summary>
        Terminated = 5,
        
        /// <summary>
        /// >> Completed
        /// The DCA is completed and completely removed from the chain
        /// </summary>
        Completed = 6,
        
        /// <summary>
        /// >> RandomnessGenerationFailed
        /// Randomness generation failed possibly coming from missing data about relay chain
        /// </summary>
        RandomnessGenerationFailed = 7,
    }
    
    /// <summary>
    /// >> 467 - Variant[pallet_dca.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.ExecutionStarted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Hydration.NetApi.Generated.Model.pallet_dca.types.EnumOrder>>(Event.Scheduled);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.ExecutionPlanned);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.TradeExecuted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Hydration.NetApi.Generated.Model.sp_runtime.EnumDispatchError>>(Event.TradeFailed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Hydration.NetApi.Generated.Model.sp_runtime.EnumDispatchError>>(Event.Terminated);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.Completed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_runtime.EnumDispatchError>>(Event.RandomnessGenerationFailed);
        }
    }
}
