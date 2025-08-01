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


namespace Opal.NetApi.Generated.Model.orml_xtokens.module
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> TransferredAssets
        /// Transferred `Asset` with fee.
        /// </summary>
        TransferredAssets = 0,
    }
    
    /// <summary>
    /// >> 50 - Variant[orml_xtokens.module.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Opal.NetApi.Generated.Model.sp_core.crypto.AccountId32, Opal.NetApi.Generated.Model.staging_xcm.v5.asset.Assets, Opal.NetApi.Generated.Model.staging_xcm.v5.asset.Asset, Opal.NetApi.Generated.Model.staging_xcm.v5.location.Location>>(Event.TransferredAssets);
        }
    }
}
