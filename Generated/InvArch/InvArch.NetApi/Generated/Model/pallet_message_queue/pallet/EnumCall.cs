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


namespace InvArch.NetApi.Generated.Model.pallet_message_queue.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> reap_page
        /// Remove a page which has no more messages remaining to be processed or is stale.
        /// </summary>
        reap_page = 0,
        
        /// <summary>
        /// >> execute_overweight
        /// Execute an overweight message.
        /// 
        /// Temporary processing errors will be propagated whereas permanent errors are treated
        /// as success condition.
        /// 
        /// - `origin`: Must be `Signed`.
        /// - `message_origin`: The origin from which the message to be executed arrived.
        /// - `page`: The page in the queue in which the message to be executed is sitting.
        /// - `index`: The index into the queue of the message to be executed.
        /// - `weight_limit`: The maximum amount of weight allowed to be consumed in the execution
        ///   of the message.
        /// 
        /// Benchmark complexity considerations: O(index + weight_limit).
        /// </summary>
        execute_overweight = 1,
    }
    
    /// <summary>
    /// >> 259 - Variant[pallet_message_queue.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.pallet_dao_staking.primitives.EnumCustomAggregateMessageOrigin, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.reap_page);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.pallet_dao_staking.primitives.EnumCustomAggregateMessageOrigin, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, InvArch.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Call.execute_overweight);
        }
    }
}
