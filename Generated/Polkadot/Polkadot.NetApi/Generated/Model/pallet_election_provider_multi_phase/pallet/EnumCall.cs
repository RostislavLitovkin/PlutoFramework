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


namespace Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> submit_unsigned
        /// Submit a solution for the unsigned phase.
        /// 
        /// The dispatch origin fo this call must be __none__.
        /// 
        /// This submission is checked on the fly. Moreover, this unsigned solution is only
        /// validated when submitted to the pool from the **local** node. Effectively, this means
        /// that only active validators can submit this transaction when authoring a block (similar
        /// to an inherent).
        /// 
        /// To prevent any incorrect solution (and thus wasted time/weight), this transaction will
        /// panic if the solution submitted by the validator is invalid in any way, effectively
        /// putting their authoring reward at risk.
        /// 
        /// No deposit or reward is associated with this submission.
        /// </summary>
        submit_unsigned = 0,
        
        /// <summary>
        /// >> set_minimum_untrusted_score
        /// Set a new value for `MinimumUntrustedScore`.
        /// 
        /// Dispatch origin must be aligned with `T::ForceOrigin`.
        /// 
        /// This check can be turned off by setting the value to `None`.
        /// </summary>
        set_minimum_untrusted_score = 1,
        
        /// <summary>
        /// >> set_emergency_election_result
        /// Set a solution in the queue, to be handed out to the client of this pallet in the next
        /// call to `ElectionProvider::elect`.
        /// 
        /// This can only be set by `T::ForceOrigin`, and only when the phase is `Emergency`.
        /// 
        /// The solution is not checked for any feasibility and is assumed to be trustworthy, as any
        /// feasibility check itself can in principle cause the election process to fail (due to
        /// memory/weight constrains).
        /// </summary>
        set_emergency_election_result = 2,
        
        /// <summary>
        /// >> submit
        /// Submit a solution for the signed phase.
        /// 
        /// The dispatch origin fo this call must be __signed__.
        /// 
        /// The solution is potentially queued, based on the claimed score and processed at the end
        /// of the signed phase.
        /// 
        /// A deposit is reserved and recorded for the solution. Based on the outcome, the solution
        /// might be rewarded, slashed, or get all or a part of the deposit back.
        /// </summary>
        submit = 3,
        
        /// <summary>
        /// >> governance_fallback
        /// Trigger the governance fallback.
        /// 
        /// This can only be called when [`Phase::Emergency`] is enabled, as an alternative to
        /// calling [`Call::set_emergency_election_result`].
        /// </summary>
        governance_fallback = 4,
    }
    
    /// <summary>
    /// >> 196 - Variant[pallet_election_provider_multi_phase.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase.RawSolution, Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase.SolutionOrSnapshotSize>>(Call.submit_unsigned);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Polkadot.NetApi.Generated.Model.sp_npos_elections.ElectionScore>>(Call.set_minimum_untrusted_score);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Polkadot.NetApi.Generated.Model.sp_npos_elections.Support>>>(Call.set_emergency_election_result);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase.RawSolution>(Call.submit);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>>(Call.governance_fallback);
        }
    }
}
