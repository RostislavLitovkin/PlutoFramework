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


namespace Hydration.NetApi.Generated.Model.pallet_hsm.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> add_collateral_asset
        /// Add a new collateral asset
        /// 
        /// This function adds a new asset as an approved collateral for Hollar. Only callable by
        /// the governance (root origin).
        /// 
        /// Parameters:
        /// - `origin`: Must be Root
        /// - `asset_id`: Asset ID to be added as collateral
        /// - `pool_id`: StableSwap pool ID where this asset and Hollar are paired
        /// - `purchase_fee`: Fee applied when buying Hollar with this asset (added to purchase price)
        /// - `max_buy_price_coefficient`: Maximum buy price coefficient for HSM to buy back Hollar
        /// - `buy_back_fee`: Fee applied when buying back Hollar (subtracted from buy price)
        /// - `buyback_rate`: Parameter that controls how quickly HSM can buy Hollar with this asset
        /// - `max_in_holding`: Optional maximum amount of collateral HSM can hold
        /// 
        /// Emits:
        /// - `CollateralAdded` when the collateral is successfully added
        /// 
        /// Errors:
        /// - `AssetAlreadyApproved` if the asset is already registered as a collateral
        /// - `PoolAlreadyHasCollateral` if another asset from the same pool is already approved
        /// - `HollarNotInPool` if Hollar is not found in the specified pool
        /// - `AssetNotInPool` if the collateral asset is not found in the specified pool
        /// - Other errors from underlying calls
        /// </summary>
        add_collateral_asset = 0,
        
        /// <summary>
        /// >> remove_collateral_asset
        /// Remove a collateral asset
        /// 
        /// Removes an asset from the approved collaterals list. Only callable by the governance (root origin).
        /// The collateral must have a zero balance in the HSM account before it can be removed.
        /// 
        /// Parameters:
        /// - `origin`: Must be Root
        /// - `asset_id`: Asset ID to remove from collaterals
        /// 
        /// Emits:
        /// - `CollateralRemoved` when the collateral is successfully removed
        /// 
        /// Errors:
        /// - `AssetNotApproved` if the asset is not a registered collateral
        /// - `CollateralNotEmpty` if the HSM account still holds some of this asset
        /// </summary>
        remove_collateral_asset = 1,
        
        /// <summary>
        /// >> update_collateral_asset
        /// Update collateral asset parameters
        /// 
        /// Updates the parameters for an existing collateral asset. Only callable by the governance (root origin).
        /// Each parameter is optional and only provided parameters will be updated.
        /// 
        /// Parameters:
        /// - `origin`: Must be Root
        /// - `asset_id`: Asset ID to update
        /// - `purchase_fee`: New purchase fee (optional)
        /// - `max_buy_price_coefficient`: New max buy price coefficient (optional)
        /// - `buy_back_fee`: New buy back fee (optional)
        /// - `buyback_rate`: New buyback rate parameter (optional)
        /// - `max_in_holding`: New maximum holding amount (optional)
        /// 
        /// Emits:
        /// - `CollateralUpdated` when the collateral is successfully updated
        /// 
        /// Errors:
        /// - `AssetNotApproved` if the asset is not a registered collateral
        /// </summary>
        update_collateral_asset = 2,
        
        /// <summary>
        /// >> sell
        /// Sell asset to HSM
        /// 
        /// This function allows users to:
        /// 1. Sell Hollar back to HSM in exchange for collateral assets
        /// 2. Sell collateral assets to HSM in exchange for newly minted Hollar
        /// 
        /// The valid pairs must include Hollar as one side and an approved collateral as the other side.
        /// 
        /// Parameters:
        /// - `origin`: Account selling the asset
        /// - `asset_in`: Asset ID being sold
        /// - `asset_out`: Asset ID being bought
        /// - `amount_in`: Amount of asset_in to sell
        /// - `slippage_limit`: Minimum amount out for slippage protection
        /// 
        /// Emits:
        /// - `Swapped3` when the sell is successful
        /// 
        /// Errors:
        /// - `InvalidAssetPair` if the pair is not Hollar and an approved collateral
        /// - `AssetNotApproved` if the collateral asset isn't registered
        /// - `SlippageLimitExceeded` if the amount received is less than the slippage limit
        /// - `MaxBuyBackExceeded` if the sell would exceed the maximum buy back rate
        /// - `MaxBuyPriceExceeded` if the sell would exceed the maximum buy price
        /// - `InsufficientCollateralBalance` if HSM doesn't have enough collateral
        /// - `InvalidEVMInteraction` if there's an error interacting with the Hollar ERC20 contract
        /// - Other errors from underlying calls
        /// </summary>
        sell = 3,
        
        /// <summary>
        /// >> buy
        /// Buy asset from HSM
        /// 
        /// This function allows users to:
        /// 1. Buy Hollar from HSM using collateral assets
        /// 2. Buy collateral assets from HSM using Hollar
        /// 
        /// The valid pairs must include Hollar as one side and an approved collateral as the other side.
        /// 
        /// Parameters:
        /// - `origin`: Account buying the asset
        /// - `asset_in`: Asset ID being sold by the user
        /// - `asset_out`: Asset ID being bought by the user
        /// - `amount_out`: Amount of asset_out to buy
        /// - `slippage_limit`: Maximum amount in for slippage protection
        /// 
        /// Emits:
        /// - `Swapped3` when the buy is successful
        /// 
        /// Errors:
        /// - `InvalidAssetPair` if the pair is not Hollar and an approved collateral
        /// - `AssetNotApproved` if the collateral asset isn't registered
        /// - `SlippageLimitExceeded` if the amount input exceeds the slippage limit
        /// - `MaxHoldingExceeded` if the buy would cause HSM to exceed its maximum holding
        /// - `InvalidEVMInteraction` if there's an error interacting with the Hollar ERC20 contract
        /// - Other errors from underlying calls
        /// </summary>
        buy = 4,
        
        /// <summary>
        /// >> execute_arbitrage
        /// Execute arbitrage opportunity between HSM and collateral stable pool
        /// 
        /// This call is designed to be triggered automatically by offchain workers. It:
        /// 1. Detects price imbalances between HSM and a stable pool for a collateral
        /// 2. If an opportunity exists, mints Hollar, swaps it for collateral on HSM
        /// 3. Swaps that collateral for Hollar on the stable pool
        /// 4. Burns the Hollar received from the arbitrage
        /// 
        /// This helps maintain the peg of Hollar by profiting from and correcting price imbalances.
        /// The call is unsigned and should only be executed by offchain workers.
        /// 
        /// Parameters:
        /// - `origin`: Must be None (unsigned)
        /// - `collateral_asset_id`: The ID of the collateral asset to check for arbitrage
        /// 
        /// Emits:
        /// - `ArbitrageExecuted` when the arbitrage is successful
        /// 
        /// Errors:
        /// - `AssetNotApproved` if the asset is not a registered collateral
        /// - `NoArbitrageOpportunity` if there's no profitable arbitrage opportunity
        /// - `MaxBuyPriceExceeded` if the arbitrage would exceed the maximum buy price
        /// - `InvalidEVMInteraction` if there's an error interacting with the Hollar ERC20 contract
        /// - Other errors from underlying calls
        /// </summary>
        execute_arbitrage = 5,
        
        /// <summary>
        /// >> set_flash_minter
        /// </summary>
        set_flash_minter = 6,
    }
    
    /// <summary>
    /// >> 259 - Variant[pallet_hsm.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Permill, Hydration.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128, Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Permill, Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Perbill, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.add_collateral_asset);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.remove_collateral_asset);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Permill>, Substrate.NetApi.Model.Types.Base.BaseOpt<Hydration.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>, Substrate.NetApi.Model.Types.Base.BaseOpt<Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Permill>, Substrate.NetApi.Model.Types.Base.BaseOpt<Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Perbill>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>>>>(Call.update_collateral_asset);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.sell);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.buy);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.execute_arbitrage);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.primitive_types.H160>(Call.set_flash_minter);
        }
    }
}
