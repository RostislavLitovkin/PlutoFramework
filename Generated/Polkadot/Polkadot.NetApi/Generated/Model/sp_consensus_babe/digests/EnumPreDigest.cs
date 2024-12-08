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


namespace Polkadot.NetApi.Generated.Model.sp_consensus_babe.digests
{
    
    
    /// <summary>
    /// >> PreDigest
    /// </summary>
    public enum PreDigest
    {
        
        /// <summary>
        /// >> Primary
        /// </summary>
        Primary = 1,
        
        /// <summary>
        /// >> SecondaryPlain
        /// </summary>
        SecondaryPlain = 2,
        
        /// <summary>
        /// >> SecondaryVRF
        /// </summary>
        SecondaryVRF = 3,
    }
    
    /// <summary>
    /// >> 534 - Variant[sp_consensus_babe.digests.PreDigest]
    /// </summary>
    public sealed class EnumPreDigest : BaseEnumRust<PreDigest>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumPreDigest()
        {
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_consensus_babe.digests.PrimaryPreDigest>(PreDigest.Primary);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_consensus_babe.digests.SecondaryPlainPreDigest>(PreDigest.SecondaryPlain);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.sp_consensus_babe.digests.SecondaryVRFPreDigest>(PreDigest.SecondaryVRF);
        }
    }
}
