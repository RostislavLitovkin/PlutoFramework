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


namespace InvArch.NetApi.Generated.Model.pallet_treasury.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Proposed
        /// New proposal.
        /// </summary>
        Proposed = 0,
        
        /// <summary>
        /// >> Spending
        /// We have ended a spend period and will now allocate funds.
        /// </summary>
        Spending = 1,
        
        /// <summary>
        /// >> Awarded
        /// Some funds have been allocated.
        /// </summary>
        Awarded = 2,
        
        /// <summary>
        /// >> Rejected
        /// A proposal was rejected; funds were slashed.
        /// </summary>
        Rejected = 3,
        
        /// <summary>
        /// >> Burnt
        /// Some of our funds have been burnt.
        /// </summary>
        Burnt = 4,
        
        /// <summary>
        /// >> Rollover
        /// Spending has finished; this is the amount that rolls over until next spend.
        /// </summary>
        Rollover = 5,
        
        /// <summary>
        /// >> Deposit
        /// Some funds have been deposited.
        /// </summary>
        Deposit = 6,
        
        /// <summary>
        /// >> SpendApproved
        /// A new spend proposal has been approved.
        /// </summary>
        SpendApproved = 7,
        
        /// <summary>
        /// >> UpdatedInactive
        /// The inactive funds of the pallet have been updated.
        /// </summary>
        UpdatedInactive = 8,
    }
    
    /// <summary>
    /// >> 43 - Variant[pallet_treasury.pallet.Event]
    /// 
    ///			The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted
    ///			by this pallet.
    ///			
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.Proposed);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.Spending);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.Awarded);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.Rejected);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.Burnt);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.Rollover);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U128>(Event.Deposit);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.SpendApproved);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Primitive.U128, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.UpdatedInactive);
        }
    }
}