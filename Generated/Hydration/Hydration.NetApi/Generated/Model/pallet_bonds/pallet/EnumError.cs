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


namespace Hydration.NetApi.Generated.Model.pallet_bonds.pallet
{
    
    
    /// <summary>
    /// >> Error
    /// The `Error` enum of this pallet.
    /// </summary>
    public enum Error
    {
        
        /// <summary>
        /// >> NotRegistered
        /// Bond not registered
        /// </summary>
        NotRegistered = 0,
        
        /// <summary>
        /// >> NotMature
        /// Bond is not mature
        /// </summary>
        NotMature = 1,
        
        /// <summary>
        /// >> InvalidMaturity
        /// Maturity not long enough
        /// </summary>
        InvalidMaturity = 2,
        
        /// <summary>
        /// >> DisallowedAsset
        /// Asset type not allowed for underlying asset
        /// </summary>
        DisallowedAsset = 3,
        
        /// <summary>
        /// >> AssetNotFound
        /// Asset is not registered in `AssetRegistry`
        /// </summary>
        AssetNotFound = 4,
        
        /// <summary>
        /// >> InvalidBondName
        /// Generated name is not valid.
        /// </summary>
        InvalidBondName = 5,
        
        /// <summary>
        /// >> FailToParseName
        /// Bond's name parsing was now successful
        /// </summary>
        FailToParseName = 6,
    }
    
    /// <summary>
    /// >> 613 - Variant[pallet_bonds.pallet.Error]
    /// The `Error` enum of this pallet.
    /// </summary>
    public sealed class EnumError : BaseEnum<Error>
    {
    }
}
