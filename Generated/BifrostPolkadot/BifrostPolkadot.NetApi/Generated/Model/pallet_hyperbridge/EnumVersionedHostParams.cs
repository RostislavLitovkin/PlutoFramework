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


namespace BifrostPolkadot.NetApi.Generated.Model.pallet_hyperbridge
{
    
    
    /// <summary>
    /// >> VersionedHostParams
    /// </summary>
    public enum VersionedHostParams
    {
        
        /// <summary>
        /// >> V1
        /// </summary>
        V1 = 0,
    }
    
    /// <summary>
    /// >> 565 - Variant[pallet_hyperbridge.VersionedHostParams]
    /// </summary>
    public sealed class EnumVersionedHostParams : BaseEnumRust<VersionedHostParams>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumVersionedHostParams()
        {
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.pallet_hyperbridge.SubstrateHostParams>(VersionedHostParams.V1);
        }
    }
}
