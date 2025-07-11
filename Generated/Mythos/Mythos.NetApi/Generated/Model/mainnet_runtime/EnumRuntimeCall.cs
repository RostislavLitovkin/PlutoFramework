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


namespace Mythos.NetApi.Generated.Model.mainnet_runtime
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
        /// >> ParachainSystem
        /// </summary>
        ParachainSystem = 1,
        
        /// <summary>
        /// >> Timestamp
        /// </summary>
        Timestamp = 2,
        
        /// <summary>
        /// >> ParachainInfo
        /// </summary>
        ParachainInfo = 3,
        
        /// <summary>
        /// >> Utility
        /// </summary>
        Utility = 4,
        
        /// <summary>
        /// >> Multisig
        /// </summary>
        Multisig = 5,
        
        /// <summary>
        /// >> Preimage
        /// </summary>
        Preimage = 6,
        
        /// <summary>
        /// >> Scheduler
        /// </summary>
        Scheduler = 7,
        
        /// <summary>
        /// >> Balances
        /// </summary>
        Balances = 10,
        
        /// <summary>
        /// >> Nfts
        /// </summary>
        Nfts = 12,
        
        /// <summary>
        /// >> Marketplace
        /// </summary>
        Marketplace = 13,
        
        /// <summary>
        /// >> Multibatching
        /// </summary>
        Multibatching = 14,
        
        /// <summary>
        /// >> Sudo
        /// </summary>
        Sudo = 15,
        
        /// <summary>
        /// >> Council
        /// </summary>
        Council = 16,
        
        /// <summary>
        /// >> Democracy
        /// </summary>
        Democracy = 17,
        
        /// <summary>
        /// >> Treasury
        /// </summary>
        Treasury = 18,
        
        /// <summary>
        /// >> CollatorStaking
        /// </summary>
        CollatorStaking = 21,
        
        /// <summary>
        /// >> Session
        /// </summary>
        Session = 22,
        
        /// <summary>
        /// >> XcmpQueue
        /// </summary>
        XcmpQueue = 30,
        
        /// <summary>
        /// >> PolkadotXcm
        /// </summary>
        PolkadotXcm = 31,
        
        /// <summary>
        /// >> CumulusXcm
        /// </summary>
        CumulusXcm = 32,
        
        /// <summary>
        /// >> MessageQueue
        /// </summary>
        MessageQueue = 33,
        
        /// <summary>
        /// >> Proxy
        /// </summary>
        Proxy = 40,
        
        /// <summary>
        /// >> Vesting
        /// </summary>
        Vesting = 41,
        
        /// <summary>
        /// >> Escrow
        /// </summary>
        Escrow = 50,
        
        /// <summary>
        /// >> MythProxy
        /// </summary>
        MythProxy = 51,
        
        /// <summary>
        /// >> Dmarket
        /// </summary>
        Dmarket = 52,
    }
    
    /// <summary>
    /// >> 245 - Variant[mainnet_runtime.RuntimeCall]
    /// </summary>
    public sealed class EnumRuntimeCall : BaseEnumRust<RuntimeCall>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeCall()
        {
				AddTypeDecoder<Mythos.NetApi.Generated.Model.frame_system.pallet.EnumCall>(RuntimeCall.System);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.cumulus_pallet_parachain_system.pallet.EnumCall>(RuntimeCall.ParachainSystem);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_timestamp.pallet.EnumCall>(RuntimeCall.Timestamp);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.staging_parachain_info.pallet.EnumCall>(RuntimeCall.ParachainInfo);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_utility.pallet.EnumCall>(RuntimeCall.Utility);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_multisig.pallet.EnumCall>(RuntimeCall.Multisig);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_preimage.pallet.EnumCall>(RuntimeCall.Preimage);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_scheduler.pallet.EnumCall>(RuntimeCall.Scheduler);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_balances.pallet.EnumCall>(RuntimeCall.Balances);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_nfts.pallet.EnumCall>(RuntimeCall.Nfts);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_marketplace.pallet.EnumCall>(RuntimeCall.Marketplace);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_multibatching.pallet.EnumCall>(RuntimeCall.Multibatching);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_sudo.pallet.EnumCall>(RuntimeCall.Sudo);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_collective.pallet.EnumCall>(RuntimeCall.Council);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_democracy.pallet.EnumCall>(RuntimeCall.Democracy);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_treasury.pallet.EnumCall>(RuntimeCall.Treasury);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_collator_staking.pallet.EnumCall>(RuntimeCall.CollatorStaking);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_session.pallet.EnumCall>(RuntimeCall.Session);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet.EnumCall>(RuntimeCall.XcmpQueue);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_xcm.pallet.EnumCall>(RuntimeCall.PolkadotXcm);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.cumulus_pallet_xcm.pallet.EnumCall>(RuntimeCall.CumulusXcm);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_message_queue.pallet.EnumCall>(RuntimeCall.MessageQueue);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_proxy.pallet.EnumCall>(RuntimeCall.Proxy);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_vesting.pallet.EnumCall>(RuntimeCall.Vesting);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_escrow.pallet.EnumCall>(RuntimeCall.Escrow);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_myth_proxy.pallet.EnumCall>(RuntimeCall.MythProxy);
				AddTypeDecoder<Mythos.NetApi.Generated.Model.pallet_dmarket.pallet.EnumCall>(RuntimeCall.Dmarket);
        }
    }
}
