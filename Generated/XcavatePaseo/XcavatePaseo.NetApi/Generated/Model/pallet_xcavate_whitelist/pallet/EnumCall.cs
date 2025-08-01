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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_xcavate_whitelist.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> add_to_whitelist
        /// Adds a user to the whitelist.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `user`: The address of the new account added to the whitelist.
        /// 
        /// Emits `NewUserWhitelisted` event when succesfful
        /// </summary>
        add_to_whitelist = 0,
        
        /// <summary>
        /// >> remove_from_whitelist
        /// Removes a user from the whitelist.
        /// 
        /// The origin must be the sudo.
        /// 
        /// Parameters:
        /// - `user`: The address of the new account removed from the whitelist.
        /// 
        /// Emits `UserRemoved` event when succesfful
        /// </summary>
        remove_from_whitelist = 1,
    }
    
    /// <summary>
    /// >> 366 - Variant[pallet_xcavate_whitelist.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.add_to_whitelist);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.remove_from_whitelist);
        }
    }
}
