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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_author_inherent.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> kick_off_authorship_validation
        /// This inherent is a workaround to run code after the "real" inherents have executed,
        /// but before transactions are executed.
        /// </summary>
        kick_off_authorship_validation = 0,
    }
    
    /// <summary>
    /// >> 259 - Variant[pallet_author_inherent.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnum<Call>
    {
    }
}
