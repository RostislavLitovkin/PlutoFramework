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


namespace Hydration.NetApi.Generated.Model.pallet_omnipool_liquidity_mining.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> create_global_farm
        /// Create a new liquidity mining program with provided parameters.
        /// 
        /// `owner` account has to have at least `total_rewards` balance. These funds will be
        /// transferred from `owner` to farm account.
        /// 
        /// The dispatch origin for this call must be `T::CreateOrigin`.
        /// !!!WARN: `T::CreateOrigin` has power over funds of `owner`'s account and it should be
        /// configured to trusted origin e.g Sudo or Governance.
        /// 
        /// Parameters:
        /// - `origin`: account allowed to create new liquidity mining program(root, governance).
        /// - `total_rewards`: total rewards planned to distribute. These rewards will be
        /// distributed between all yield farms in the global farm.
        /// - `planned_yielding_periods`: planned number of periods to distribute `total_rewards`.
        /// WARN: THIS IS NOT HARD DEADLINE. Not all rewards have to be distributed in
        /// `planned_yielding_periods`. Rewards are distributed based on the situation in the yield
        /// farms and can be distributed in a longer, though never in a shorter, time frame.
        /// - `blocks_per_period`:  number of blocks in a single period. Min. number of blocks per
        /// period is 1.
        /// - `reward_currency`: payoff currency of rewards.
        /// - `owner`: liq. mining farm owner. This account will be able to manage created
        /// liquidity mining program.
        /// - `yield_per_period`: percentage return on `reward_currency` of all farms.
        /// - `min_deposit`: minimum amount of LP shares to be deposited into the liquidity mining by each user.
        /// - `lrna_price_adjustment`: price adjustment between `[LRNA]` and `reward_currency`.
        /// 
        /// Emits `GlobalFarmCreated` when successful.
        /// 
        /// </summary>
        create_global_farm = 0,
        
        /// <summary>
        /// >> terminate_global_farm
        /// Terminate existing liq. mining program.
        /// 
        /// Only farm owner can perform this action.
        /// 
        /// WARN: To successfully terminate a global farm, farm have to be empty
        /// (all yield farms in the global farm must be terminated).
        /// 
        /// Parameters:
        /// - `origin`: global farm's owner.
        /// - `global_farm_id`: id of global farm to be terminated.
        /// 
        /// Emits `GlobalFarmTerminated` event when successful.
        /// 
        /// </summary>
        terminate_global_farm = 2,
        
        /// <summary>
        /// >> create_yield_farm
        /// Create yield farm for given `asset_id` in the omnipool.
        ///  
        /// Only farm owner can perform this action.
        /// 
        /// Asset with `asset_id` has to be registered in the omnipool.
        /// At most one `active` yield farm can exist in one global farm for the same `asset_id`.
        /// 
        /// Parameters:
        /// - `origin`: global farm's owner.
        /// - `global_farm_id`: global farm id to which a yield farm will be added.
        /// - `asset_id`: id of a asset in the omnipool. Yield farm will be created
        /// for this asset and user will be able to lock LP shares into this yield farm immediately.
        /// - `multiplier`: yield farm's multiplier.
        /// - `loyalty_curve`: curve to calculate loyalty multiplier to distribute rewards to users
        /// with time incentive. `None` means no loyalty multiplier.
        /// 
        /// Emits `YieldFarmCreated` event when successful.
        /// 
        /// </summary>
        create_yield_farm = 3,
        
        /// <summary>
        /// >> update_yield_farm
        /// Update yield farm's multiplier.
        ///  
        /// Only farm owner can perform this action.
        /// 
        /// Parameters:
        /// - `origin`: global farm's owner.
        /// - `global_farm_id`: global farm id in which yield farm will be updated.
        /// - `asset_id`: id of the asset identifying yield farm in the global farm.
        /// - `multiplier`: new yield farm's multiplier.
        /// 
        /// Emits `YieldFarmUpdated` event when successful.
        /// 
        /// </summary>
        update_yield_farm = 4,
        
        /// <summary>
        /// >> stop_yield_farm
        /// Stop liquidity miming for specific yield farm.
        /// 
        /// This function claims rewards from `GlobalFarm` last time and stop yield farm
        /// incentivization from a `GlobalFarm`. Users will be able to only withdraw
        /// shares(with claiming) after calling this function.
        /// `deposit_shares()` is not allowed on stopped yield farm.
        ///  
        /// Only farm owner can perform this action.
        /// 
        /// Parameters:
        /// - `origin`: global farm's owner.
        /// - `global_farm_id`: farm id in which yield farm will be canceled.
        /// - `asset_id`: id of the asset identifying yield farm in the global farm.
        /// 
        /// Emits `YieldFarmStopped` event when successful.
        /// 
        /// </summary>
        stop_yield_farm = 5,
        
        /// <summary>
        /// >> resume_yield_farm
        /// Resume incentivization of the asset represented by yield farm.
        /// 
        /// This function resume incentivization of the asset from the `GlobalFarm` and
        /// restore full functionality or the yield farm. Users will be able to deposit,
        /// claim and withdraw again.
        /// 
        /// WARN: Yield farm(and users) is NOT rewarded for time it was stopped.
        /// 
        /// Only farm owner can perform this action.
        /// 
        /// Parameters:
        /// - `origin`: global farm's owner.
        /// - `global_farm_id`: global farm id in which yield farm will be resumed.
        /// - `yield_farm_id`: id of the yield farm to be resumed.
        /// - `asset_id`: id of the asset identifying yield farm in the global farm.
        /// - `multiplier`: yield farm multiplier.
        /// 
        /// Emits `YieldFarmResumed` event when successful.
        /// 
        /// </summary>
        resume_yield_farm = 6,
        
        /// <summary>
        /// >> terminate_yield_farm
        /// Terminate yield farm.
        /// 
        /// This function marks a yield farm as ready to be removed from storage when it's empty. Users will
        /// be able to only withdraw shares(without claiming rewards from yield farm). Unpaid rewards
        /// will be transferred back to global farm and it will be used to distribute to other yield farms.
        /// 
        /// Yield farm must be stopped before it can be terminated.
        /// 
        /// Only global farm's owner can perform this action. Yield farm stays in the storage until it's
        /// empty(all farm entries are withdrawn). Last withdrawn from yield farm trigger removing from
        /// the storage.
        /// 
        /// Parameters:
        /// - `origin`: global farm's owner.
        /// - `global_farm_id`: global farm id in which yield farm should be terminated.
        /// - `yield_farm_id`: id of yield farm to be terminated.
        /// - `asset_id`: id of the asset identifying yield farm.
        /// 
        /// Emits `YieldFarmTerminated` event when successful.
        /// 
        /// </summary>
        terminate_yield_farm = 7,
        
        /// <summary>
        /// >> deposit_shares
        /// Deposit omnipool position(LP shares) to a liquidity mining.
        /// 
        /// This function transfers omnipool position from `origin` to pallet's account and mint NFT for
        /// `origin` account. Minted NFT represents deposit in the liquidity mining. User can
        /// deposit omnipool position as a whole(all the LP shares in the position).
        /// 
        /// Parameters:
        /// - `origin`: owner of the omnipool position to deposit into the liquidity mining.
        /// - `global_farm_id`: id of global farm to which user wants to deposit LP shares.
        /// - `yield_farm_id`: id of yield farm to deposit to.
        /// - `position_id`: id of the omnipool position to be deposited into the liquidity mining.
        /// 
        /// Emits `SharesDeposited` event when successful.
        /// 
        /// </summary>
        deposit_shares = 8,
        
        /// <summary>
        /// >> redeposit_shares
        /// Redeposit LP shares in the already locked omnipool position.
        /// 
        /// This function create yield farm entry for existing deposit. Amount of redeposited LP
        /// shares is same as amount shares which are already deposited in the deposit.
        /// 
        /// This function DOESN'T create new deposit(NFT).
        /// 
        /// Parameters:
        /// - `origin`: owner of the deposit to redeposit.
        /// - `global_farm_id`: id of the global farm to which user wants to redeposit LP shares.
        /// - `yield_farm_id`: id of the yield farm to redeposit to.
        /// - `deposit_id`: identifier of the deposit to redeposit.
        /// 
        /// Emits `SharesRedeposited` event when successful.
        /// 
        /// </summary>
        redeposit_shares = 9,
        
        /// <summary>
        /// >> claim_rewards
        /// Note: This extrinsic is disabled
        /// 
        /// Claim rewards from liquidity mining program for deposit represented by the `deposit_id`.
        /// 
        /// This function calculate user rewards from liquidity mining and transfer rewards to `origin`
        /// account. Claiming multiple time the same period is not allowed.
        /// 
        /// Parameters:
        /// - `origin`: owner of deposit.
        /// - `deposit_id`: id of the deposit to claim rewards for.
        /// - `yield_farm_id`: id of the yield farm to claim rewards from.
        /// 
        /// Emits `RewardClaimed` event when successful.
        /// 
        /// </summary>
        claim_rewards = 10,
        
        /// <summary>
        /// >> withdraw_shares
        /// This function claim rewards and withdraw LP shares from yield farm. Omnipool position
        /// is transferred to origin only if this is last withdraw in the deposit and deposit is
        /// destroyed. This function claim rewards only if yield farm is not terminated and user
        /// didn't already claim rewards in current period.
        /// 
        /// Unclaimable rewards represents rewards which user won't be able to claim because of
        /// exiting early and these rewards will be transferred back to global farm for future
        /// redistribution.
        /// 
        /// Parameters:
        /// - `origin`: owner of deposit.
        /// - `deposit_id`: id of the deposit to claim rewards for.
        /// - `yield_farm_id`: id of the yield farm to claim rewards from.
        /// 
        /// Emits:
        /// * `RewardClaimed` event if claimed rewards is > 0
        /// * `SharesWithdrawn` event when successful
        /// * `DepositDestroyed` event when this was last withdraw from the deposit and deposit was
        /// destroyed.
        /// 
        /// </summary>
        withdraw_shares = 11,
        
        /// <summary>
        /// >> update_global_farm
        /// This extrinsic updates global farm's main parameters.
        /// 
        /// The dispatch origin for this call must be `T::CreateOrigin`.
        /// !!!WARN: `T::CreateOrigin` has power over funds of `owner`'s account and it should be
        /// configured to trusted origin e.g Sudo or Governance.
        /// 
        /// Parameters:
        /// - `origin`: account allowed to create new liquidity mining program(root, governance).
        /// - `global_farm_id`: id of the global farm to update.
        /// - `planned_yielding_periods`: planned number of periods to distribute `total_rewards`.
        /// - `yield_per_period`: percentage return on `reward_currency` of all farms.
        /// - `min_deposit`: minimum amount of LP shares to be deposited into the liquidity mining by each user.
        /// 
        /// Emits `GlobalFarmUpdated` event when successful.
        /// </summary>
        update_global_farm = 12,
        
        /// <summary>
        /// >> join_farms
        /// This function allows user to join multiple farms with a single omnipool position.
        /// 
        /// Parameters:
        /// - `origin`: owner of the omnipool position to deposit into the liquidity mining.
        /// - `farm_entries`: list of farms to join.
        /// - `position_id`: id of the omnipool position to be deposited into the liquidity mining.
        /// 
        /// Emits `SharesDeposited` event for the first farm entry
        /// Emits `SharesRedeposited` event for each farm entry after the first one
        /// </summary>
        join_farms = 13,
        
        /// <summary>
        /// >> add_liquidity_and_join_farms
        /// This function allows user to add liquidity then use that shares to join multiple farms.
        /// 
        /// Parameters:
        /// - `origin`: owner of the omnipool position to deposit into the liquidity mining.
        /// - `farm_entries`: list of farms to join.
        /// - `asset`: id of the asset to be deposited into the liquidity mining.
        /// - `amount`: amount of the asset to be deposited into the liquidity mining.
        /// 
        /// Emits `SharesDeposited` event for the first farm entry
        /// Emits `SharesRedeposited` event for each farm entry after the first one
        /// </summary>
        add_liquidity_and_join_farms = 14,
        
        /// <summary>
        /// >> exit_farms
        /// Exit from all specified yield farms
        /// 
        /// This function will attempt to withdraw shares and claim rewards (if available) from all
        /// specified yield farms for a given deposit.
        /// 
        /// Parameters:
        /// - `origin`: account owner of deposit(nft).
        /// - `deposit_id`: id of the deposit to claim rewards for.
        /// - `yield_farm_ids`: id(s) of yield farm(s) to exit from.
        /// 
        /// Emits:
        /// * `RewardClaimed` for each successful claim
        /// * `SharesWithdrawn` for each successful withdrawal
        /// * `DepositDestroyed` if the deposit is fully withdrawn
        /// 
        /// </summary>
        exit_farms = 15,
    }
    
    /// <summary>
    /// >> 366 - Variant[pallet_omnipool_liquidity_mining.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Perquintill, Substrate.NetApi.Model.Types.Primitive.U128, Hydration.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>>(Call.create_global_farm);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.terminate_global_farm);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128, Substrate.NetApi.Model.Types.Base.BaseOpt<Hydration.NetApi.Generated.Model.pallet_liquidity_mining.types.LoyaltyCurve>>>(Call.create_yield_farm);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>>(Call.update_yield_farm);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.stop_yield_farm);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>>(Call.resume_yield_farm);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.terminate_yield_farm);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.deposit_shares);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.redeposit_shares);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.claim_rewards);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.withdraw_shares);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Hydration.NetApi.Generated.Model.sp_arithmetic.per_things.Perquintill, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.update_global_farm);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT18, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.join_farms);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT18, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.add_liquidity_and_join_farms);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Hydration.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT19>>(Call.exit_farms);
        }
    }
}
