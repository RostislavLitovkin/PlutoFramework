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
    /// >> 111 - Variant[xcm.v2.multiasset.AssetId]
    /// </summary>
    public sealed class EnumAssetId : BaseEnumRust<AssetId>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAssetId()
        {
				AddTypeDecoder<XCavatePaseo.NetApi.Generated.Model.xcm.v2.multilocation.MultiLocation>(AssetId.Concrete);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(AssetId.Abstract);
        }
    }
}
