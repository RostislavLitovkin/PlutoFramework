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


namespace Unique.NetApi.Generated.Model.pallet_foreign_assets.module
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> ForeignAssetAlreadyRegistered
        /// The foreign asset is already registered.
        /// </summary>
        ForeignAssetAlreadyRegistered = 0,
        
        /// <summary>
        /// >> BadForeignAssetId
        /// The given asset ID could not be converted into the current XCM version.
        /// </summary>
        BadForeignAssetId = 1,
    }
    
    /// <summary>
    /// >> 625 - Variant[pallet_foreign_assets.module.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
