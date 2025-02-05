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


namespace Kilt.NetApi.Generated.Model.pallet_web3_names.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Web3NameClaimed
        /// A new name has been claimed.
        /// </summary>
        Web3NameClaimed = 0,
        
        /// <summary>
        /// >> Web3NameReleased
        /// A name has been released.
        /// </summary>
        Web3NameReleased = 1,
        
        /// <summary>
        /// >> Web3NameBanned
        /// A name has been banned.
        /// </summary>
        Web3NameBanned = 2,
        
        /// <summary>
        /// >> Web3NameUnbanned
        /// A name has been unbanned.
        /// </summary>
        Web3NameUnbanned = 3,
    }
    
    /// <summary>
    /// >> 121 - Variant[pallet_web3_names.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32, Kilt.NetApi.Generated.Model.pallet_web3_names.web3_name.AsciiWeb3Name>>(Event.Web3NameClaimed);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32, Kilt.NetApi.Generated.Model.pallet_web3_names.web3_name.AsciiWeb3Name>>(Event.Web3NameReleased);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_web3_names.web3_name.AsciiWeb3Name>(Event.Web3NameBanned);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_web3_names.web3_name.AsciiWeb3Name>(Event.Web3NameUnbanned);
        }
    }
}
