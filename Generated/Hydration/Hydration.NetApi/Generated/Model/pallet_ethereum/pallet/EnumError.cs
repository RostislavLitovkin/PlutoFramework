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


namespace Hydration.NetApi.Generated.Model.pallet_ethereum.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> InvalidSignature
        /// Signature is invalid.
        /// </summary>
        InvalidSignature = 0,
        
        /// <summary>
        /// >> PreLogExists
        /// Pre-log is present, therefore transact is not allowed.
        /// </summary>
        PreLogExists = 1,
    }
    
    /// <summary>
    /// >> 651 - Variant[pallet_ethereum.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
