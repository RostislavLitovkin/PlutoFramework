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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_xcavate_staking.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Locked
        /// Balance was locked successfully.
        /// </summary>
        Locked = 0,
        
        /// <summary>
        /// >> Unlocked
        /// Balance was unlocked successfully.
        /// </summary>
        Unlocked = 1,
        
        /// <summary>
        /// >> RewardsClaimed
        /// Rewards were claimed successfully.
        /// </summary>
        RewardsClaimed = 2,
    }
    
    /// <summary>
    /// >> 164 - Variant[pallet_xcavate_staking.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Locked);
				AddTypeDecoder<BaseTuple<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Unlocked);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.RewardsClaimed);
        }
    }
}
