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


namespace XCavatePaseo.NetApi.Generated.Model.xcm.v2.multiasset
{
    
    
    /// <summary>
    /// >> WildMultiAsset
    /// </summary>
    public enum WildMultiAsset
    {
        
        /// <summary>
        /// >> All
        /// </summary>
        All = 0,
        
        /// <summary>
        /// >> AllOf
        /// </summary>
        AllOf = 1,
    }
    
    /// <summary>
    /// >> 170 - Variant[xcm.v2.multiasset.WildMultiAsset]
    /// </summary>
    public sealed class EnumWildMultiAsset : BaseEnumRust<WildMultiAsset>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumWildMultiAsset()
        {
				AddTypeDecoder<BaseVoid>(WildMultiAsset.All);
				AddTypeDecoder<BaseTuple<XCavatePaseo.NetApi.Generated.Model.xcm.v2.multiasset.EnumAssetId, XCavatePaseo.NetApi.Generated.Model.xcm.v2.multiasset.EnumWildFungibility>>(WildMultiAsset.AllOf);
        }
    }
}
