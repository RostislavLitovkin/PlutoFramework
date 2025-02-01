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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_tx_pause.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> IsPaused
        /// The call is paused.
        /// </summary>
        IsPaused = 0,
        
        /// <summary>
        /// >> IsUnpaused
        /// The call is unpaused.
        /// </summary>
        IsUnpaused = 1,
        
        /// <summary>
        /// >> Unpausable
        /// The call is whitelisted and cannot be paused.
        /// </summary>
        Unpausable = 2,
        
        /// <summary>
        /// >> NotFound
        /// </summary>
        NotFound = 3,
    }
    
    /// <summary>
    /// >> 369 - Variant[pallet_tx_pause.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
