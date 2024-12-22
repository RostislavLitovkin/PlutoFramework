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


namespace InvArch.NetApi.Generated.Model.xcm
{
    
    
    /// <summary>
    /// >> VersionedAsset
    /// </summary>
    public enum VersionedAsset
    {
        
        /// <summary>
        /// >> V2
        /// </summary>
        V2 = 1,
        
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
    /// >> 209 - Variant[xcm.VersionedAsset]
    /// </summary>
    public sealed class EnumVersionedAsset : BaseEnumRust<VersionedAsset>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedAsset()
        {
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v2.multiasset.MultiAsset>(VersionedAsset.V2);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.v3.multiasset.MultiAsset>(VersionedAsset.V3);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.staging_xcm.v4.asset.Asset>(VersionedAsset.V4);
        }
    }
}