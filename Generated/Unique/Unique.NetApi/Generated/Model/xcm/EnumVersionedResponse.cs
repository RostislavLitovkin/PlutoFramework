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


namespace Unique.NetApi.Generated.Model.xcm
{
    
    
    /// <summary>
    /// >> VersionedResponse
    /// </summary>
    public enum VersionedResponse
    {
        
        /// <summary>
        /// >> V2
        /// </summary>
        V2 = 2,
        
        /// <summary>
        /// >> V3
        /// </summary>
        V3 = 3,
    }
    
    /// <summary>
    /// >> 545 - Variant[xcm.VersionedResponse]
    /// </summary>
    public sealed class EnumVersionedResponse : BaseEnumRust<VersionedResponse>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedResponse()
        {
				AddTypeDecoder<Unique.NetApi.Generated.Model.xcm.v2.EnumResponse>(VersionedResponse.V2);
				AddTypeDecoder<Unique.NetApi.Generated.Model.xcm.v3.EnumResponse>(VersionedResponse.V3);
        }
    }
}
