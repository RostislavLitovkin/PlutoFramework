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


namespace Unique.NetApi.Generated.Model.xcm.v2
{
    
    
    /// <summary>
    /// >> OriginKind
    /// </summary>
    public enum OriginKind
    {
        
        /// <summary>
        /// >> Native
        /// </summary>
        Native = 0,
        
        /// <summary>
        /// >> SovereignAccount
        /// </summary>
        SovereignAccount = 1,
        
        /// <summary>
        /// >> Superuser
        /// </summary>
        Superuser = 2,
        
        /// <summary>
        /// >> Xcm
        /// </summary>
        Xcm = 3,
    }
    
    /// <summary>
    /// >> 224 - Variant[xcm.v2.OriginKind]
    /// </summary>
    public sealed class EnumOriginKind : BaseEnum<OriginKind>
    {
    }
}
