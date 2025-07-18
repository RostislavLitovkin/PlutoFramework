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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_flexible_fee.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NotEnoughBalance
        /// The account does not have enough balance to perform the operation.
        /// </summary>
        NotEnoughBalance = 0,
        
        /// <summary>
        /// >> ConversionError
        /// An error occurred during currency conversion.
        /// </summary>
        ConversionError = 1,
        
        /// <summary>
        /// >> WeightAndFeeNotExist
        /// No weight or fee information is available for the requested operation.
        /// </summary>
        WeightAndFeeNotExist = 2,
        
        /// <summary>
        /// >> UnweighableMessage
        /// The message cannot be weighed, possibly due to insufficient information.
        /// </summary>
        UnweighableMessage = 3,
        
        /// <summary>
        /// >> XcmExecutionFailed
        /// The XCM execution has failed.
        /// </summary>
        XcmExecutionFailed = 4,
        
        /// <summary>
        /// >> CurrencyNotSupport
        /// The specified currency is not supported by the system.
        /// </summary>
        CurrencyNotSupport = 5,
        
        /// <summary>
        /// >> MaxCurrenciesReached
        /// The maximum number of currencies that can be handled has been reached.
        /// </summary>
        MaxCurrenciesReached = 6,
        
        /// <summary>
        /// >> EvmPermitExpired
        /// EVM permit expired.
        /// </summary>
        EvmPermitExpired = 7,
        
        /// <summary>
        /// >> EvmPermitInvalid
        /// EVM permit is invalid.
        /// </summary>
        EvmPermitInvalid = 8,
        
        /// <summary>
        /// >> EvmPermitCallExecutionError
        /// EVM permit call failed.
        /// </summary>
        EvmPermitCallExecutionError = 9,
        
        /// <summary>
        /// >> EvmPermitRunnerError
        /// EVM permit call failed.
        /// </summary>
        EvmPermitRunnerError = 10,
        
        /// <summary>
        /// >> PercentageCalculationFailed
        /// Percentage calculation failed due to overflow.
        /// </summary>
        PercentageCalculationFailed = 11,
    }
    
    /// <summary>
    /// >> 891 - Variant[bifrost_flexible_fee.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
