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


namespace Mythos.NetApi.Generated.Model.pallet_sudo.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> sudo
        /// Authenticates the sudo key and dispatches a function call with `Root` origin.
        /// </summary>
        sudo = 0,
        
        /// <summary>
        /// >> sudo_unchecked_weight
        /// Authenticates the sudo key and dispatches a function call with `Root` origin.
        /// This function does not check the weight of the call, and instead allows the
        /// Sudo user to specify the weight of the call.
        /// 
        /// The dispatch origin for this call must be _Signed_.
        /// </summary>
        sudo_unchecked_weight = 1,
        
        /// <summary>
        /// >> set_key
        /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo
        /// key.
        /// </summary>
        set_key = 2,
        
        /// <summary>
        /// >> sudo_as
        /// Authenticates the sudo key and dispatches a function call with `Signed` origin from
        /// a given account.
        /// 
        /// The dispatch origin for this call must be _Signed_.
        /// </summary>
        sudo_as = 3,
        
        /// <summary>
        /// >> remove_key
        /// Permanently removes the sudo key.
        /// 
        /// **This cannot be un-done.**
        /// </summary>
        remove_key = 4,
    }
    
    /// <summary>
    /// >> 258 - Variant[pallet_sudo.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Mythos.NetApi.Generated.Model.mainnet_runtime.EnumRuntimeCall>(Call.sudo);
				AddTypeDecoder<BaseTuple<Mythos.NetApi.Generated.Model.mainnet_runtime.EnumRuntimeCall, Mythos.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Call.sudo_unchecked_weight);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.account.AccountId20>(Call.set_key);
				AddTypeDecoder<BaseTuple<Mythos.NetApi.Generated.Model.account.AccountId20, Mythos.NetApi.Generated.Model.mainnet_runtime.EnumRuntimeCall>>(Call.sudo_as);
				AddTypeDecoder<BaseVoid>(Call.remove_key);
        }
    }
}
