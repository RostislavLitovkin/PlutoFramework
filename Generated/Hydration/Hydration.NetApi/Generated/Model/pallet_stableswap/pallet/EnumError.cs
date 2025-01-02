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
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> IncorrectAssets
        /// Creating a pool with same assets or less than 2 assets is not allowed.
        /// </summary>
        IncorrectAssets = 0,
        
        /// <summary>
        /// >> MaxAssetsExceeded
        /// Maximum number of assets has been exceeded.
        /// </summary>
        MaxAssetsExceeded = 1,
        
        /// <summary>
        /// >> PoolNotFound
        /// A pool with given assets does not exist.
        /// </summary>
        PoolNotFound = 2,
        
        /// <summary>
        /// >> PoolExists
        /// A pool with given assets already exists.
        /// </summary>
        PoolExists = 3,
        
        /// <summary>
        /// >> AssetNotInPool
        /// Asset is not in the pool.
        /// </summary>
        AssetNotInPool = 4,
        
        /// <summary>
        /// >> ShareAssetNotRegistered
        /// Share asset is not registered in Registry.
        /// </summary>
        ShareAssetNotRegistered = 5,
        
        /// <summary>
        /// >> ShareAssetInPoolAssets
        /// Share asset is amount assets when creating a pool.
        /// </summary>
        ShareAssetInPoolAssets = 6,
        
        /// <summary>
        /// >> AssetNotRegistered
        /// One or more assets are not registered in AssetRegistry
        /// </summary>
        AssetNotRegistered = 7,
        
        /// <summary>
        /// >> InvalidAssetAmount
        /// Invalid asset amount provided. Amount must be greater than zero.
        /// </summary>
        InvalidAssetAmount = 8,
        
        /// <summary>
        /// >> InsufficientBalance
        /// Balance of an asset is not sufficient to perform a trade.
        /// </summary>
        InsufficientBalance = 9,
        
        /// <summary>
        /// >> InsufficientShares
        /// Balance of a share asset is not sufficient to withdraw liquidity.
        /// </summary>
        InsufficientShares = 10,
        
        /// <summary>
        /// >> InsufficientLiquidity
        /// Liquidity has not reached the required minimum.
        /// </summary>
        InsufficientLiquidity = 11,
        
        /// <summary>
        /// >> InsufficientLiquidityRemaining
        /// Insufficient liquidity left in the pool after withdrawal.
        /// </summary>
        InsufficientLiquidityRemaining = 12,
        
        /// <summary>
        /// >> InsufficientTradingAmount
        /// Amount is less than the minimum trading amount configured.
        /// </summary>
        InsufficientTradingAmount = 13,
        
        /// <summary>
        /// >> BuyLimitNotReached
        /// Minimum limit has not been reached during trade.
        /// </summary>
        BuyLimitNotReached = 14,
        
        /// <summary>
        /// >> SellLimitExceeded
        /// Maximum limit has been exceeded during trade.
        /// </summary>
        SellLimitExceeded = 15,
        
        /// <summary>
        /// >> InvalidInitialLiquidity
        /// Initial liquidity of asset must be > 0.
        /// </summary>
        InvalidInitialLiquidity = 16,
        
        /// <summary>
        /// >> InvalidAmplification
        /// Amplification is outside configured range.
        /// </summary>
        InvalidAmplification = 17,
        
        /// <summary>
        /// >> InsufficientShareBalance
        /// Remaining balance of share asset is below asset's existential deposit.
        /// </summary>
        InsufficientShareBalance = 18,
        
        /// <summary>
        /// >> NotAllowed
        /// Not allowed to perform an operation on given asset.
        /// </summary>
        NotAllowed = 19,
        
        /// <summary>
        /// >> PastBlock
        /// Future block number is in the past.
        /// </summary>
        PastBlock = 20,
        
        /// <summary>
        /// >> SameAmplification
        /// New amplification is equal to the previous value.
        /// </summary>
        SameAmplification = 21,
        
        /// <summary>
        /// >> SlippageLimit
        /// Slippage protection.
        /// </summary>
        SlippageLimit = 22,
        
        /// <summary>
        /// >> UnknownDecimals
        /// Failed to retrieve asset decimals.
        /// </summary>
        UnknownDecimals = 23,
    }
    
    /// <summary>
    /// >> 611 - Variant[pallet_stableswap.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
