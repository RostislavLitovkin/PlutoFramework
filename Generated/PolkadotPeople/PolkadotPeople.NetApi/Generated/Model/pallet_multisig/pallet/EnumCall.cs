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


namespace PolkadotPeople.NetApi.Generated.Model.pallet_multisig.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> as_multi_threshold_1
        /// Immediately dispatch a multi-signature call using a single approval from the caller.
        /// 
        /// The dispatch origin for this call must be _Signed_.
        /// 
        /// - `other_signatories`: The accounts (other than the sender) who are part of the
        /// multi-signature, but do not participate in the approval process.
        /// - `call`: The call to be executed.
        /// 
        /// Result is equivalent to the dispatched result.
        /// 
        /// ## Complexity
        /// O(Z + C) where Z is the length of the call and C its execution weight.
        /// </summary>
        as_multi_threshold_1 = 0,
        
        /// <summary>
        /// >> as_multi
        /// Register approval for a dispatch to be made from a deterministic composite account if
        /// approved by a total of `threshold - 1` of `other_signatories`.
        /// 
        /// If there are enough, then dispatch the call.
        /// 
        /// Payment: `DepositBase` will be reserved if this is the first approval, plus
        /// `threshold` times `DepositFactor`. It is returned once this dispatch happens or
        /// is cancelled.
        /// 
        /// The dispatch origin for this call must be _Signed_.
        /// 
        /// - `threshold`: The total number of approvals for this dispatch before it is executed.
        /// - `other_signatories`: The accounts (other than the sender) who can approve this
        /// dispatch. May not be empty.
        /// - `maybe_timepoint`: If this is the first approval, then this must be `None`. If it is
        /// not the first approval, then it must be `Some`, with the timepoint (block number and
        /// transaction index) of the first approval transaction.
        /// - `call`: The call to be executed.
        /// 
        /// NOTE: Unless this is the final approval, you will generally want to use
        /// `approve_as_multi` instead, since it only requires a hash of the call.
        /// 
        /// Result is equivalent to the dispatched result if `threshold` is exactly `1`. Otherwise
        /// on success, result is `Ok` and the result from the interior call, if it was executed,
        /// may be found in the deposited `MultisigExecuted` event.
        /// 
        /// ## Complexity
        /// - `O(S + Z + Call)`.
        /// - Up to one balance-reserve or unreserve operation.
        /// - One passthrough operation, one insert, both `O(S)` where `S` is the number of
        ///   signatories. `S` is capped by `MaxSignatories`, with weight being proportional.
        /// - One call encode & hash, both of complexity `O(Z)` where `Z` is tx-len.
        /// - One encode & hash, both of complexity `O(S)`.
        /// - Up to one binary search and insert (`O(logS + S)`).
        /// - I/O: 1 read `O(S)`, up to 1 mutate `O(S)`. Up to one remove.
        /// - One event.
        /// - The weight of the `call`.
        /// - Storage: inserts one item, value size bounded by `MaxSignatories`, with a deposit
        ///   taken for its lifetime of `DepositBase + threshold * DepositFactor`.
        /// </summary>
        as_multi = 1,
        
        /// <summary>
        /// >> approve_as_multi
        /// Register approval for a dispatch to be made from a deterministic composite account if
        /// approved by a total of `threshold - 1` of `other_signatories`.
        /// 
        /// Payment: `DepositBase` will be reserved if this is the first approval, plus
        /// `threshold` times `DepositFactor`. It is returned once this dispatch happens or
        /// is cancelled.
        /// 
        /// The dispatch origin for this call must be _Signed_.
        /// 
        /// - `threshold`: The total number of approvals for this dispatch before it is executed.
        /// - `other_signatories`: The accounts (other than the sender) who can approve this
        /// dispatch. May not be empty.
        /// - `maybe_timepoint`: If this is the first approval, then this must be `None`. If it is
        /// not the first approval, then it must be `Some`, with the timepoint (block number and
        /// transaction index) of the first approval transaction.
        /// - `call_hash`: The hash of the call to be executed.
        /// 
        /// NOTE: If this is the final approval, you will want to use `as_multi` instead.
        /// 
        /// ## Complexity
        /// - `O(S)`.
        /// - Up to one balance-reserve or unreserve operation.
        /// - One passthrough operation, one insert, both `O(S)` where `S` is the number of
        ///   signatories. `S` is capped by `MaxSignatories`, with weight being proportional.
        /// - One encode & hash, both of complexity `O(S)`.
        /// - Up to one binary search and insert (`O(logS + S)`).
        /// - I/O: 1 read `O(S)`, up to 1 mutate `O(S)`. Up to one remove.
        /// - One event.
        /// - Storage: inserts one item, value size bounded by `MaxSignatories`, with a deposit
        ///   taken for its lifetime of `DepositBase + threshold * DepositFactor`.
        /// </summary>
        approve_as_multi = 2,
        
        /// <summary>
        /// >> cancel_as_multi
        /// Cancel a pre-existing, on-going multisig transaction. Any deposit reserved previously
        /// for this operation will be unreserved on success.
        /// 
        /// The dispatch origin for this call must be _Signed_.
        /// 
        /// - `threshold`: The total number of approvals for this dispatch before it is executed.
        /// - `other_signatories`: The accounts (other than the sender) who can approve this
        /// dispatch. May not be empty.
        /// - `timepoint`: The timepoint (block number and transaction index) of the first approval
        /// transaction for this dispatch.
        /// - `call_hash`: The hash of the call to be executed.
        /// 
        /// ## Complexity
        /// - `O(S)`.
        /// - Up to one balance-reserve or unreserve operation.
        /// - One passthrough operation, one insert, both `O(S)` where `S` is the number of
        ///   signatories. `S` is capped by `MaxSignatories`, with weight being proportional.
        /// - One encode & hash, both of complexity `O(S)`.
        /// - One event.
        /// - I/O: 1 read `O(S)`, one remove.
        /// - Storage: removes one item.
        /// </summary>
        cancel_as_multi = 3,
    }
    
    /// <summary>
    /// >> 321 - Variant[pallet_multisig.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32>, PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime.EnumRuntimeCall>>(Call.as_multi_threshold_1);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseOpt<PolkadotPeople.NetApi.Generated.Model.pallet_multisig.Timepoint>, PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime.EnumRuntimeCall, PolkadotPeople.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Call.as_multi);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32>, Substrate.NetApi.Model.Types.Base.BaseOpt<PolkadotPeople.NetApi.Generated.Model.pallet_multisig.Timepoint>, PolkadotPeople.NetApi.Generated.Types.Base.Arr32U8, PolkadotPeople.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Call.approve_as_multi);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U16, Substrate.NetApi.Model.Types.Base.BaseVec<PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32>, PolkadotPeople.NetApi.Generated.Model.pallet_multisig.Timepoint, PolkadotPeople.NetApi.Generated.Types.Base.Arr32U8>>(Call.cancel_as_multi);
        }
    }
}
