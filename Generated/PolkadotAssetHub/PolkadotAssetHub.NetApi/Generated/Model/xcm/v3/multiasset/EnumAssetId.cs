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


namespace PolkadotAssetHub.NetApi.Generated.Model.xcm.v3.multiasset
{
    
    
    /// <summary>
    /// >> AssetId
    /// </summary>
    public enum AssetId
    {
        
        /// <summary>
        /// >> Concrete
        /// </summary>
        Concrete = 0,
        
        /// <summary>
        /// >> Abstract
        /// </summary>
        Abstract = 1,
    }
    
    /// <summary>
    /// >> 108 - Variant[xcm.v3.multiasset.AssetId]
    /// </summary>
    public sealed class EnumAssetId : BaseEnumRust<AssetId>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAssetId()
        {
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v3.multilocation.MultiLocation>(AssetId.Concrete);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Types.Base.Arr32U8>(AssetId.Abstract);
        }
    }
}
