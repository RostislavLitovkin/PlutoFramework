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


namespace PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset
{
    
    
    /// <summary>
    /// >> WildAsset
    /// </summary>
    public enum WildAsset
    {
        
        /// <summary>
        /// >> All
        /// </summary>
        All = 0,
        
        /// <summary>
        /// >> AllOf
        /// </summary>
        AllOf = 1,
        
        /// <summary>
        /// >> AllCounted
        /// </summary>
        AllCounted = 2,
        
        /// <summary>
        /// >> AllOfCounted
        /// </summary>
        AllOfCounted = 3,
    }
    
    /// <summary>
    /// >> 88 - Variant[staging_xcm.v4.asset.WildAsset]
    /// </summary>
    public sealed class EnumWildAsset : BaseEnumRust<WildAsset>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumWildAsset()
        {
				AddTypeDecoder<BaseVoid>(WildAsset.All);
				AddTypeDecoder<BaseTuple<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.AssetId, PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumWildFungibility>>(WildAsset.AllOf);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>(WildAsset.AllCounted);
				AddTypeDecoder<BaseTuple<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.AssetId, PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.asset.EnumWildFungibility, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>>>(WildAsset.AllOfCounted);
        }
    }
}
