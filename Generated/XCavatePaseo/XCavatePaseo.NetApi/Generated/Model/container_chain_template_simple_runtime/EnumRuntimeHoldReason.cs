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


namespace XcavatePaseo.NetApi.Generated.Model.container_chain_template_simple_runtime
{
    
    
    /// <summary>
    /// >> RuntimeHoldReason
    /// </summary>
    public enum RuntimeHoldReason
    {
        
        /// <summary>
        /// >> NftFractionalization
        /// </summary>
        NftFractionalization = 117,
    }
    
    /// <summary>
    /// >> 379 - Variant[container_chain_template_simple_runtime.RuntimeHoldReason]
    /// </summary>
    public sealed class EnumRuntimeHoldReason : BaseEnumRust<RuntimeHoldReason>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeHoldReason()
        {
				AddTypeDecoder<XcavatePaseo.NetApi.Generated.Model.pallet_nft_fractionalization.pallet.EnumHoldReason>(RuntimeHoldReason.NftFractionalization);
        }
    }
}
