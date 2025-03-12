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
    /// >> RuntimeCall
    /// </summary>
    public enum RuntimeCall
    {
        
        /// <summary>
        /// >> System
        /// </summary>
        System = 0,
        
        /// <summary>
        /// >> Timestamp
        /// </summary>
        Timestamp = 2,
        
        /// <summary>
        /// >> Indices
        /// </summary>
        Indices = 5,
        
        /// <summary>
        /// >> Balances
        /// </summary>
        Balances = 6,
        
        /// <summary>
        /// >> Session
        /// </summary>
        Session = 22,
        
        /// <summary>
        /// >> ParachainStaking
        /// </summary>
        ParachainStaking = 21,
        
        /// <summary>
        /// >> Democracy
        /// </summary>
        Democracy = 30,
        
        /// <summary>
        /// >> Council
        /// </summary>
        Council = 31,
        
        /// <summary>
        /// >> TechnicalCommittee
        /// </summary>
        TechnicalCommittee = 32,
        
        /// <summary>
        /// >> TechnicalMembership
        /// </summary>
        TechnicalMembership = 34,
        
        /// <summary>
        /// >> Treasury
        /// </summary>
        Treasury = 35,
        
        /// <summary>
        /// >> Utility
        /// </summary>
        Utility = 40,
        
        /// <summary>
        /// >> Vesting
        /// </summary>
        Vesting = 41,
        
        /// <summary>
        /// >> Scheduler
        /// </summary>
        Scheduler = 42,
        
        /// <summary>
        /// >> Proxy
        /// </summary>
        Proxy = 43,
        
        /// <summary>
        /// >> Preimage
        /// </summary>
        Preimage = 44,
        
        /// <summary>
        /// >> TipsMembership
        /// </summary>
        TipsMembership = 45,
        
        /// <summary>
        /// >> Tips
        /// </summary>
        Tips = 46,
        
        /// <summary>
        /// >> Multisig
        /// </summary>
        Multisig = 47,
        
        /// <summary>
        /// >> AssetSwitchPool1
        /// </summary>
        AssetSwitchPool1 = 48,
        
        /// <summary>
        /// >> Fungibles
        /// </summary>
        Fungibles = 49,
        
        /// <summary>
        /// >> Ctype
        /// </summary>
        Ctype = 61,
        
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
        /// >> Migration
        /// </summary>
        Migration = 70,
        
        /// <summary>
        /// >> DipProvider
        /// </summary>
        DipProvider = 71,
        
        /// <summary>
        /// >> DepositStorage
        /// </summary>
        DepositStorage = 72,
        
        /// <summary>
        /// >> ParachainSystem
        /// </summary>
        ParachainSystem = 80,
        
        /// <summary>
        /// >> ParachainInfo
        /// </summary>
        ParachainInfo = 81,
        
        /// <summary>
        /// >> XcmpQueue
        /// </summary>
        XcmpQueue = 82,
        
        /// <summary>
        /// >> PolkadotXcm
        /// </summary>
        PolkadotXcm = 83,
        
        /// <summary>
        /// >> MessageQueue
        /// </summary>
        MessageQueue = 86,
    }
    
    /// <summary>
    /// >> 301 - Variant[spiritnet_runtime.RuntimeCall]
    /// </summary>
    public sealed class EnumRuntimeCall : BaseEnumRust<RuntimeCall>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeCall()
        {
				AddTypeDecoder<Kilt.NetApi.Generated.Model.frame_system.pallet.EnumCall>(RuntimeCall.System);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_timestamp.pallet.EnumCall>(RuntimeCall.Timestamp);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_indices.pallet.EnumCall>(RuntimeCall.Indices);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_balances.pallet.EnumCall>(RuntimeCall.Balances);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_session.pallet.EnumCall>(RuntimeCall.Session);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.parachain_staking.pallet.EnumCall>(RuntimeCall.ParachainStaking);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_democracy.pallet.EnumCall>(RuntimeCall.Democracy);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_collective.pallet.EnumCall>(RuntimeCall.Council);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_collective.pallet.EnumCall>(RuntimeCall.TechnicalCommittee);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_membership.pallet.EnumCall>(RuntimeCall.TechnicalMembership);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_treasury.pallet.EnumCall>(RuntimeCall.Treasury);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_utility.pallet.EnumCall>(RuntimeCall.Utility);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_vesting.pallet.EnumCall>(RuntimeCall.Vesting);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_scheduler.pallet.EnumCall>(RuntimeCall.Scheduler);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_proxy.pallet.EnumCall>(RuntimeCall.Proxy);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_preimage.pallet.EnumCall>(RuntimeCall.Preimage);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_membership.pallet.EnumCall>(RuntimeCall.TipsMembership);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_tips.pallet.EnumCall>(RuntimeCall.Tips);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_multisig.pallet.EnumCall>(RuntimeCall.Multisig);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_asset_switch.pallet.EnumCall>(RuntimeCall.AssetSwitchPool1);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_assets.pallet.EnumCall>(RuntimeCall.Fungibles);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.ctype.pallet.EnumCall>(RuntimeCall.Ctype);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.attestation.pallet.EnumCall>(RuntimeCall.Attestation);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.delegation.pallet.EnumCall>(RuntimeCall.Delegation);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.pallet.EnumCall>(RuntimeCall.Did);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_did_lookup.pallet.EnumCall>(RuntimeCall.DidLookup);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_web3_names.pallet.EnumCall>(RuntimeCall.Web3Names);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.public_credentials.pallet.EnumCall>(RuntimeCall.PublicCredentials);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_migration.pallet.EnumCall>(RuntimeCall.Migration);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_dip_provider.pallet.EnumCall>(RuntimeCall.DipProvider);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_deposit_storage.pallet.EnumCall>(RuntimeCall.DepositStorage);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.cumulus_pallet_parachain_system.pallet.EnumCall>(RuntimeCall.ParachainSystem);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_parachain_info.pallet.EnumCall>(RuntimeCall.ParachainInfo);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet.EnumCall>(RuntimeCall.XcmpQueue);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_xcm.pallet.EnumCall>(RuntimeCall.PolkadotXcm);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_message_queue.pallet.EnumCall>(RuntimeCall.MessageQueue);
        }
    }
}
