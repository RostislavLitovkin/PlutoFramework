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


namespace Unique.NetApi.Generated.Model.orml_xtokens.module
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> TransferredMultiAssets
        /// Transferred `MultiAsset` with fee.
        /// </summary>
        TransferredMultiAssets = 0,
    }
    
    /// <summary>
    /// >> 46 - Variant[orml_xtokens.module.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<Unique.NetApi.Generated.Model.sp_core.crypto.AccountId32, Unique.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets, Unique.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset, Unique.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>>(Event.TransferredMultiAssets);
        }
    }
}
