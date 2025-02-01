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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_xcavate_whitelist.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> NewUserWhitelisted
        /// A new user has been successfully whitelisted.
        /// </summary>
        NewUserWhitelisted = 0,
        
        /// <summary>
        /// >> UserRemoved
        /// A new user has been successfully removed.
        /// </summary>
        UserRemoved = 1,
    }
    
    /// <summary>
    /// >> 142 - Variant[pallet_xcavate_whitelist.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.NewUserWhitelisted);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.UserRemoved);
        }
    }
}
