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


namespace Unique.NetApi.Generated.Model.up_data_structs
{
    
    
    /// <summary>
    /// >> CreateItemData
    /// </summary>
    public enum CreateItemData
    {
        
        /// <summary>
        /// >> NFT
        /// </summary>
        NFT = 0,
        
        /// <summary>
        /// >> Fungible
        /// </summary>
        Fungible = 1,
        
        /// <summary>
        /// >> ReFungible
        /// </summary>
        ReFungible = 2,
    }
    
    /// <summary>
    /// >> 294 - Variant[up_data_structs.CreateItemData]
    /// </summary>
    public sealed class EnumCreateItemData : BaseEnumRust<CreateItemData>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCreateItemData()
        {
				AddTypeDecoder<Unique.NetApi.Generated.Model.up_data_structs.CreateNftData>(CreateItemData.NFT);
				AddTypeDecoder<Unique.NetApi.Generated.Model.up_data_structs.CreateFungibleData>(CreateItemData.Fungible);
				AddTypeDecoder<Unique.NetApi.Generated.Model.up_data_structs.CreateReFungibleData>(CreateItemData.ReFungible);
        }
    }
}
