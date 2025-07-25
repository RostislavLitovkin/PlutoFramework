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


namespace BifrostPolkadot.NetApi.Generated.Model.lend_market.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> CollateralAssetAdded
        /// Enable collateral for certain asset
        /// [sender, asset_id]
        /// </summary>
        CollateralAssetAdded = 0,
        
        /// <summary>
        /// >> CollateralAssetRemoved
        /// Disable collateral for certain asset
        /// [sender, asset_id]
        /// </summary>
        CollateralAssetRemoved = 1,
        
        /// <summary>
        /// >> Deposited
        /// Event emitted when assets are deposited
        /// [sender, asset_id, amount]
        /// </summary>
        Deposited = 2,
        
        /// <summary>
        /// >> Redeemed
        /// Event emitted when assets are redeemed
        /// [sender, asset_id, amount]
        /// </summary>
        Redeemed = 3,
        
        /// <summary>
        /// >> Borrowed
        /// Event emitted when cash is borrowed
        /// [sender, asset_id, amount]
        /// </summary>
        Borrowed = 4,
        
        /// <summary>
        /// >> RepaidBorrow
        /// Event emitted when a borrow is repaid
        /// [sender, asset_id, amount]
        /// </summary>
        RepaidBorrow = 5,
        
        /// <summary>
        /// >> LiquidatedBorrow
        /// Event emitted when a borrow is liquidated
        /// [liquidator, borrower, liquidation_asset_id, collateral_asset_id, repay_amount,
        /// collateral_amount]
        /// </summary>
        LiquidatedBorrow = 6,
        
        /// <summary>
        /// >> ReservesReduced
        /// Event emitted when the reserves are reduced
        /// [admin, asset_id, reduced_amount, total_reserves]
        /// </summary>
        ReservesReduced = 7,
        
        /// <summary>
        /// >> ReservesAdded
        /// Event emitted when the reserves are added
        /// [admin, asset_id, added_amount, total_reserves]
        /// </summary>
        ReservesAdded = 8,
        
        /// <summary>
        /// >> NewMarket
        /// New market is set
        /// [new_interest_rate_model]
        /// </summary>
        NewMarket = 9,
        
        /// <summary>
        /// >> ActivatedMarket
        /// Event emitted when a market is activated
        /// [admin, asset_id]
        /// </summary>
        ActivatedMarket = 10,
        
        /// <summary>
        /// >> UpdatedMarket
        /// New market parameters is updated
        /// [admin, asset_id]
        /// </summary>
        UpdatedMarket = 11,
        
        /// <summary>
        /// >> RewardAdded
        /// Reward added
        /// </summary>
        RewardAdded = 12,
        
        /// <summary>
        /// >> RewardWithdrawn
        /// Reward withdrawed
        /// </summary>
        RewardWithdrawn = 13,
        
        /// <summary>
        /// >> MarketRewardSpeedUpdated
        /// Event emitted when market reward speed updated.
        /// </summary>
        MarketRewardSpeedUpdated = 14,
        
        /// <summary>
        /// >> DistributedSupplierReward
        /// Deposited when Reward is distributed to a supplier
        /// </summary>
        DistributedSupplierReward = 15,
        
        /// <summary>
        /// >> DistributedBorrowerReward
        /// Deposited when Reward is distributed to a borrower
        /// </summary>
        DistributedBorrowerReward = 16,
        
        /// <summary>
        /// >> RewardPaid
        /// Reward Paid for user
        /// </summary>
        RewardPaid = 17,
        
        /// <summary>
        /// >> IncentiveReservesReduced
        /// Event emitted when the incentive reserves are redeemed and transfer to receiver's
        /// account [receive_account_id, asset_id, reduced_amount]
        /// </summary>
        IncentiveReservesReduced = 18,
        
        /// <summary>
        /// >> LiquidationFreeCollateralsUpdated
        /// Liquidation free collaterals has been updated
        /// </summary>
        LiquidationFreeCollateralsUpdated = 19,
        
        /// <summary>
        /// >> MarketBonded
        /// </summary>
        MarketBonded = 20,
    }
    
    /// <summary>
    /// >> 610 - Variant[lend_market.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId>>(Event.CollateralAssetAdded);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId>>(Event.CollateralAssetRemoved);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Deposited);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Redeemed);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Borrowed);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.RepaidBorrow);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.LiquidatedBorrow);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.ReservesReduced);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.ReservesAdded);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, BifrostPolkadot.NetApi.Generated.Model.lend_market.types.Market>>(Event.NewMarket);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId>(Event.ActivatedMarket);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, BifrostPolkadot.NetApi.Generated.Model.lend_market.types.Market>>(Event.UpdatedMarket);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.RewardAdded);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.RewardWithdrawn);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.MarketRewardSpeedUpdated);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.DistributedSupplierReward);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.DistributedBorrowerReward);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.RewardPaid);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.IncentiveReservesReduced);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId>>(Event.LiquidationFreeCollateralsUpdated);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Base.BaseVec<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId>>>(Event.MarketBonded);
        }
    }
}
