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


namespace PolkadotAssetHub.NetApi.Generated.Model.xcm
{
    
    
    /// <summary>
    /// >> VersionedAssetId
    /// </summary>
    public enum VersionedAssetId
    {
        
        /// <summary>
        /// >> V3
        /// </summary>
        V3 = 3,
        
        /// <summary>
        /// >> V4
        /// </summary>
        V4 = 4,
    }
    
    /// <summary>
    /// >> 296 - Variant[xcm.VersionedAssetId]
    /// </summary>
    public sealed class EnumVersionedAssetId : BaseEnumRust<VersionedAssetId>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedAssetId()
        {
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.xcm.v3.multiasset.EnumAssetId>(VersionedAssetId.V3);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.AssetId>(VersionedAssetId.V4);
        }
    }
}
