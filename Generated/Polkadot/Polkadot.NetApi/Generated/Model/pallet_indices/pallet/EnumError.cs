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


namespace Polkadot.NetApi.Generated.Model.pallet_indices.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NotAssigned
        /// The index was not already assigned.
        /// </summary>
        NotAssigned = 0,
        
        /// <summary>
        /// >> NotOwner
        /// The index is assigned to another account.
        /// </summary>
        NotOwner = 1,
        
        /// <summary>
        /// >> InUse
        /// The index was not available.
        /// </summary>
        InUse = 2,
        
        /// <summary>
        /// >> NotTransfer
        /// The source and destination accounts are identical.
        /// </summary>
        NotTransfer = 3,
        
        /// <summary>
        /// >> Permanent
        /// The index is permanent and may not be freed/changed.
        /// </summary>
        Permanent = 4,
    }
    
    /// <summary>
    /// >> 545 - Variant[pallet_indices.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
