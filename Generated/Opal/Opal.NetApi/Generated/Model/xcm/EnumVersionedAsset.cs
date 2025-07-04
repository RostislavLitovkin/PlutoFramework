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


namespace Opal.NetApi.Generated.Model.xcm
{
    
    
    /// <summary>
    /// >> VersionedAsset
    /// </summary>
    public enum VersionedAsset
    {
        
        /// <summary>
        /// >> V3
        /// </summary>
        V3 = 3,
        
        /// <summary>
        /// >> V4
        /// </summary>
        V4 = 4,
        
        /// <summary>
        /// >> V5
        /// </summary>
        V5 = 5,
    }
    
    /// <summary>
    /// >> 156 - Variant[xcm.VersionedAsset]
    /// </summary>
    public sealed class EnumVersionedAsset : BaseEnumRust<VersionedAsset>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedAsset()
        {
				AddTypeDecoder<Opal.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset>(VersionedAsset.V3);
				AddTypeDecoder<Opal.NetApi.Generated.Model.staging_xcm.v4.asset.Asset>(VersionedAsset.V4);
				AddTypeDecoder<Opal.NetApi.Generated.Model.staging_xcm.v5.asset.Asset>(VersionedAsset.V5);
        }
    }
}
