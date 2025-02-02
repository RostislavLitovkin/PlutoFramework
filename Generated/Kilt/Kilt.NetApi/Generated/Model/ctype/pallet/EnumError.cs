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


namespace Kilt.NetApi.Generated.Model.ctype.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NotFound
        /// There is no CType with the given hash.
        /// </summary>
        NotFound = 0,
        
        /// <summary>
        /// >> AlreadyExists
        /// The CType already exists.
        /// </summary>
        AlreadyExists = 1,
        
        /// <summary>
        /// >> UnableToPayFees
        /// The paying account was unable to pay the fees for creating a ctype.
        /// </summary>
        UnableToPayFees = 2,
    }
    
    /// <summary>
    /// >> 522 - Variant[ctype.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
