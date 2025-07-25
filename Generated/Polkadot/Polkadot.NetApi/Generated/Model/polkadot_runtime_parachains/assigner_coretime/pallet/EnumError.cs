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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.assigner_coretime.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> AssignmentsEmpty
        /// </summary>
        AssignmentsEmpty = 0,
        
        /// <summary>
        /// >> OverScheduled
        /// Assignments together exceeded 57600.
        /// </summary>
        OverScheduled = 1,
        
        /// <summary>
        /// >> UnderScheduled
        /// Assignments together less than 57600
        /// </summary>
        UnderScheduled = 2,
        
        /// <summary>
        /// >> DisallowedInsert
        /// assign_core is only allowed to append new assignments at the end of already existing
        /// ones.
        /// </summary>
        DisallowedInsert = 3,
        
        /// <summary>
        /// >> DuplicateInsert
        /// Tried to insert a schedule for the same core and block number as an existing schedule
        /// </summary>
        DuplicateInsert = 4,
        
        /// <summary>
        /// >> AssignmentsNotSorted
        /// Tried to add an unsorted set of assignments
        /// </summary>
        AssignmentsNotSorted = 5,
    }
    
    /// <summary>
    /// >> 788 - Variant[polkadot_runtime_parachains.assigner_coretime.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
