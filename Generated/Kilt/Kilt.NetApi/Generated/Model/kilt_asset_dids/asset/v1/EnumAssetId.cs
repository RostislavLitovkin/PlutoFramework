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


namespace Kilt.NetApi.Generated.Model.kilt_asset_dids.asset.v1
{
    
    
    /// <summary>
    /// >> AssetId
    /// </summary>
    public enum AssetId
    {
        
        /// <summary>
        /// >> Slip44
        /// </summary>
        Slip44 = 0,
        
        /// <summary>
        /// >> Erc20
        /// </summary>
        Erc20 = 1,
        
        /// <summary>
        /// >> Erc721
        /// </summary>
        Erc721 = 2,
        
        /// <summary>
        /// >> Erc1155
        /// </summary>
        Erc1155 = 3,
        
        /// <summary>
        /// >> Generic
        /// </summary>
        Generic = 4,
    }
    
    /// <summary>
    /// >> 136 - Variant[kilt_asset_dids.asset.v1.AssetId]
    /// </summary>
    public sealed class EnumAssetId : BaseEnumRust<AssetId>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumAssetId()
        {
				AddTypeDecoder<Kilt.NetApi.Generated.Model.kilt_asset_dids.asset.v1.Slip44Reference>(AssetId.Slip44);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.kilt_asset_dids.asset.v1.EvmSmartContractFungibleReference>(AssetId.Erc20);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.kilt_asset_dids.asset.v1.EvmSmartContractNonFungibleReference>(AssetId.Erc721);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.kilt_asset_dids.asset.v1.EvmSmartContractNonFungibleReference>(AssetId.Erc1155);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.kilt_asset_dids.asset.v1.GenericAssetId>(AssetId.Generic);
        }
    }
}
