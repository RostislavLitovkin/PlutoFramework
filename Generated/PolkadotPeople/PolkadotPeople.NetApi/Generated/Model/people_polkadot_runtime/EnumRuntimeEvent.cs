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


namespace PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime
{
    
    
    /// <summary>
    /// >> RuntimeEvent
    /// </summary>
    public enum RuntimeEvent
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
        /// >> MultiBlockMigrations
        /// </summary>
        MultiBlockMigrations = 4,
        
        /// <summary>
        /// >> Balances
        /// </summary>
        Balances = 10,
        
        /// <summary>
        /// >> TransactionPayment
        /// </summary>
        TransactionPayment = 11,
        
        /// <summary>
        /// >> CollatorSelection
        /// </summary>
        CollatorSelection = 21,
        
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
        MessageQueue = 34,
        
        /// <summary>
        /// >> Utility
        /// </summary>
        Utility = 40,
        
        /// <summary>
        /// >> Multisig
        /// </summary>
        Multisig = 41,
        
        /// <summary>
        /// >> Proxy
        /// </summary>
        Proxy = 42,
        
        /// <summary>
        /// >> Identity
        /// </summary>
        Identity = 50,
    }
    
    /// <summary>
    /// >> 21 - Variant[people_polkadot_runtime.RuntimeEvent]
    /// </summary>
    public sealed class EnumRuntimeEvent : BaseEnumRust<RuntimeEvent>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeEvent()
        {
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.frame_system.pallet.EnumEvent>(RuntimeEvent.System);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.cumulus_pallet_parachain_system.pallet.EnumEvent>(RuntimeEvent.ParachainSystem);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_migrations.pallet.EnumEvent>(RuntimeEvent.MultiBlockMigrations);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_balances.pallet.EnumEvent>(RuntimeEvent.Balances);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_transaction_payment.pallet.EnumEvent>(RuntimeEvent.TransactionPayment);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_collator_selection.pallet.EnumEvent>(RuntimeEvent.CollatorSelection);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_session.pallet.EnumEvent>(RuntimeEvent.Session);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet.EnumEvent>(RuntimeEvent.XcmpQueue);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_xcm.pallet.EnumEvent>(RuntimeEvent.PolkadotXcm);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.cumulus_pallet_xcm.pallet.EnumEvent>(RuntimeEvent.CumulusXcm);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_message_queue.pallet.EnumEvent>(RuntimeEvent.MessageQueue);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_utility.pallet.EnumEvent>(RuntimeEvent.Utility);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_multisig.pallet.EnumEvent>(RuntimeEvent.Multisig);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_proxy.pallet.EnumEvent>(RuntimeEvent.Proxy);
				AddTypeDecoder<PolkadotPeople.NetApi.Generated.Model.pallet_identity.pallet.EnumEvent>(RuntimeEvent.Identity);
        }
    }
}
