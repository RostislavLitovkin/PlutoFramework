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


namespace Polkadot.NetApi.Generated.Model.pallet_fast_unstake.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NotController
        /// The provided Controller account was not found.
        /// 
        /// This means that the given account is not bonded.
        /// </summary>
        NotController = 0,
        
        /// <summary>
        /// >> AlreadyQueued
        /// The bonded account has already been queued.
        /// </summary>
        AlreadyQueued = 1,
        
        /// <summary>
        /// >> NotFullyBonded
        /// The bonded account has active unlocking chunks.
        /// </summary>
        NotFullyBonded = 2,
        
        /// <summary>
        /// >> NotQueued
        /// The provided un-staker is not in the `Queue`.
        /// </summary>
        NotQueued = 3,
        
        /// <summary>
        /// >> AlreadyHead
        /// The provided un-staker is already in Head, and cannot deregister.
        /// </summary>
        AlreadyHead = 4,
        
        /// <summary>
        /// >> CallNotAllowed
        /// The call is not allowed at this point because the pallet is not active.
        /// </summary>
        CallNotAllowed = 5,
    }
    
    /// <summary>
    /// >> 704 - Variant[pallet_fast_unstake.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
