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


namespace Polkadot.NetApi.Generated.Model.pallet_nomination_pools.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// Events of this pallet.
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Created
        /// A pool has been created.
        /// </summary>
        Created = 0,
        
        /// <summary>
        /// >> Bonded
        /// A member has became bonded in a pool.
        /// </summary>
        Bonded = 1,
        
        /// <summary>
        /// >> PaidOut
        /// A payout has been made to a member.
        /// </summary>
        PaidOut = 2,
        
        /// <summary>
        /// >> Unbonded
        /// A member has unbonded from their pool.
        /// 
        /// - `balance` is the corresponding balance of the number of points that has been
        ///   requested to be unbonded (the argument of the `unbond` transaction) from the bonded
        ///   pool.
        /// - `points` is the number of points that are issued as a result of `balance` being
        /// dissolved into the corresponding unbonding pool.
        /// - `era` is the era in which the balance will be unbonded.
        /// In the absence of slashing, these values will match. In the presence of slashing, the
        /// number of points that are issued in the unbonding pool will be less than the amount
        /// requested to be unbonded.
        /// </summary>
        Unbonded = 3,
        
        /// <summary>
        /// >> Withdrawn
        /// A member has withdrawn from their pool.
        /// 
        /// The given number of `points` have been dissolved in return of `balance`.
        /// 
        /// Similar to `Unbonded` event, in the absence of slashing, the ratio of point to balance
        /// will be 1.
        /// </summary>
        Withdrawn = 4,
        
        /// <summary>
        /// >> Destroyed
        /// A pool has been destroyed.
        /// </summary>
        Destroyed = 5,
        
        /// <summary>
        /// >> StateChanged
        /// The state of a pool has changed
        /// </summary>
        StateChanged = 6,
        
        /// <summary>
        /// >> MemberRemoved
        /// A member has been removed from a pool.
        /// 
        /// The removal can be voluntary (withdrawn all unbonded funds) or involuntary (kicked).
        /// </summary>
        MemberRemoved = 7,
        
        /// <summary>
        /// >> RolesUpdated
        /// The roles of a pool have been updated to the given new roles. Note that the depositor
        /// can never change.
        /// </summary>
        RolesUpdated = 8,
        
        /// <summary>
        /// >> PoolSlashed
        /// The active balance of pool `pool_id` has been slashed to `balance`.
        /// </summary>
        PoolSlashed = 9,
        
        /// <summary>
        /// >> UnbondingPoolSlashed
        /// The unbond pool at `era` of pool `pool_id` has been slashed to `balance`.
        /// </summary>
        UnbondingPoolSlashed = 10,
        
        /// <summary>
        /// >> PoolCommissionUpdated
        /// A pool's commission setting has been changed.
        /// </summary>
        PoolCommissionUpdated = 11,
        
        /// <summary>
        /// >> PoolMaxCommissionUpdated
        /// A pool's maximum commission setting has been changed.
        /// </summary>
        PoolMaxCommissionUpdated = 12,
        
        /// <summary>
        /// >> PoolCommissionChangeRateUpdated
        /// A pool's commission `change_rate` has been changed.
        /// </summary>
        PoolCommissionChangeRateUpdated = 13,
        
        /// <summary>
        /// >> PoolCommissionClaimPermissionUpdated
        /// Pool commission claim permission has been updated.
        /// </summary>
        PoolCommissionClaimPermissionUpdated = 14,
        
        /// <summary>
        /// >> PoolCommissionClaimed
        /// Pool commission has been claimed.
        /// </summary>
        PoolCommissionClaimed = 15,
        
        /// <summary>
        /// >> MinBalanceDeficitAdjusted
        /// Topped up deficit in frozen ED of the reward pool.
        /// </summary>
        MinBalanceDeficitAdjusted = 16,
        
        /// <summary>
        /// >> MinBalanceExcessAdjusted
        /// Claimed excess frozen ED of af the reward pool.
        /// </summary>
        MinBalanceExcessAdjusted = 17,
    }
    
    /// <summary>
    /// >> 472 - Variant[pallet_nomination_pools.pallet.Event]
    /// Events of this pallet.
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.Created);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.Bool>>(Event.Bonded);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.PaidOut);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.Unbonded);
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Withdrawn);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Destroyed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkadot.NetApi.Generated.Model.pallet_nomination_pools.EnumPoolState>>(Event.StateChanged);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.MemberRemoved);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>>>(Event.RolesUpdated);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.PoolSlashed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.UnbondingPoolSlashed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Perbill, Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>>>>(Event.PoolCommissionUpdated);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkadot.NetApi.Generated.Model.sp_arithmetic.per_things.Perbill>>(Event.PoolMaxCommissionUpdated);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Polkadot.NetApi.Generated.Model.pallet_nomination_pools.CommissionChangeRate>>(Event.PoolCommissionChangeRateUpdated);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.pallet_nomination_pools.EnumCommissionClaimPermission>>>(Event.PoolCommissionClaimPermissionUpdated);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.PoolCommissionClaimed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.MinBalanceDeficitAdjusted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.MinBalanceExcessAdjusted);
        }
    }
}
