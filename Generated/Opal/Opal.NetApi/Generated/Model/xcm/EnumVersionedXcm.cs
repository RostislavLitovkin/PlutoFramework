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


namespace Opal.NetApi.Generated.Model.xcm
{
    
    
    /// <summary>
    /// >> VersionedXcm
    /// </summary>
    public enum VersionedXcm
    {
        
        /// <summary>
        /// >> V3
        /// </summary>
        V3 = 3,
        
        /// <summary>
        /// >> V4
        /// </summary>
        V4 = 4,
        
        /// <summary>
        /// >> V5
        /// </summary>
        V5 = 5,
    }
    
    /// <summary>
    /// >> 309 - Variant[xcm.VersionedXcm]
    /// </summary>
    public sealed class EnumVersionedXcm : BaseEnumRust<VersionedXcm>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedXcm()
        {
				AddTypeDecoder<Opal.NetApi.Generated.Model.xcm.v3.XcmT2>(VersionedXcm.V3);
				AddTypeDecoder<Opal.NetApi.Generated.Model.staging_xcm.v4.XcmT2>(VersionedXcm.V4);
				AddTypeDecoder<Opal.NetApi.Generated.Model.staging_xcm.v5.XcmT2>(VersionedXcm.V5);
        }
    }
}
