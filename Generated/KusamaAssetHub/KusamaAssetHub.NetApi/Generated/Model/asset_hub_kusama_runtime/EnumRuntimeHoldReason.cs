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


namespace KusamaAssetHub.NetApi.Generated.Model.asset_hub_kusama_runtime
{
    
    
    /// <summary>
    /// >> RuntimeHoldReason
    /// </summary>
    public enum RuntimeHoldReason
    {
        
        /// <summary>
        /// >> NftFractionalization
        /// </summary>
        NftFractionalization = 54,
        
        /// <summary>
        /// >> StateTrieMigration
        /// </summary>
        StateTrieMigration = 70,
    }
    
    /// <summary>
    /// >> 228 - Variant[asset_hub_kusama_runtime.RuntimeHoldReason]
    /// </summary>
    public sealed class EnumRuntimeHoldReason : BaseEnumRust<RuntimeHoldReason>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeHoldReason()
        {
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_nft_fractionalization.pallet.EnumHoldReason>(RuntimeHoldReason.NftFractionalization);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_state_trie_migration.pallet.EnumHoldReason>(RuntimeHoldReason.StateTrieMigration);
        }
    }
}
