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


namespace PolkadotPeople.NetApi.Generated.Model.xcm
{
    
    
    /// <summary>
    /// >> VersionedAssets
    /// </summary>
    public enum VersionedAssets
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
    /// >> 101 - Variant[xcm.VersionedAssets]
    /// </summary>
    public sealed class EnumVersionedAssets : BaseEnumRust<VersionedAssets>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedAssets()
        {
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.xcm.v3.multiasset.MultiAssets>(VersionedAssets.V3);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.staging_xcm.v4.asset.Assets>(VersionedAssets.V4);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.staging_xcm.v5.asset.Assets>(VersionedAssets.V5);
        }
    }
}
