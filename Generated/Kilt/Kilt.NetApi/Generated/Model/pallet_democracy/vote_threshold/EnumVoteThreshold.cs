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


namespace Kilt.NetApi.Generated.Model.pallet_democracy.vote_threshold
{
    
    
    /// <summary>
    /// >> VoteThreshold
    /// </summary>
    public enum VoteThreshold
    {
        
        /// <summary>
        /// >> SuperMajorityApprove
        /// </summary>
        SuperMajorityApprove = 0,
        
        /// <summary>
        /// >> SuperMajorityAgainst
        /// </summary>
        SuperMajorityAgainst = 1,
        
        /// <summary>
        /// >> SimpleMajority
        /// </summary>
        SimpleMajority = 2,
    }
    
    /// <summary>
    /// >> 39 - Variant[pallet_democracy.vote_threshold.VoteThreshold]
    /// </summary>
    public sealed class EnumVoteThreshold : BaseEnum<VoteThreshold>
    {
    }
}
