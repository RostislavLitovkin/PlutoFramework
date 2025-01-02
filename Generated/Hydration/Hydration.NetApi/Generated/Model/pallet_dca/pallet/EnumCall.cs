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
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> schedule
        /// Creates a new DCA (Dollar-Cost Averaging) schedule and plans the next execution
        /// for the specified block.
        /// 
        /// If the block is not specified, the execution is planned for the next block.
        /// If the given block is full, the execution will be planned in the subsequent block.
        /// 
        /// Once the schedule is created, the specified `total_amount` will be reserved for DCA.
        /// The reservation currency will be the `amount_in` currency of the order.
        /// 
        /// Trades are executed as long as there is budget remaining
        /// from the initial `total_amount` allocation.
        /// 
        /// If a trade fails due to slippage limit or price stability errors, it will be retried.
        /// If the number of retries reaches the maximum allowed,
        /// the schedule will be terminated permanently.
        /// In the case of a successful trade, the retry counter is reset.
        /// 
        /// Parameters:
        /// - `origin`: schedule owner
        /// - `schedule`: schedule details
        /// - `start_execution_block`: first possible execution block for the schedule
        /// 
        /// Emits `Scheduled` and `ExecutionPlanned` event when successful.
        /// 
        /// </summary>
        schedule = 0,
        
        /// <summary>
        /// >> terminate
        /// Terminates a DCA schedule and remove it completely from the chain.
        /// 
        /// This can be called by both schedule owner or the configured `T::TechnicalOrigin`
        /// 
        /// Parameters:
        /// - `origin`: schedule owner
        /// - `schedule_id`: schedule id
        /// - `next_execution_block`: block number where the schedule is planned.
        /// 
        /// Emits `Terminated` event when successful.
        /// 
        /// </summary>
        terminate = 1,
    }
    
    /// <summary>
    /// >> 407 - Variant[pallet_dca.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.pallet_dca.types.Schedule, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>>(Call.schedule);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>>(Call.terminate);
        }
    }
}
