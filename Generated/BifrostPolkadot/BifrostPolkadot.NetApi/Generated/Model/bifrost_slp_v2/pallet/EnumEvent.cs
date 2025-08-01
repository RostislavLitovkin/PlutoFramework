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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> AddDelegator
        /// Add a delegator to the staking protocol.
        /// </summary>
        AddDelegator = 0,
        
        /// <summary>
        /// >> RemoveDelegator
        /// Remove a delegator from the staking protocol.
        /// </summary>
        RemoveDelegator = 1,
        
        /// <summary>
        /// >> AddValidator
        /// Add a validator to the staking protocol.
        /// </summary>
        AddValidator = 2,
        
        /// <summary>
        /// >> RemoveValidator
        /// Remove a validator from the staking protocol.
        /// </summary>
        RemoveValidator = 3,
        
        /// <summary>
        /// >> SetConfiguration
        /// Set configuration for a specific staking protocol.
        /// </summary>
        SetConfiguration = 4,
        
        /// <summary>
        /// >> SetLedger
        /// Set ledger for a specific delegator.
        /// </summary>
        SetLedger = 5,
        
        /// <summary>
        /// >> SendXcmTask
        /// Send xcm task.
        /// </summary>
        SendXcmTask = 6,
        
        /// <summary>
        /// >> NotifyResponseReceived
        /// Xcm task response received.
        /// </summary>
        NotifyResponseReceived = 7,
        
        /// <summary>
        /// >> TimeUnitUpdated
        /// Time unit updated.
        /// </summary>
        TimeUnitUpdated = 8,
        
        /// <summary>
        /// >> TokenExchangeRateUpdated
        /// Token exchange rate updated.
        /// </summary>
        TokenExchangeRateUpdated = 9,
        
        /// <summary>
        /// >> TransferTo
        /// Transfer the staking token to remote chain.
        /// </summary>
        TransferTo = 10,
        
        /// <summary>
        /// >> TransferBack
        /// Transfer the staking token back from remote chain.
        /// </summary>
        TransferBack = 11,
        
        /// <summary>
        /// >> EthereumStaking
        /// Ethereum staking task.
        /// </summary>
        EthereumStaking = 12,
    }
    
    /// <summary>
    /// >> 620 - Variant[bifrost_slp_v2.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, Substrate.NetApi.Model.Types.Primitive.U16, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator>>(Event.AddDelegator);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, Substrate.NetApi.Model.Types.Primitive.U16, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator>>(Event.RemoveDelegator);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumValidator>>(Event.AddValidator);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumValidator>>(Event.RemoveValidator);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.ProtocolConfiguration>>(Event.SetConfiguration);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumLedger>>(Event.SetLedger);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U64>, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumXcmTask, Substrate.NetApi.Model.Types.Base.BaseOpt<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumPendingStatus>, BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Event.SendXcmTask);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumPendingStatus>>(Event.NotifyResponseReceived);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.time_unit.EnumTimeUnit>>(Event.TimeUnitUpdated);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.TokenExchangeRateUpdated);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.TransferTo);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.polkadot.EnumStakingProtocol, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.TransferBack);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.common.types.EnumDelegator, BifrostPolkadot.NetApi.Generated.Model.bifrost_slp_v2.ethereum_staking.types.EnumEthereumStaking>>(Event.EthereumStaking);
        }
    }
}
