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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_property_governance.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Proposed
        /// New proposal has been created.
        /// </summary>
        Proposed = 0,
        
        /// <summary>
        /// >> Inquery
        /// A new inquery has been made.
        /// </summary>
        Inquery = 1,
        
        /// <summary>
        /// >> VotedOnProposal
        /// Voted on proposal.
        /// </summary>
        VotedOnProposal = 2,
        
        /// <summary>
        /// >> VotedOnInquery
        /// Voted on inquery.
        /// </summary>
        VotedOnInquery = 3,
    }
    
    /// <summary>
    /// >> 162 - Variant[pallet_property_governance.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.Proposed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.Inquery);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, XCavatePaseo.NetApi.Generated.Model.pallet_property_governance.pallet.EnumVote>>(Event.VotedOnProposal);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, XCavatePaseo.NetApi.Generated.Model.pallet_property_governance.pallet.EnumVote>>(Event.VotedOnInquery);
        }
    }
}
