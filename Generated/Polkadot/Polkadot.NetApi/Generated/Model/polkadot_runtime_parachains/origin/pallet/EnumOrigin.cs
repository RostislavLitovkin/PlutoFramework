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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.origin.pallet
{
    
    
    /// <summary>
    /// >> Origin
    /// </summary>
    public enum Origin
    {
        
        /// <summary>
        /// >> Parachain
        /// </summary>
        Parachain = 0,
    }
    
    /// <summary>
    /// >> 162 - Variant[polkadot_runtime_parachains.origin.pallet.Origin]
    /// </summary>
    public sealed class EnumOrigin : BaseEnumRust<Origin>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumOrigin()
        {
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>(Origin.Parachain);
        }
    }
}
