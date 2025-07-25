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


namespace BifrostPolkadot.NetApi.Generated.Model.orml_oracle.module
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NoPermission
        /// Sender does not have permission
        /// </summary>
        NoPermission = 0,
        
        /// <summary>
        /// >> AlreadyFeeded
        /// Feeder has already feeded at this block
        /// </summary>
        AlreadyFeeded = 1,
    }
    
    /// <summary>
    /// >> 1012 - Variant[orml_oracle.module.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
