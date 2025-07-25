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


namespace BifrostPolkadot.NetApi.Generated.Model.pallet_ismp.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// Pallet errors
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> InvalidMessage
        /// Invalid ISMP message
        /// </summary>
        InvalidMessage = 0,
        
        /// <summary>
        /// >> MessageNotFound
        /// Requested message was not found
        /// </summary>
        MessageNotFound = 1,
        
        /// <summary>
        /// >> ConsensusClientCreationFailed
        /// Encountered an error while creating the consensus client.
        /// </summary>
        ConsensusClientCreationFailed = 2,
        
        /// <summary>
        /// >> UnbondingPeriodUpdateFailed
        /// Couldn't update unbonding period
        /// </summary>
        UnbondingPeriodUpdateFailed = 3,
        
        /// <summary>
        /// >> ChallengePeriodUpdateFailed
        /// Couldn't update challenge period
        /// </summary>
        ChallengePeriodUpdateFailed = 4,
    }
    
    /// <summary>
    /// >> 888 - Variant[pallet_ismp.pallet.Error]
    /// Pallet errors
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
