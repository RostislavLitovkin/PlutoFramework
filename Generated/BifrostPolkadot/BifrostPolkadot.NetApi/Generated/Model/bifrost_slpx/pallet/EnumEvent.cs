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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_slpx.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> AddWhitelistAccountId
        /// Add the contract account to the whitelist
        /// </summary>
        AddWhitelistAccountId = 0,
        
        /// <summary>
        /// >> RemoveWhitelistAccountId
        /// Remove the contract account from the whitelist
        /// </summary>
        RemoveWhitelistAccountId = 1,
        
        /// <summary>
        /// >> SetTransferToFee
        /// Set the transfer fee for the currency, only for Moonbeam
        /// </summary>
        SetTransferToFee = 2,
        
        /// <summary>
        /// >> SetExecutionFee
        /// Set the execution fee for the order
        /// </summary>
        SetExecutionFee = 3,
        
        /// <summary>
        /// >> SupportXcmOracle
        /// Support currency to xcm oracle
        /// </summary>
        SupportXcmOracle = 4,
        
        /// <summary>
        /// >> SetXcmOracleConfiguration
        /// Set the xcm oracle configuration
        /// </summary>
        SetXcmOracleConfiguration = 5,
        
        /// <summary>
        /// >> XcmOracle
        /// Send Xcm message
        /// </summary>
        XcmOracle = 6,
        
        /// <summary>
        /// >> SetCurrencyToSupportXcmFee
        /// Set the currency to support the XCM fee
        /// </summary>
        SetCurrencyToSupportXcmFee = 7,
        
        /// <summary>
        /// >> SetDelayBlock
        /// Set the delay block
        /// </summary>
        SetDelayBlock = 8,
        
        /// <summary>
        /// >> CreateOrder
        /// Create order
        /// </summary>
        CreateOrder = 9,
        
        /// <summary>
        /// >> OrderHandled
        /// Order handled
        /// </summary>
        OrderHandled = 10,
        
        /// <summary>
        /// >> OrderFailed
        /// Order failed
        /// </summary>
        OrderFailed = 11,
        
        /// <summary>
        /// >> XcmOracleFailed
        /// Xcm oracle failed
        /// </summary>
        XcmOracleFailed = 12,
        
        /// <summary>
        /// >> InsufficientAssets
        /// Withdraw xcm fee
        /// </summary>
        InsufficientAssets = 13,
        
        /// <summary>
        /// >> SetHyperBridgeOracleConfig
        /// Set HyperBridge Oracle Config
        /// </summary>
        SetHyperBridgeOracleConfig = 14,
        
        /// <summary>
        /// >> SetHydrationOracleConfig
        /// Set Hydration Oracle Config
        /// </summary>
        SetHydrationOracleConfig = 15,
        
        /// <summary>
        /// >> AsyncMintExecuted
        /// Async Mint executed
        /// </summary>
        AsyncMintExecuted = 16,
        
        /// <summary>
        /// >> AsyncMintConfigUpdated
        /// Async Mint configuration updated
        /// </summary>
        AsyncMintConfigUpdated = 17,
        
        /// <summary>
        /// >> AsyncMintExecutionFailed
        /// Async Mint execution failed
        /// </summary>
        AsyncMintExecutionFailed = 18,
    }
    
    /// <summary>
    /// >> 601 - Variant[bifrost_slpx.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.EnumSupportChain, BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.AddWhitelistAccountId);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.EnumSupportChain, BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.RemoveWhitelistAccountId);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.EnumSupportChain, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.SetTransferToFee);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.SetExecutionFee);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.Bool>>(Event.SupportXcmOracle);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, BifrostPolkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight, Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160>>(Event.SetXcmOracleConfiguration);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.XcmOracle);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.Bool>>(Event.SetCurrencyToSupportXcmFee);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.SetDelayBlock);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.bifrost_slpx.types.Order>(Event.CreateOrder);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.bifrost_slpx.types.Order>(Event.OrderHandled);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.bifrost_slpx.types.Order>(Event.OrderFailed);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_runtime.EnumDispatchError>(Event.XcmOracleFailed);
				AddTypeDecoder<BaseVoid>(Event.InsufficientAssets);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.primitive_types.H160, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT18>>(Event.SetHyperBridgeOracleConfig);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT19>>(Event.SetHydrationOracleConfig);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.AsyncMintExecuted);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.bifrost_slpx.types.AsyncMintConfiguration>(Event.AsyncMintConfigUpdated);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.AsyncMintExecutionFailed);
        }
    }
}
