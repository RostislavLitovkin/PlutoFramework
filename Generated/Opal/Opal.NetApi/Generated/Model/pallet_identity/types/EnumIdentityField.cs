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


namespace Opal.NetApi.Generated.Model.pallet_identity.types
{
    
    
    /// <summary>
    /// >> IdentityField
    /// </summary>
    public enum IdentityField
    {
        
        /// <summary>
        /// >> Display
        /// </summary>
        Display = 1,
        
        /// <summary>
        /// >> Legal
        /// </summary>
        Legal = 2,
        
        /// <summary>
        /// >> Web
        /// </summary>
        Web = 4,
        
        /// <summary>
        /// >> Riot
        /// </summary>
        Riot = 8,
        
        /// <summary>
        /// >> Email
        /// </summary>
        Email = 16,
        
        /// <summary>
        /// >> PgpFingerprint
        /// </summary>
        PgpFingerprint = 32,
        
        /// <summary>
        /// >> Image
        /// </summary>
        Image = 64,
        
        /// <summary>
        /// >> Twitter
        /// </summary>
        Twitter = 128,
    }
    
    /// <summary>
    /// >> 210 - Variant[pallet_identity.types.IdentityField]
    /// </summary>
    public sealed class EnumIdentityField : BaseEnum<IdentityField>
    {
    }
}
