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


namespace Hydration.NetApi.Generated.Model.pallet_staking.pallet
{
    
    
    /// <summary>
    /// >> InconsistentStateError
    /// </summary>
    public enum InconsistentStateError
    {
        
        /// <summary>
        /// >> PositionNotFound
        /// </summary>
        PositionNotFound = 0,
        
        /// <summary>
        /// >> NegativePendingRewards
        /// </summary>
        NegativePendingRewards = 1,
        
        /// <summary>
        /// >> NegativeUnpaidRewards
        /// </summary>
        NegativeUnpaidRewards = 2,
        
        /// <summary>
        /// >> TooManyPositions
        /// </summary>
        TooManyPositions = 3,
        
        /// <summary>
        /// >> Arithmetic
        /// </summary>
        Arithmetic = 4,
    }
    
    /// <summary>
    /// >> 682 - Variant[pallet_staking.pallet.InconsistentStateError]
    /// </summary>
    public sealed class EnumInconsistentStateError : BaseEnum<InconsistentStateError>
    {
    }
}
