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


namespace Kilt.NetApi.Generated.Model.runtime_common.authorization
{
    
    
    /// <summary>
    /// >> PalletAuthorize
    /// </summary>
    public enum PalletAuthorize
    {
        
        /// <summary>
        /// >> Delegation
        /// </summary>
        Delegation = 0,
    }
    
    /// <summary>
    /// >> 338 - Variant[runtime_common.authorization.PalletAuthorize]
    /// </summary>
    public sealed class EnumPalletAuthorize : BaseEnumRust<PalletAuthorize>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumPalletAuthorize()
        {
				AddTypeDecoder<Kilt.NetApi.Generated.Model.delegation.access_control.DelegationAc>(PalletAuthorize.Delegation);
        }
    }
}
