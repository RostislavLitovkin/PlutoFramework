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


namespace Polkadot.NetApi.Generated.Model.pallet_staking
{
    
    
    /// <summary>
    /// >> Forcing
    /// </summary>
    public enum Forcing
    {
        
        /// <summary>
        /// >> NotForcing
        /// </summary>
        NotForcing = 0,
        
        /// <summary>
        /// >> ForceNew
        /// </summary>
        ForceNew = 1,
        
        /// <summary>
        /// >> ForceNone
        /// </summary>
        ForceNone = 2,
        
        /// <summary>
        /// >> ForceAlways
        /// </summary>
        ForceAlways = 3,
    }
    
    /// <summary>
    /// >> 48 - Variant[pallet_staking.Forcing]
    /// </summary>
    public sealed class EnumForcing : BaseEnum<Forcing>
    {
    }
}
