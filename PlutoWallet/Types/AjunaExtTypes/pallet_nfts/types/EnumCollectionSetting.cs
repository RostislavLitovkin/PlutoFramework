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


namespace PlutoWallet.NetApiExt.Generated.Model.pallet_nfts.types
{
    
    
    public enum CollectionSetting
    {
        
        TransferableItems = 1,
        
        UnlockedMetadata = 2,
        
        UnlockedAttributes = 4,
        
        UnlockedMaxSupply = 8,
        
        DepositRequired = 16,
    }
    
    /// <summary>
    /// >> 287 - Variant[pallet_nfts.types.CollectionSetting]
    /// </summary>
    public sealed class EnumCollectionSetting : BaseEnum<CollectionSetting>
    {
    }
}
