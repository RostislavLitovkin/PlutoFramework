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


namespace Hydration.NetApi.Generated.Model.pallet_stableswap.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> create_pool
        /// Create a stable pool with given list of assets.
        /// 
        /// All assets must be correctly registered in `T::AssetRegistry`.
        /// Note that this does not seed the pool with liquidity. Use `add_liquidity` to provide
        /// initial liquidity.
        /// 
        /// Parameters:
        /// - `origin`: Must be T::AuthorityOrigin
        /// - `share_asset`: Preregistered share asset identifier
        /// - `assets`: List of Asset ids
        /// - `amplification`: Pool amplification
        /// - `fee`: fee to be applied on trade and liquidity operations
        /// 
        /// Emits `PoolCreated` event if successful.
        /// </summary>
        create_pool = 0,
        
        /// <summary>
        /// >> update_pool_fee
        /// Update pool's fee.
        /// 
        /// if pool does not exist, `PoolNotFound` is returned.
        /// 
        /// Parameters:
        /// - `origin`: Must be T::AuthorityOrigin
        /// - `pool_id`: pool to update
        /// - `fee`: new pool fee
        /// 
        /// Emits `FeeUpdated` event if successful.
        /// </summary>
        update_pool_fee = 1,
        
        /// <summary>
        /// >> update_amplification
        /// Update pool's amplification.
        /// 
        /// Parameters:
        /// - `origin`: Must be T::AuthorityOrigin
        /// - `pool_id`: pool to update
        /// - `future_amplification`: new desired pool amplification
        /// - `future_block`: future block number when the amplification is updated
        /// 
        /// Emits `AmplificationUpdated` event if successful.
        /// </summary>
        update_amplification = 2,
        
        /// <summary>
        /// >> add_liquidity
        /// Add liquidity to selected pool.
        /// 
        /// First call of `add_liquidity` must provide "initial liquidity" of all assets.
        /// 
        /// If there is liquidity already in the pool, LP can provide liquidity of any number of pool assets.
        /// 
        /// LP must have sufficient amount of each asset.
        /// 
        /// Origin is given corresponding amount of shares.
        /// 
        /// Parameters:
        /// - `origin`: liquidity provider
        /// - `pool_id`: Pool Id
        /// - `assets`: asset id and liquidity amount provided
        /// 
        /// Emits `LiquidityAdded` event when successful.
        /// </summary>
        add_liquidity = 3,
        
        /// <summary>
        /// >> add_liquidity_shares
        /// Add liquidity to selected pool given exact amount of shares to receive.
        /// 
        /// Similar to `add_liquidity` but LP specifies exact amount of shares to receive.
        /// 
        /// This functionality is used mainly by on-chain routing when a swap between Omnipool asset and stable asset is performed.
        /// 
        /// Parameters:
        /// - `origin`: liquidity provider
        /// - `pool_id`: Pool Id
        /// - `shares`: amount of shares to receive
        /// - `asset_id`: asset id of an asset to provide as liquidity
        /// - `max_asset_amount`: slippage limit. Max amount of asset.
        /// 
        /// Emits `LiquidityAdded` event when successful.
        /// </summary>
        add_liquidity_shares = 4,
        
        /// <summary>
        /// >> remove_liquidity_one_asset
        /// Remove liquidity from selected pool.
        /// 
        /// Withdraws liquidity of selected asset from a pool.
        /// 
        /// Share amount is burned and LP receives corresponding amount of chosen asset.
        /// 
        /// Withdraw fee is applied to the asset amount.
        /// 
        /// Parameters:
        /// - `origin`: liquidity provider
        /// - `pool_id`: Pool Id
        /// - `asset_id`: id of asset to receive
        /// - 'share_amount': amount of shares to withdraw
        /// - 'min_amount_out': minimum amount to receive
        /// 
        /// Emits `LiquidityRemoved` event when successful.
        /// </summary>
        remove_liquidity_one_asset = 5,
        
        /// <summary>
        /// >> withdraw_asset_amount
        /// Remove liquidity from selected pool by specifying exact amount of asset to receive.
        /// 
        /// Similar to `remove_liquidity_one_asset` but LP specifies exact amount of asset to receive instead of share amount.
        /// 
        /// Parameters:
        /// - `origin`: liquidity provider
        /// - `pool_id`: Pool Id
        /// - `asset_id`: id of asset to receive
        /// - 'amount': amount of asset to receive
        /// - 'max_share_amount': Slippage limit. Max amount of shares to burn.
        /// 
        /// Emits `LiquidityRemoved` event when successful.
        /// </summary>
        withdraw_asset_amount = 6,
        
        /// <summary>
        /// >> sell
        /// Execute a swap of `asset_in` for `asset_out`.
        /// 
        /// Parameters:
        /// - `origin`: origin of the caller
        /// - `pool_id`: Id of a pool
        /// - `asset_in`: ID of asset sold to the pool
        /// - `asset_out`: ID of asset bought from the pool
        /// - `amount_in`: Amount of asset to be sold to the pool
        /// - `min_buy_amount`: Minimum amount required to receive
        /// 
        /// Emits `SellExecuted` event when successful.
        /// 
        /// </summary>
        sell = 7,
        
        /// <summary>
        /// >> buy
        /// Execute a swap of `asset_in` for `asset_out`.
        /// 
        /// Parameters:
        /// - `origin`:
        /// - `pool_id`: Id of a pool
        /// - `asset_out`: ID of asset bought from the pool
        /// - `asset_in`: ID of asset sold to the pool
        /// - `amount_out`: Amount of asset to receive from the pool
        /// - `max_sell_amount`: Maximum amount allowed to be sold
        /// 
        /// Emits `BuyExecuted` event when successful.
        /// 
        /// </summary>
        buy = 8,
        
        /// <summary>
        /// >> set_asset_tradable_state
        /// </summary>
        set_asset_tradable_state = 9,
        
        /// <summary>
        /// >> remove_liquidity
        /// </summary>
        remove_liquidity = 10,
    }
    
    /// <summary>
    /// >> 375 - Variant[pallet_stableswap.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Primitive.U16, Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Permill>>(Call.create_pool);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Permill>>(Call.update_pool_fee);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.update_amplification);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.pallet_stableswap.types.AssetAmount>>>(Call.add_liquidity);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.add_liquidity_shares);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.remove_liquidity_one_asset);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.withdraw_asset_amount);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.sell);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.buy);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.pallet_stableswap.types.Tradability>>(Call.set_asset_tradable_state);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT20>>(Call.remove_liquidity);
        }
    }
}
