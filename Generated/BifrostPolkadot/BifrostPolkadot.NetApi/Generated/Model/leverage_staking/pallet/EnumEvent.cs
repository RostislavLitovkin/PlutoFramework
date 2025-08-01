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


namespace BifrostPolkadot.NetApi.Generated.Model.leverage_staking.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> FlashLoanDeposited
        /// User's leverage rate has been changed.
        /// </summary>
        FlashLoanDeposited = 0,
    }
    
    /// <summary>
    /// >> 615 - Variant[leverage_staking.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId, BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128, BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>>(Event.FlashLoanDeposited);
        }
    }
}
