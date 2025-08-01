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


namespace BifrostPolkadot.NetApi.Generated.Model.bifrost_salp.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Created
        /// Create a new crowdloaning campaign. [fund_index]
        /// </summary>
        Created = 0,
        
        /// <summary>
        /// >> Contributing
        /// Contributing to a crowd sale. [who, fund_index, amount]
        /// </summary>
        Contributing = 1,
        
        /// <summary>
        /// >> Contributed
        /// Contributed to a crowd sale. [who, fund_index, amount]
        /// </summary>
        Contributed = 2,
        
        /// <summary>
        /// >> ContributeFailed
        /// Fail on contribute to crowd sale. [who, fund_index, amount]
        /// </summary>
        ContributeFailed = 3,
        
        /// <summary>
        /// >> Withdrew
        /// Withdrew full balance of a contributor. [who, fund_index, amount]
        /// </summary>
        Withdrew = 4,
        
        /// <summary>
        /// >> Refunded
        /// refund to account. [who, fund_index,value]
        /// </summary>
        Refunded = 5,
        
        /// <summary>
        /// >> AllRefunded
        /// all refund
        /// </summary>
        AllRefunded = 6,
        
        /// <summary>
        /// >> Redeemed
        /// redeem to account. [who, fund_index, first_slot, last_slot, value]
        /// </summary>
        Redeemed = 7,
        
        /// <summary>
        /// >> Edited
        /// Fund is edited. [fund_index]
        /// </summary>
        Edited = 8,
        
        /// <summary>
        /// >> Dissolved
        /// Fund is dissolved. [fund_index]
        /// </summary>
        Dissolved = 9,
        
        /// <summary>
        /// >> Unlocked
        /// The vsToken/vsBond was be unlocked. [who, fund_index, value]
        /// </summary>
        Unlocked = 10,
        
        /// <summary>
        /// >> AllUnlocked
        /// </summary>
        AllUnlocked = 11,
        
        /// <summary>
        /// >> Failed
        /// Fund status change
        /// </summary>
        Failed = 12,
        
        /// <summary>
        /// >> Success
        /// </summary>
        Success = 13,
        
        /// <summary>
        /// >> Retired
        /// </summary>
        Retired = 14,
        
        /// <summary>
        /// >> End
        /// </summary>
        End = 15,
        
        /// <summary>
        /// >> Continued
        /// </summary>
        Continued = 16,
        
        /// <summary>
        /// >> RefundedDissolved
        /// </summary>
        RefundedDissolved = 17,
        
        /// <summary>
        /// >> Buyback
        /// </summary>
        Buyback = 18,
        
        /// <summary>
        /// >> VstokenUnlocked
        /// </summary>
        VstokenUnlocked = 19,
        
        /// <summary>
        /// >> BuybackByStablePool
        /// </summary>
        BuybackByStablePool = 20,
        
        /// <summary>
        /// >> Reserved
        /// </summary>
        Reserved = 21,
        
        /// <summary>
        /// >> ReservationCancelled
        /// </summary>
        ReservationCancelled = 22,
        
        /// <summary>
        /// >> ReservationFullyHandled
        /// </summary>
        ReservationFullyHandled = 23,
        
        /// <summary>
        /// >> ReservationHandled
        /// </summary>
        ReservationHandled = 24,
    }
    
    /// <summary>
    /// >> 574 - Variant[bifrost_salp.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Created);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, BifrostPolkadot.NetApi.Generated.Types.Base.Arr32U8>>(Event.Contributing);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Contributed);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.ContributeFailed);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Withdrew);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Refunded);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.AllRefunded);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Redeemed);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Edited);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Dissolved);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Unlocked);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.AllUnlocked);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Failed);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Success);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Retired);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.End);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.Continued);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.RefundedDissolved);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.Buyback);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.VstokenUnlocked);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.BuybackByStablePool);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.Bool>>(Event.Reserved);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.ReservationCancelled);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.ReservationFullyHandled);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.ReservationHandled);
        }
    }
}
