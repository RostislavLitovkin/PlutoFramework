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


namespace PolkadotAssetHub.NetApi.Generated.Model.pallet_asset_conversion.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Pallet's callable functions.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> create_pool
        /// Creates an empty liquidity pool and an associated new `lp_token` asset
        /// (the id of which is returned in the `Event::PoolCreated` event).
        /// 
        /// Once a pool is created, someone may [`Pallet::add_liquidity`] to it.
        /// </summary>
        create_pool = 0,
        
        /// <summary>
        /// >> add_liquidity
        /// Provide liquidity into the pool of `asset1` and `asset2`.
        /// NOTE: an optimal amount of asset1 and asset2 will be calculated and
        /// might be different than the provided `amount1_desired`/`amount2_desired`
        /// thus you should provide the min amount you're happy to provide.
        /// Params `amount1_min`/`amount2_min` represent that.
        /// `mint_to` will be sent the liquidity tokens that represent this share of the pool.
        /// 
        /// NOTE: when encountering an incorrect exchange rate and non-withdrawable pool liquidity,
        /// batch an atomic call with [`Pallet::add_liquidity`] and
        /// [`Pallet::swap_exact_tokens_for_tokens`] or [`Pallet::swap_tokens_for_exact_tokens`]
        /// calls to render the liquidity withdrawable and rectify the exchange rate.
        /// 
        /// Once liquidity is added, someone may successfully call
        /// [`Pallet::swap_exact_tokens_for_tokens`].
        /// </summary>
        add_liquidity = 1,
        
        /// <summary>
        /// >> remove_liquidity
        /// Allows you to remove liquidity by providing the `lp_token_burn` tokens that will be
        /// burned in the process. With the usage of `amount1_min_receive`/`amount2_min_receive`
        /// it's possible to control the min amount of returned tokens you're happy with.
        /// </summary>
        remove_liquidity = 2,
        
        /// <summary>
        /// >> swap_exact_tokens_for_tokens
        /// Swap the exact amount of `asset1` into `asset2`.
        /// `amount_out_min` param allows you to specify the min amount of the `asset2`
        /// you're happy to receive.
        /// 
        /// [`AssetConversionApi::quote_price_exact_tokens_for_tokens`] runtime call can be called
        /// for a quote.
        /// </summary>
        swap_exact_tokens_for_tokens = 3,
        
        /// <summary>
        /// >> swap_tokens_for_exact_tokens
        /// Swap any amount of `asset1` to get the exact amount of `asset2`.
        /// `amount_in_max` param allows to specify the max amount of the `asset1`
        /// you're happy to provide.
        /// 
        /// [`AssetConversionApi::quote_price_tokens_for_exact_tokens`] runtime call can be called
        /// for a quote.
        /// </summary>
        swap_tokens_for_exact_tokens = 4,
        
        /// <summary>
        /// >> touch
        /// Touch an existing pool to fulfill prerequisites before providing liquidity, such as
        /// ensuring that the pool's accounts are in place. It is typically useful when a pool
        /// creator removes the pool's accounts and does not provide a liquidity. This action may
        /// involve holding assets from the caller as a deposit for creating the pool's accounts.
        /// 
        /// The origin must be Signed.
        /// 
        /// - `asset1`: The asset ID of an existing pool with a pair (asset1, asset2).
        /// - `asset2`: The asset ID of an existing pool with a pair (asset1, asset2).
        /// 
        /// Emits `Touched` event when successful.
        /// </summary>
        touch = 5,
    }
    
    /// <summary>
    /// >> 386 - Variant[pallet_asset_conversion.pallet.Call]
    /// Pallet's callable functions.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Call.create_pool);
				AddTypeDecoder<BaseTuple<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, PolkadotAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Call.add_liquidity);
				AddTypeDecoder<BaseTuple<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, PolkadotAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Call.remove_liquidity);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, PolkadotAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.swap_exact_tokens_for_tokens);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, PolkadotAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.swap_tokens_for_exact_tokens);
				AddTypeDecoder<BaseTuple<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location, PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.location.Location>>(Call.touch);
        }
    }
}
