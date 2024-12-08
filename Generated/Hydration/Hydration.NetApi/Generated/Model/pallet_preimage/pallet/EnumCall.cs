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


namespace Hydration.NetApi.Generated.Model.pallet_preimage.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> note_preimage
        /// Register a preimage on-chain.
        /// 
        /// If the preimage was previously requested, no fees or deposits are taken for providing
        /// the preimage. Otherwise, a deposit is taken proportional to the size of the preimage.
        /// </summary>
        note_preimage = 0,
        
        /// <summary>
        /// >> unnote_preimage
        /// Clear an unrequested preimage from the runtime storage.
        /// 
        /// If `len` is provided, then it will be a much cheaper operation.
        /// 
        /// - `hash`: The hash of the preimage to be removed from the store.
        /// - `len`: The length of the preimage of `hash`.
        /// </summary>
        unnote_preimage = 1,
        
        /// <summary>
        /// >> request_preimage
        /// Request a preimage be uploaded to the chain without paying any fees or deposits.
        /// 
        /// If the preimage requests has already been provided on-chain, we unreserve any deposit
        /// a user may have paid, and take the control of the preimage out of their hands.
        /// </summary>
        request_preimage = 2,
        
        /// <summary>
        /// >> unrequest_preimage
        /// Clear a previously made request for a preimage.
        /// 
        /// NOTE: THIS MUST NOT BE CALLED ON `hash` MORE TIMES THAN `request_preimage`.
        /// </summary>
        unrequest_preimage = 3,
        
        /// <summary>
        /// >> ensure_updated
        /// Ensure that the a bulk of pre-images is upgraded.
        /// 
        /// The caller pays no fee if at least 90% of pre-images were successfully updated.
        /// </summary>
        ensure_updated = 4,
    }
    
    /// <summary>
    /// >> 288 - Variant[pallet_preimage.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(Call.note_preimage);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H256>(Call.unnote_preimage);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H256>(Call.request_preimage);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H256>(Call.unrequest_preimage);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.primitive_types.H256>>(Call.ensure_updated);
        }
    }
}
