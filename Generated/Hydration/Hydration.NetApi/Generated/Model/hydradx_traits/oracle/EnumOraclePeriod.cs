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


namespace Hydration.NetApi.Generated.Model.hydradx_traits.oracle
{
    
    
    /// <summary>
    /// >> OraclePeriod
    /// </summary>
    public enum OraclePeriod
    {
        
        /// <summary>
        /// >> LastBlock
        /// </summary>
        LastBlock = 0,
        
        /// <summary>
        /// >> Short
        /// </summary>
        Short = 1,
        
        /// <summary>
        /// >> TenMinutes
        /// </summary>
        TenMinutes = 2,
        
        /// <summary>
        /// >> Hour
        /// </summary>
        Hour = 3,
        
        /// <summary>
        /// >> Day
        /// </summary>
        Day = 4,
        
        /// <summary>
        /// >> Week
        /// </summary>
        Week = 5,
    }
    
    /// <summary>
    /// >> 584 - Variant[hydradx_traits.oracle.OraclePeriod]
    /// </summary>
    public sealed class EnumOraclePeriod : BaseEnum<OraclePeriod>
    {
    }
}
