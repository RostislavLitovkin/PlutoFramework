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


namespace Hydration.NetApi.Generated.Model.pallet_session.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> set_keys
        /// Sets the session key(s) of the function caller to `keys`.
        /// Allows an account to set its session key prior to becoming a validator.
        /// This doesn't take effect until the next session.
        /// 
        /// The dispatch origin of this function must be signed.
        /// 
        /// ## Complexity
        /// - `O(1)`. Actual cost depends on the number of length of `T::Keys::key_ids()` which is
        ///   fixed.
        /// </summary>
        set_keys = 0,
        
        /// <summary>
        /// >> purge_keys
        /// Removes any session key(s) of the function caller.
        /// 
        /// This doesn't take effect until the next session.
        /// 
        /// The dispatch origin of this function must be Signed and the account must be either be
        /// convertible to a validator ID using the chain's typical addressing system (this usually
        /// means being a controller account) or directly convertible into a validator ID (which
        /// usually means being a stash account).
        /// 
        /// ## Complexity
        /// - `O(1)` in number of key types. Actual cost depends on the number of length of
        ///   `T::Keys::key_ids()` which is fixed.
        /// </summary>
        purge_keys = 1,
    }
    
    /// <summary>
    /// >> 471 - Variant[pallet_session.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.hydradx_runtime.opaque.SessionKeys, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>(Call.set_keys);
				AddTypeDecoder<BaseVoid>(Call.purge_keys);
        }
    }
}
