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


namespace BifrostPolkadot.NetApi.Generated.Model.xcm.v2.multilocation
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
    /// >> 133 - Variant[xcm.v2.multilocation.Junctions]
    /// </summary>
    public sealed class EnumJunctions : BaseEnumRust<Junctions>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumJunctions()
        {
				AddTypeDecoder<BaseVoid>(Junctions.Here);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>(Junctions.X1);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>>(Junctions.X2);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>>(Junctions.X3);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>>(Junctions.X4);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>>(Junctions.X5);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>>(Junctions.X6);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>>(Junctions.X7);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction, BifrostPolkadot.NetApi.Generated.Model.xcm.v2.junction.EnumJunction>>(Junctions.X8);
        }
    }
}
