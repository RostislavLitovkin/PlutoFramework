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


namespace Polkadot.NetApi.Generated.Model.pallet_scheduler.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// Events type.
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Scheduled
        /// Scheduled some task.
        /// </summary>
        Scheduled = 0,
        
        /// <summary>
        /// >> Canceled
        /// Canceled some task.
        /// </summary>
        Canceled = 1,
        
        /// <summary>
        /// >> Dispatched
        /// Dispatched some task.
        /// </summary>
        Dispatched = 2,
        
        /// <summary>
        /// >> RetrySet
        /// Set a retry configuration for some task.
        /// </summary>
        RetrySet = 3,
        
        /// <summary>
        /// >> RetryCancelled
        /// Cancel a retry configuration for some task.
        /// </summary>
        RetryCancelled = 4,
        
        /// <summary>
        /// >> CallUnavailable
        /// The call for the provided hash was not found so the task has been aborted.
        /// </summary>
        CallUnavailable = 5,
        
        /// <summary>
        /// >> PeriodicFailed
        /// The given task was unable to be renewed since the agenda is full at that block.
        /// </summary>
        PeriodicFailed = 6,
        
        /// <summary>
        /// >> RetryFailed
        /// The given task was unable to be retried since the agenda is full at that block or there
        /// was not enough weight to reschedule it.
        /// </summary>
        RetryFailed = 7,
        
        /// <summary>
        /// >> PermanentlyOverweight
        /// The given task can never be executed since it is overweight.
        /// </summary>
        PermanentlyOverweight = 8,
        
        /// <summary>
        /// >> AgendaIncomplete
        /// Agenda is incomplete from `when`.
        /// </summary>
        AgendaIncomplete = 9,
    }
    
    /// <summary>
    /// >> 32 - Variant[pallet_scheduler.pallet.Event]
    /// Events type.
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.Scheduled);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.Canceled);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Types.Base.Arr32U8>, Polkadot.NetApi.Generated.Types.Base.EnumResult>>(Event.Dispatched);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Types.Base.Arr32U8>, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U8>>(Event.RetrySet);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Types.Base.Arr32U8>>>(Event.RetryCancelled);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Types.Base.Arr32U8>>>(Event.CallUnavailable);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Types.Base.Arr32U8>>>(Event.PeriodicFailed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Types.Base.Arr32U8>>>(Event.RetryFailed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Types.Base.Arr32U8>>>(Event.PermanentlyOverweight);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.AgendaIncomplete);
        }
    }
}
