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


namespace PolkadotPeople.NetApi.Generated.Model.cumulus_pallet_xcm.pallet
{
    
    
    /// <summary>
    /// >> Origin
    /// </summary>
    public enum Origin
    {
        
        /// <summary>
        /// >> Relay
        /// </summary>
        Relay = 0,
        
        /// <summary>
        /// >> SiblingParachain
        /// </summary>
        SiblingParachain = 1,
    }
    
    /// <summary>
    /// >> 398 - Variant[cumulus_pallet_xcm.pallet.Origin]
    /// </summary>
    public sealed class EnumOrigin : BaseEnumRust<Origin>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumOrigin()
        {
				AddTypeDecoder<BaseVoid>(Origin.Relay);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>(Origin.SiblingParachain);
        }
    }
}
