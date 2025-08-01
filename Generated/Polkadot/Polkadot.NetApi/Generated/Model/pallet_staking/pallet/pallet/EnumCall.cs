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


namespace Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> bond
        /// Take the origin account as a stash and lock up `value` of its balance. `controller` will
        /// be the account that controls it.
        /// 
        /// `value` must be more than the `minimum_balance` specified by `T::Currency`.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the stash account.
        /// 
        /// Emits `Bonded`.
        /// ## Complexity
        /// - Independent of the arguments. Moderate complexity.
        /// - O(1).
        /// - Three extra DB entries.
        /// 
        /// NOTE: Two of the storage writes (`Self::bonded`, `Self::payee`) are _never_ cleaned
        /// unless the `origin` falls below _existential deposit_ (or equal to 0) and gets removed
        /// as dust.
        /// </summary>
        bond = 0,
        
        /// <summary>
        /// >> bond_extra
        /// Add some extra amount that have appeared in the stash `free_balance` into the balance up
        /// for staking.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the stash, not the controller.
        /// 
        /// Use this if there are additional funds in your stash account that you wish to bond.
        /// Unlike [`bond`](Self::bond) or [`unbond`](Self::unbond) this function does not impose
        /// any limitation on the amount that can be added.
        /// 
        /// Emits `Bonded`.
        /// 
        /// ## Complexity
        /// - Independent of the arguments. Insignificant complexity.
        /// - O(1).
        /// </summary>
        bond_extra = 1,
        
        /// <summary>
        /// >> unbond
        /// Schedule a portion of the stash to be unlocked ready for transfer out after the bond
        /// period ends. If this leaves an amount actively bonded less than
        /// [`asset::existential_deposit`], then it is increased to the full amount.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the controller, not the stash.
        /// 
        /// Once the unlock period is done, you can call `withdraw_unbonded` to actually move
        /// the funds out of management ready for transfer.
        /// 
        /// No more than a limited number of unlocking chunks (see `MaxUnlockingChunks`)
        /// can co-exists at the same time. If there are no unlocking chunks slots available
        /// [`Call::withdraw_unbonded`] is called to remove some of the chunks (if possible).
        /// 
        /// If a user encounters the `InsufficientBond` error when calling this extrinsic,
        /// they should call `chill` first in order to free up their bonded funds.
        /// 
        /// Emits `Unbonded`.
        /// 
        /// See also [`Call::withdraw_unbonded`].
        /// </summary>
        unbond = 2,
        
        /// <summary>
        /// >> withdraw_unbonded
        /// Remove any unlocked chunks from the `unlocking` queue from our management.
        /// 
        /// This essentially frees up that balance to be used by the stash account to do whatever
        /// it wants.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the controller.
        /// 
        /// Emits `Withdrawn`.
        /// 
        /// See also [`Call::unbond`].
        /// 
        /// ## Parameters
        /// 
        /// - `num_slashing_spans` indicates the number of metadata slashing spans to clear when
        /// this call results in a complete removal of all the data related to the stash account.
        /// In this case, the `num_slashing_spans` must be larger or equal to the number of
        /// slashing spans associated with the stash account in the [`SlashingSpans`] storage type,
        /// otherwise the call will fail. The call weight is directly proportional to
        /// `num_slashing_spans`.
        /// 
        /// ## Complexity
        /// O(S) where S is the number of slashing spans to remove
        /// NOTE: Weight annotation is the kill scenario, we refund otherwise.
        /// </summary>
        withdraw_unbonded = 3,
        
        /// <summary>
        /// >> validate
        /// Declare the desire to validate for the origin controller.
        /// 
        /// Effects will be felt at the beginning of the next era.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the controller, not the stash.
        /// </summary>
        validate = 4,
        
        /// <summary>
        /// >> nominate
        /// Declare the desire to nominate `targets` for the origin controller.
        /// 
        /// Effects will be felt at the beginning of the next era.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the controller, not the stash.
        /// 
        /// ## Complexity
        /// - The transaction's complexity is proportional to the size of `targets` (N)
        /// which is capped at CompactAssignments::LIMIT (T::MaxNominations).
        /// - Both the reads and writes follow a similar pattern.
        /// </summary>
        nominate = 5,
        
        /// <summary>
        /// >> chill
        /// Declare no desire to either validate or nominate.
        /// 
        /// Effects will be felt at the beginning of the next era.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the controller, not the stash.
        /// 
        /// ## Complexity
        /// - Independent of the arguments. Insignificant complexity.
        /// - Contains one read.
        /// - Writes are limited to the `origin` account key.
        /// </summary>
        chill = 6,
        
        /// <summary>
        /// >> set_payee
        /// (Re-)set the payment target for a controller.
        /// 
        /// Effects will be felt instantly (as soon as this function is completed successfully).
        /// 
        /// The dispatch origin for this call must be _Signed_ by the controller, not the stash.
        /// 
        /// ## Complexity
        /// - O(1)
        /// - Independent of the arguments. Insignificant complexity.
        /// - Contains a limited number of reads.
        /// - Writes are limited to the `origin` account key.
        /// ---------
        /// </summary>
        set_payee = 7,
        
        /// <summary>
        /// >> set_controller
        /// (Re-)sets the controller of a stash to the stash itself. This function previously
        /// accepted a `controller` argument to set the controller to an account other than the
        /// stash itself. This functionality has now been removed, now only setting the controller
        /// to the stash, if it is not already.
        /// 
        /// Effects will be felt instantly (as soon as this function is completed successfully).
        /// 
        /// The dispatch origin for this call must be _Signed_ by the stash, not the controller.
        /// 
        /// ## Complexity
        /// O(1)
        /// - Independent of the arguments. Insignificant complexity.
        /// - Contains a limited number of reads.
        /// - Writes are limited to the `origin` account key.
        /// </summary>
        set_controller = 8,
        
        /// <summary>
        /// >> set_validator_count
        /// Sets the ideal number of validators.
        /// 
        /// The dispatch origin must be Root.
        /// 
        /// ## Complexity
        /// O(1)
        /// </summary>
        set_validator_count = 9,
        
        /// <summary>
        /// >> increase_validator_count
        /// Increments the ideal number of validators up to maximum of
        /// `ElectionProviderBase::MaxWinners`.
        /// 
        /// The dispatch origin must be Root.
        /// 
        /// ## Complexity
        /// Same as [`Self::set_validator_count`].
        /// </summary>
        increase_validator_count = 10,
        
        /// <summary>
        /// >> scale_validator_count
        /// Scale up the ideal number of validators by a factor up to maximum of
        /// `ElectionProviderBase::MaxWinners`.
        /// 
        /// The dispatch origin must be Root.
        /// 
        /// ## Complexity
        /// Same as [`Self::set_validator_count`].
        /// </summary>
        scale_validator_count = 11,
        
        /// <summary>
        /// >> force_no_eras
        /// Force there to be no new eras indefinitely.
        /// 
        /// The dispatch origin must be Root.
        /// 
        /// # Warning
        /// 
        /// The election process starts multiple blocks before the end of the era.
        /// Thus the election process may be ongoing when this is called. In this case the
        /// election will continue until the next era is triggered.
        /// 
        /// ## Complexity
        /// - No arguments.
        /// - Weight: O(1)
        /// </summary>
        force_no_eras = 12,
        
        /// <summary>
        /// >> force_new_era
        /// Force there to be a new era at the end of the next session. After this, it will be
        /// reset to normal (non-forced) behaviour.
        /// 
        /// The dispatch origin must be Root.
        /// 
        /// # Warning
        /// 
        /// The election process starts multiple blocks before the end of the era.
        /// If this is called just before a new era is triggered, the election process may not
        /// have enough blocks to get a result.
        /// 
        /// ## Complexity
        /// - No arguments.
        /// - Weight: O(1)
        /// </summary>
        force_new_era = 13,
        
        /// <summary>
        /// >> set_invulnerables
        /// Set the validators who cannot be slashed (if any).
        /// 
        /// The dispatch origin must be Root.
        /// </summary>
        set_invulnerables = 14,
        
        /// <summary>
        /// >> force_unstake
        /// Force a current staker to become completely unstaked, immediately.
        /// 
        /// The dispatch origin must be Root.
        /// 
        /// ## Parameters
        /// 
        /// - `num_slashing_spans`: Refer to comments on [`Call::withdraw_unbonded`] for more
        /// details.
        /// </summary>
        force_unstake = 15,
        
        /// <summary>
        /// >> force_new_era_always
        /// Force there to be a new era at the end of sessions indefinitely.
        /// 
        /// The dispatch origin must be Root.
        /// 
        /// # Warning
        /// 
        /// The election process starts multiple blocks before the end of the era.
        /// If this is called just before a new era is triggered, the election process may not
        /// have enough blocks to get a result.
        /// </summary>
        force_new_era_always = 16,
        
        /// <summary>
        /// >> cancel_deferred_slash
        /// Cancel enactment of a deferred slash.
        /// 
        /// Can be called by the `T::AdminOrigin`.
        /// 
        /// Parameters: era and indices of the slashes for that era to kill.
        /// </summary>
        cancel_deferred_slash = 17,
        
        /// <summary>
        /// >> payout_stakers
        /// Pay out next page of the stakers behind a validator for the given era.
        /// 
        /// - `validator_stash` is the stash account of the validator.
        /// - `era` may be any era between `[current_era - history_depth; current_era]`.
        /// 
        /// The origin of this call must be _Signed_. Any account can call this function, even if
        /// it is not one of the stakers.
        /// 
        /// The reward payout could be paged in case there are too many nominators backing the
        /// `validator_stash`. This call will payout unpaid pages in an ascending order. To claim a
        /// specific page, use `payout_stakers_by_page`.`
        /// 
        /// If all pages are claimed, it returns an error `InvalidPage`.
        /// </summary>
        payout_stakers = 18,
        
        /// <summary>
        /// >> rebond
        /// Rebond a portion of the stash scheduled to be unlocked.
        /// 
        /// The dispatch origin must be signed by the controller.
        /// 
        /// ## Complexity
        /// - Time complexity: O(L), where L is unlocking chunks
        /// - Bounded by `MaxUnlockingChunks`.
        /// </summary>
        rebond = 19,
        
        /// <summary>
        /// >> reap_stash
        /// Remove all data structures concerning a staker/stash once it is at a state where it can
        /// be considered `dust` in the staking system. The requirements are:
        /// 
        /// 1. the `total_balance` of the stash is below existential deposit.
        /// 2. or, the `ledger.total` of the stash is below existential deposit.
        /// 3. or, existential deposit is zero and either `total_balance` or `ledger.total` is zero.
        /// 
        /// The former can happen in cases like a slash; the latter when a fully unbonded account
        /// is still receiving staking rewards in `RewardDestination::Staked`.
        /// 
        /// It can be called by anyone, as long as `stash` meets the above requirements.
        /// 
        /// Refunds the transaction fees upon successful execution.
        /// 
        /// ## Parameters
        /// 
        /// - `num_slashing_spans`: Refer to comments on [`Call::withdraw_unbonded`] for more
        /// details.
        /// </summary>
        reap_stash = 20,
        
        /// <summary>
        /// >> kick
        /// Remove the given nominations from the calling validator.
        /// 
        /// Effects will be felt at the beginning of the next era.
        /// 
        /// The dispatch origin for this call must be _Signed_ by the controller, not the stash.
        /// 
        /// - `who`: A list of nominator stash accounts who are nominating this validator which
        ///   should no longer be nominating this validator.
        /// 
        /// Note: Making this call only makes sense if you first set the validator preferences to
        /// block any further nominations.
        /// </summary>
        kick = 21,
        
        /// <summary>
        /// >> set_staking_configs
        /// Update the various staking configurations .
        /// 
        /// * `min_nominator_bond`: The minimum active bond needed to be a nominator.
        /// * `min_validator_bond`: The minimum active bond needed to be a validator.
        /// * `max_nominator_count`: The max number of users who can be a nominator at once. When
        ///   set to `None`, no limit is enforced.
        /// * `max_validator_count`: The max number of users who can be a validator at once. When
        ///   set to `None`, no limit is enforced.
        /// * `chill_threshold`: The ratio of `max_nominator_count` or `max_validator_count` which
        ///   should be filled in order for the `chill_other` transaction to work.
        /// * `min_commission`: The minimum amount of commission that each validators must maintain.
        ///   This is checked only upon calling `validate`. Existing validators are not affected.
        /// 
        /// RuntimeOrigin must be Root to call this function.
        /// 
        /// NOTE: Existing nominators and validators will not be affected by this update.
        /// to kick people under the new limits, `chill_other` should be called.
        /// </summary>
        set_staking_configs = 22,
        
        /// <summary>
        /// >> chill_other
        /// Declare a `controller` to stop participating as either a validator or nominator.
        /// 
        /// Effects will be felt at the beginning of the next era.
        /// 
        /// The dispatch origin for this call must be _Signed_, but can be called by anyone.
        /// 
        /// If the caller is the same as the controller being targeted, then no further checks are
        /// enforced, and this function behaves just like `chill`.
        /// 
        /// If the caller is different than the controller being targeted, the following conditions
        /// must be met:
        /// 
        /// * `controller` must belong to a nominator who has become non-decodable,
        /// 
        /// Or:
        /// 
        /// * A `ChillThreshold` must be set and checked which defines how close to the max
        ///   nominators or validators we must reach before users can start chilling one-another.
        /// * A `MaxNominatorCount` and `MaxValidatorCount` must be set which is used to determine
        ///   how close we are to the threshold.
        /// * A `MinNominatorBond` and `MinValidatorBond` must be set and checked, which determines
        ///   if this is a person that should be chilled because they have not met the threshold
        ///   bond required.
        /// 
        /// This can be helpful if bond requirements are updated, and we need to remove old users
        /// who do not satisfy these requirements.
        /// </summary>
        chill_other = 23,
        
        /// <summary>
        /// >> force_apply_min_commission
        /// Force a validator to have at least the minimum commission. This will not affect a
        /// validator who already has a commission greater than or equal to the minimum. Any account
        /// can call this.
        /// </summary>
        force_apply_min_commission = 24,
        
        /// <summary>
        /// >> set_min_commission
        /// Sets the minimum amount of commission that each validators must maintain.
        /// 
        /// This call has lower privilege requirements than `set_staking_config` and can be called
        /// by the `T::AdminOrigin`. Root can always call this.
        /// </summary>
        set_min_commission = 25,
        
        /// <summary>
        /// >> payout_stakers_by_page
        /// Pay out a page of the stakers behind a validator for the given era and page.
        /// 
        /// - `validator_stash` is the stash account of the validator.
        /// - `era` may be any era between `[current_era - history_depth; current_era]`.
        /// - `page` is the page index of nominators to pay out with value between 0 and
        ///   `num_nominators / T::MaxExposurePageSize`.
        /// 
        /// The origin of this call must be _Signed_. Any account can call this function, even if
        /// it is not one of the stakers.
        /// 
        /// If a validator has more than [`Config::MaxExposurePageSize`] nominators backing
        /// them, then the list of nominators is paged, with each page being capped at
        /// [`Config::MaxExposurePageSize`.] If a validator has more than one page of nominators,
        /// the call needs to be made for each page separately in order for all the nominators
        /// backing a validator to receive the reward. The nominators are not sorted across pages
        /// and so it should not be assumed the highest staker would be on the topmost page and vice
        /// versa. If rewards are not claimed in [`Config::HistoryDepth`] eras, they are lost.
        /// </summary>
        payout_stakers_by_page = 26,
        
        /// <summary>
        /// >> update_payee
        /// Migrates an account's `RewardDestination::Controller` to
        /// `RewardDestination::Account(controller)`.
        /// 
        /// Effects will be felt instantly (as soon as this function is completed successfully).
        /// 
        /// This will waive the transaction fee if the `payee` is successfully migrated.
        /// </summary>
        update_payee = 27,
        
        /// <summary>
        /// >> deprecate_controller_batch
        /// Updates a batch of controller accounts to their corresponding stash account if they are
        /// not the same. Ignores any controller accounts that do not exist, and does not operate if
        /// the stash and controller are already the same.
        /// 
        /// Effects will be felt instantly (as soon as this function is completed successfully).
        /// 
        /// The dispatch origin must be `T::AdminOrigin`.
        /// </summary>
        deprecate_controller_batch = 28,
        
        /// <summary>
        /// >> restore_ledger
        /// Restores the state of a ledger which is in an inconsistent state.
        /// 
        /// The requirements to restore a ledger are the following:
        /// * The stash is bonded; or
        /// * The stash is not bonded but it has a staking lock left behind; or
        /// * If the stash has an associated ledger and its state is inconsistent; or
        /// * If the ledger is not corrupted *but* its staking lock is out of sync.
        /// 
        /// The `maybe_*` input parameters will overwrite the corresponding data and metadata of the
        /// ledger associated with the stash. If the input parameters are not set, the ledger will
        /// be reset values from on-chain state.
        /// </summary>
        restore_ledger = 29,
        
        /// <summary>
        /// >> migrate_currency
        /// Removes the legacy Staking locks if they exist.
        /// 
        /// This removes the legacy lock on the stake with [`Config::OldCurrency`] and creates a
        /// hold on it if needed. If all stake cannot be held, the best effort is made to hold as
        /// much as possible. The remaining stake is forced withdrawn from the ledger.
        /// 
        /// The fee is waived if the migration is successful.
        /// </summary>
        migrate_currency = 30,
        
        /// <summary>
        /// >> manual_slash
        /// This function allows governance to manually slash a validator and is a
        /// **fallback mechanism**.
        /// 
        /// The dispatch origin must be `T::AdminOrigin`.
        /// 
        /// ## Parameters
        /// - `validator_stash` - The stash account of the validator to slash.
        /// - `era` - The era in which the validator was in the active set.
        /// - `slash_fraction` - The percentage of the stake to slash, expressed as a Perbill.
        /// 
        /// ## Behavior
        /// 
        /// The slash will be applied using the standard slashing mechanics, respecting the
        /// configured `SlashDeferDuration`.
        /// 
        /// This means:
        /// - If the validator was already slashed by a higher percentage for the same era, this
        ///   slash will have no additional effect.
        /// - If the validator was previously slashed by a lower percentage, only the difference
        ///   will be applied.
        /// - The slash will be deferred by `SlashDeferDuration` eras before being enacted.
        /// </summary>
        manual_slash = 33,
    }
    
    /// <summary>
    /// >> 129 - Variant[pallet_staking.pallet.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Polkadot.NetApi.Generated.Model.pallet_staking.EnumRewardDestination>>(Call.bond);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>(Call.bond_extra);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>(Call.unbond);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.withdraw_unbonded);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.pallet_staking.ValidatorPrefs>(Call.validate);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.nominate);
				AddTypeDecoder<BaseVoid>(Call.chill);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.pallet_staking.EnumRewardDestination>(Call.set_payee);
				AddTypeDecoder<BaseVoid>(Call.set_controller);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(Call.set_validator_count);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(Call.increase_validator_count);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Percent>(Call.scale_validator_count);
				AddTypeDecoder<BaseVoid>(Call.force_no_eras);
				AddTypeDecoder<BaseVoid>(Call.force_new_era);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Call.set_invulnerables);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.force_unstake);
				AddTypeDecoder<BaseVoid>(Call.force_new_era_always);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>>>(Call.cancel_deferred_slash);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.payout_stakers);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>(Call.rebond);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.reap_stash);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.kick);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet.EnumConfigOp, Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet.EnumConfigOp, Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet.EnumConfigOp, Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet.EnumConfigOp, Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet.EnumConfigOp, Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet.EnumConfigOp, Polkadot.NetApi.Generated.Model.pallet_staking.pallet.pallet.EnumConfigOp>>(Call.set_staking_configs);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.chill_other);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.force_apply_min_commission);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Perbill>(Call.set_min_commission);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.payout_stakers_by_page);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.update_payee);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT1>(Call.deprecate_controller_batch);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT2>>>(Call.restore_ledger);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.migrate_currency);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Polkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Perbill>>(Call.manual_slash);
        }
    }
}
