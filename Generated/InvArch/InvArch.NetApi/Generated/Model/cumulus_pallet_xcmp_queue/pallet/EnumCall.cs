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


namespace InvArch.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> suspend_xcm_execution
        /// Suspends all XCM executions for the XCMP queue, regardless of the sender's origin.
        /// 
        /// - `origin`: Must pass `ControllerOrigin`.
        /// </summary>
        suspend_xcm_execution = 1,
        
        /// <summary>
        /// >> resume_xcm_execution
        /// Resumes all XCM executions for the XCMP queue.
        /// 
        /// Note that this function doesn't change the status of the in/out bound channels.
        /// 
        /// - `origin`: Must pass `ControllerOrigin`.
        /// </summary>
        resume_xcm_execution = 2,
        
        /// <summary>
        /// >> update_suspend_threshold
        /// Overwrites the number of pages which must be in the queue for the other side to be
        /// told to suspend their sending.
        /// 
        /// - `origin`: Must pass `Root`.
        /// - `new`: Desired value for `QueueConfigData.suspend_value`
        /// </summary>
        update_suspend_threshold = 3,
        
        /// <summary>
        /// >> update_drop_threshold
        /// Overwrites the number of pages which must be in the queue after which we drop any
        /// further messages from the channel.
        /// 
        /// - `origin`: Must pass `Root`.
        /// - `new`: Desired value for `QueueConfigData.drop_threshold`
        /// </summary>
        update_drop_threshold = 4,
        
        /// <summary>
        /// >> update_resume_threshold
        /// Overwrites the number of pages which the queue must be reduced to before it signals
        /// that message sending may recommence after it has been suspended.
        /// 
        /// - `origin`: Must pass `Root`.
        /// - `new`: Desired value for `QueueConfigData.resume_threshold`
        /// </summary>
        update_resume_threshold = 5,
    }
    
    /// <summary>
    /// >> 216 - Variant[cumulus_pallet_xcmp_queue.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseVoid>(Call.suspend_xcm_execution);
				AddTypeDecoder<BaseVoid>(Call.resume_xcm_execution);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.update_suspend_threshold);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.update_drop_threshold);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.update_resume_threshold);
        }
    }
}
