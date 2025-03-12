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


namespace Kilt.NetApi.Generated.Model.spiritnet_runtime
{
    
    
    /// <summary>
    /// >> RuntimeHoldReason
    /// </summary>
    public enum RuntimeHoldReason
    {
        
        /// <summary>
        /// >> Preimage
        /// </summary>
        Preimage = 44,
        
        /// <summary>
        /// >> Attestation
        /// </summary>
        Attestation = 62,
        
        /// <summary>
        /// >> Delegation
        /// </summary>
        Delegation = 63,
        
        /// <summary>
        /// >> Did
        /// </summary>
        Did = 64,
        
        /// <summary>
        /// >> DidLookup
        /// </summary>
        DidLookup = 67,
        
        /// <summary>
        /// >> Web3Names
        /// </summary>
        Web3Names = 68,
        
        /// <summary>
        /// >> PublicCredentials
        /// </summary>
        PublicCredentials = 69,
        
        /// <summary>
        /// >> DepositStorage
        /// </summary>
        DepositStorage = 72,
    }
    
    /// <summary>
    /// >> 170 - Variant[spiritnet_runtime.RuntimeHoldReason]
    /// </summary>
    public sealed class EnumRuntimeHoldReason : BaseEnumRust<RuntimeHoldReason>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeHoldReason()
        {
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_preimage.pallet.EnumHoldReason>(RuntimeHoldReason.Preimage);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.attestation.pallet.EnumHoldReason>(RuntimeHoldReason.Attestation);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.delegation.pallet.EnumHoldReason>(RuntimeHoldReason.Delegation);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.pallet.EnumHoldReason>(RuntimeHoldReason.Did);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_did_lookup.pallet.EnumHoldReason>(RuntimeHoldReason.DidLookup);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_web3_names.pallet.EnumHoldReason>(RuntimeHoldReason.Web3Names);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.public_credentials.pallet.EnumHoldReason>(RuntimeHoldReason.PublicCredentials);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_deposit_storage.pallet.EnumHoldReason>(RuntimeHoldReason.DepositStorage);
        }
    }
}
