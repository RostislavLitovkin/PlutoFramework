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


namespace Polkadot.NetApi.Generated.Model.pallet_conviction_voting.vote
{
    
    
    /// <summary>
    /// >> AccountVote
    /// </summary>
    public enum AccountVote
    {
        
        /// <summary>
        /// >> Standard
        /// </summary>
        Standard = 0,
        
        /// <summary>
        /// >> Split
        /// </summary>
        Split = 1,
        
        /// <summary>
        /// >> SplitAbstain
        /// </summary>
        SplitAbstain = 2,
    }
    
    /// <summary>
    /// >> 154 - Variant[pallet_conviction_voting.vote.AccountVote]
    /// </summary>
    public sealed class EnumAccountVote : BaseEnumRust<AccountVote>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAccountVote()
        {
				AddTypeDecoder<BaseTuple<Polkadot.NetApi.Generated.Model.pallet_conviction_voting.vote.Vote, Substrate.NetApi.Model.Types.Primitive.U128>>(AccountVote.Standard);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(AccountVote.Split);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(AccountVote.SplitAbstain);
        }
    }
}
