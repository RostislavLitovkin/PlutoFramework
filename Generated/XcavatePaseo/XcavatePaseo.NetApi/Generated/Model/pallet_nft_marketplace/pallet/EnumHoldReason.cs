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


namespace XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.pallet
{
    
    
    /// <summary>
    /// >> HoldReason
    /// </summary>
    public enum HoldReason
    {
        
        /// <summary>
        /// >> RegionDepositReserve
        /// </summary>
        RegionDepositReserve = 0,
        
        /// <summary>
        /// >> LocationDepositReserve
        /// </summary>
        LocationDepositReserve = 1,
        
        /// <summary>
        /// >> ListingDepositReserve
        /// </summary>
        ListingDepositReserve = 2,
    }
    
    /// <summary>
    /// >> 405 - Variant[pallet_nft_marketplace.pallet.HoldReason]
    /// </summary>
    public sealed class EnumHoldReason : BaseEnum<HoldReason>
    {
    }
}
