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


namespace PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junctions
{
    
    
    /// <summary>
    /// >> Junctions
    /// </summary>
    public enum Junctions
    {
        
        /// <summary>
        /// >> Here
        /// </summary>
        Here = 0,
        
        /// <summary>
        /// >> X1
        /// </summary>
        X1 = 1,
        
        /// <summary>
        /// >> X2
        /// </summary>
        X2 = 2,
        
        /// <summary>
        /// >> X3
        /// </summary>
        X3 = 3,
        
        /// <summary>
        /// >> X4
        /// </summary>
        X4 = 4,
        
        /// <summary>
        /// >> X5
        /// </summary>
        X5 = 5,
        
        /// <summary>
        /// >> X6
        /// </summary>
        X6 = 6,
        
        /// <summary>
        /// >> X7
        /// </summary>
        X7 = 7,
        
        /// <summary>
        /// >> X8
        /// </summary>
        X8 = 8,
    }
    
    /// <summary>
    /// >> 38 - Variant[staging_xcm.v4.junctions.Junctions]
    /// </summary>
    public sealed class EnumJunctions : BaseEnumRust<Junctions>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumJunctions()
        {
				AddTypeDecoder<BaseVoid>(Junctions.Here);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr1EnumJunction>(Junctions.X1);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr2EnumJunction>(Junctions.X2);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr3EnumJunction>(Junctions.X3);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr4EnumJunction>(Junctions.X4);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr5EnumJunction>(Junctions.X5);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr6EnumJunction>(Junctions.X6);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr7EnumJunction>(Junctions.X7);
				AddTypeDecoder<PolkadotAssetHub.NetApi.Generated.Model.staging_xcm.v4.junction.Arr8EnumJunction>(Junctions.X8);
        }
    }
}
