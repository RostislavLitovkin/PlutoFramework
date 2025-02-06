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


namespace XcavatePaseo.NetApi.Generated.Model.xcm.v3.multiasset
{
    
    
    /// <summary>
    /// >> AssetInstance
    /// </summary>
    public enum AssetInstance
    {
        
        /// <summary>
        /// >> Undefined
        /// </summary>
        Undefined = 0,
        
        /// <summary>
        /// >> Index
        /// </summary>
        Index = 1,
        
        /// <summary>
        /// >> Array4
        /// </summary>
        Array4 = 2,
        
        /// <summary>
        /// >> Array8
        /// </summary>
        Array8 = 3,
        
        /// <summary>
        /// >> Array16
        /// </summary>
        Array16 = 4,
        
        /// <summary>
        /// >> Array32
        /// </summary>
        Array32 = 5,
    }
    
    /// <summary>
    /// >> 131 - Variant[xcm.v3.multiasset.AssetInstance]
    /// </summary>
    public sealed class EnumAssetInstance : BaseEnumRust<AssetInstance>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAssetInstance()
        {
				AddTypeDecoder<BaseVoid>(AssetInstance.Undefined);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>(AssetInstance.Index);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Types.Base.Arr4U8>(AssetInstance.Array4);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Types.Base.Arr8U8>(AssetInstance.Array8);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Types.Base.Arr16U8>(AssetInstance.Array16);
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Types.Base.Arr32U8>(AssetInstance.Array32);
        }
    }
}
