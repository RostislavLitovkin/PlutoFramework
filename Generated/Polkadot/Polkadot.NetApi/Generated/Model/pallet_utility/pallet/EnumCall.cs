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


namespace Polkadot.NetApi.Generated.Model.pallet_utility.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> batch
        /// Send a batch of dispatch calls.
        /// 
        /// May be called from any origin except `None`.
        /// 
        /// - `calls`: The calls to be dispatched from the same origin. The number of call must not
        ///   exceed the constant: `batched_calls_limit` (available in constant metadata).
        /// 
        /// If origin is root then the calls are dispatched without checking origin filter. (This
        /// includes bypassing `frame_system::Config::BaseCallFilter`).
        /// 
        /// ## Complexity
        /// - O(C) where C is the number of calls to be batched.
        /// 
        /// This will return `Ok` in all circumstances. To determine the success of the batch, an
        /// event is deposited. If a call failed and the batch was interrupted, then the
        /// `BatchInterrupted` event is deposited, along with the number of successful calls made
        /// and the error of the failed call. If all were successful, then the `BatchCompleted`
        /// event is deposited.
        /// </summary>
        batch = 0,
        
        /// <summary>
        /// >> as_derivative
        /// Send a call through an indexed pseudonym of the sender.
        /// 
        /// Filter from origin are passed along. The call will be dispatched with an origin which
        /// use the same filter as the origin of this call.
        /// 
        /// NOTE: If you need to ensure that any account-based filtering is not honored (i.e.
        /// because you expect `proxy` to have been used prior in the call stack and you do not want
        /// the call restrictions to apply to any sub-accounts), then use `as_multi_threshold_1`
        /// in the Multisig pallet instead.
        /// 
        /// NOTE: Prior to version *12, this was called `as_limited_sub`.
        /// 
        /// The dispatch origin for this call must be _Signed_.
        /// </summary>
        as_derivative = 1,
        
        /// <summary>
        /// >> batch_all
        /// Send a batch of dispatch calls and atomically execute them.
        /// The whole transaction will rollback and fail if any of the calls failed.
        /// 
        /// May be called from any origin except `None`.
        /// 
        /// - `calls`: The calls to be dispatched from the same origin. The number of call must not
        ///   exceed the constant: `batched_calls_limit` (available in constant metadata).
        /// 
        /// If origin is root then the calls are dispatched without checking origin filter. (This
        /// includes bypassing `frame_system::Config::BaseCallFilter`).
        /// 
        /// ## Complexity
        /// - O(C) where C is the number of calls to be batched.
        /// </summary>
        batch_all = 2,
        
        /// <summary>
        /// >> dispatch_as
        /// Dispatches a function call with a provided origin.
        /// 
        /// The dispatch origin for this call must be _Root_.
        /// 
        /// ## Complexity
        /// - O(1).
        /// </summary>
        dispatch_as = 3,
        
        /// <summary>
        /// >> force_batch
        /// Send a batch of dispatch calls.
        /// Unlike `batch`, it allows errors and won't interrupt.
        /// 
        /// May be called from any origin except `None`.
        /// 
        /// - `calls`: The calls to be dispatched from the same origin. The number of call must not
        ///   exceed the constant: `batched_calls_limit` (available in constant metadata).
        /// 
        /// If origin is root then the calls are dispatch without checking origin filter. (This
        /// includes bypassing `frame_system::Config::BaseCallFilter`).
        /// 
        /// ## Complexity
        /// - O(C) where C is the number of calls to be batched.
        /// </summary>
        force_batch = 4,
        
        /// <summary>
        /// >> with_weight
        /// Dispatch a function call with a specified weight.
        /// 
        /// This function does not check the weight of the call, and instead allows the
        /// Root origin to specify the weight of the call.
        /// 
        /// The dispatch origin for this call must be _Root_.
        /// </summary>
        with_weight = 5,
    }
    
    /// <summary>
    /// >> 190 - Variant[pallet_utility.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumRuntimeCall>>(Call.batch);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumRuntimeCall>>(Call.as_derivative);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumRuntimeCall>>(Call.batch_all);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumOriginCaller, Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumRuntimeCall>>(Call.dispatch_as);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumRuntimeCall>>(Call.force_batch);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.polkadot_runtime.EnumRuntimeCall, Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Call.with_weight);
        }
    }
}
