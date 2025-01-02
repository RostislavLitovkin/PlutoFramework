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


namespace XCavatePaseo.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> BadQueueConfig
        /// Setting the queue config failed since one of its values was invalid.
        /// </summary>
        BadQueueConfig = 0,
        
        /// <summary>
        /// >> AlreadySuspended
        /// The execution is already suspended.
        /// </summary>
        AlreadySuspended = 1,
        
        /// <summary>
        /// >> AlreadyResumed
        /// The execution is already resumed.
        /// </summary>
        AlreadyResumed = 2,
    }
    
    /// <summary>
    /// >> 470 - Variant[cumulus_pallet_xcmp_queue.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
