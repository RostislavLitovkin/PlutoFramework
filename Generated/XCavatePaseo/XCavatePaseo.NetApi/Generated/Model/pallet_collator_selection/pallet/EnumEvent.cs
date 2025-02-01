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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_collator_selection.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> NewInvulnerables
        /// New Invulnerables were set.
        /// </summary>
        NewInvulnerables = 0,
        
        /// <summary>
        /// >> InvulnerableAdded
        /// A new Invulnerable was added.
        /// </summary>
        InvulnerableAdded = 1,
        
        /// <summary>
        /// >> InvulnerableRemoved
        /// An Invulnerable was removed.
        /// </summary>
        InvulnerableRemoved = 2,
        
        /// <summary>
        /// >> NewDesiredCandidates
        /// The number of desired candidates was set.
        /// </summary>
        NewDesiredCandidates = 3,
        
        /// <summary>
        /// >> NewCandidacyBond
        /// The candidacy bond was set.
        /// </summary>
        NewCandidacyBond = 4,
        
        /// <summary>
        /// >> CandidateAdded
        /// A new candidate joined.
        /// </summary>
        CandidateAdded = 5,
        
        /// <summary>
        /// >> CandidateBondUpdated
        /// Bond of a candidate updated.
        /// </summary>
        CandidateBondUpdated = 6,
        
        /// <summary>
        /// >> CandidateRemoved
        /// A candidate was removed.
        /// </summary>
        CandidateRemoved = 7,
        
        /// <summary>
        /// >> CandidateReplaced
        /// An account was replaced in the candidate list by another one.
        /// </summary>
        CandidateReplaced = 8,
        
        /// <summary>
        /// >> InvalidInvulnerableSkipped
        /// An account was unable to be added to the Invulnerables because they did not have keys
        /// registered. Other Invulnerables may have been set.
        /// </summary>
        InvalidInvulnerableSkipped = 9,
    }
    
    /// <summary>
    /// >> 286 - Variant[pallet_collator_selection.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.NewInvulnerables);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.InvulnerableAdded);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.InvulnerableRemoved);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.NewDesiredCandidates);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.NewCandidacyBond);
				AddTypeDecoder<BaseTuple<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.CandidateAdded);
				AddTypeDecoder<BaseTuple<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.CandidateBondUpdated);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.CandidateRemoved);
				AddTypeDecoder<BaseTuple<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.CandidateReplaced);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.InvalidInvulnerableSkipped);
        }
    }
}
