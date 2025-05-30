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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_community_projects.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> ProjectListed
        /// A new object has been listed on the marketplace.
        /// </summary>
        ProjectListed = 0,
        
        /// <summary>
        /// >> NftBought
        /// A nft has been bought.
        /// </summary>
        NftBought = 1,
        
        /// <summary>
        /// >> VotedOnMilestone
        /// Voted on a milestone.
        /// </summary>
        VotedOnMilestone = 2,
        
        /// <summary>
        /// >> ProjectLaunched
        /// A project has been sold out.
        /// </summary>
        ProjectLaunched = 3,
        
        /// <summary>
        /// >> VotingPeriodStarted
        /// A Voting period has started.
        /// </summary>
        VotingPeriodStarted = 4,
        
        /// <summary>
        /// >> FundsDestributed
        /// Funds has been sent to the project.
        /// </summary>
        FundsDestributed = 5,
        
        /// <summary>
        /// >> MilestonePeriodStarted
        /// A Milestone period has started.
        /// </summary>
        MilestonePeriodStarted = 6,
        
        /// <summary>
        /// >> ProjectDeleted
        /// The project has been deleted.
        /// </summary>
        ProjectDeleted = 7,
        
        /// <summary>
        /// >> TokenBonded
        /// Token got bonded to the project.
        /// </summary>
        TokenBonded = 8,
        
        /// <summary>
        /// >> TokenRefunded
        /// </summary>
        TokenRefunded = 9,
        
        /// <summary>
        /// >> TokenUnbonded
        /// </summary>
        TokenUnbonded = 10,
    }
    
    /// <summary>
    /// >> 167 - Variant[pallet_community_projects.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.ProjectListed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.NftBought);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, XcavatePaseo.NetApi.Generated.Model.pallet_community_projects.pallet.EnumVote>>(Event.VotedOnMilestone);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.ProjectLaunched);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.VotingPeriodStarted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.FundsDestributed);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.MilestonePeriodStarted);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.ProjectDeleted);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.TokenBonded);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.TokenRefunded);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.TokenUnbonded);
        }
    }
}
