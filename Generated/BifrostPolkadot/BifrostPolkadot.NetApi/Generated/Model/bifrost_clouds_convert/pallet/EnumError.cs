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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_clouds_convert.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NotEnoughBalance
        /// </summary>
        NotEnoughBalance = 0,
        
        /// <summary>
        /// >> CalculationOverflow
        /// </summary>
        CalculationOverflow = 1,
        
        /// <summary>
        /// >> LessThanExpected
        /// </summary>
        LessThanExpected = 2,
        
        /// <summary>
        /// >> LessThanExistentialDeposit
        /// </summary>
        LessThanExistentialDeposit = 3,
    }
    
    /// <summary>
    /// >> 1019 - Variant[bifrost_clouds_convert.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
