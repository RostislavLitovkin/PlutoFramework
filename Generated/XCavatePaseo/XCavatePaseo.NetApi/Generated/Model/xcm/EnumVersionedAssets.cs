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


namespace XCavatePaseo.NetApi.Generated.Model.xcm
{
    
    
    /// <summary>
    /// >> VersionedAssets
    /// </summary>
    public enum VersionedAssets
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
    /// >> 107 - Variant[xcm.VersionedAssets]
    /// </summary>
    public sealed class EnumVersionedAssets : BaseEnumRust<VersionedAssets>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedAssets()
        {
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.xcm.v2.multiasset.MultiAssets>(VersionedAssets.V2);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets>(VersionedAssets.V3);
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(VersionedAssets.V4);
        }
    }
}
