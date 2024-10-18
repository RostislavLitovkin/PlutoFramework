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


namespace Unique.NetApi.Generated.Model.unique_runtime
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
        /// >> StateTrieMigration
        /// </summary>
        StateTrieMigration = 1,
        
        /// <summary>
        /// >> ParachainSystem
        /// </summary>
        ParachainSystem = 20,
        
        /// <summary>
        /// >> Balances
        /// </summary>
        Balances = 30,
        
        /// <summary>
        /// >> TransactionPayment
        /// </summary>
        TransactionPayment = 33,
        
        /// <summary>
        /// >> Treasury
        /// </summary>
        Treasury = 34,
        
        /// <summary>
        /// >> Sudo
        /// </summary>
        Sudo = 35,
        
        /// <summary>
        /// >> Vesting
        /// </summary>
        Vesting = 37,
        
        /// <summary>
        /// >> XTokens
        /// </summary>
        XTokens = 38,
        
        /// <summary>
        /// >> Identity
        /// </summary>
        Identity = 40,
        
        /// <summary>
        /// >> Preimage
        /// </summary>
        Preimage = 41,
        
        /// <summary>
        /// >> Democracy
        /// </summary>
        Democracy = 42,
        
        /// <summary>
        /// >> Council
        /// </summary>
        Council = 43,
        
        /// <summary>
        /// >> TechnicalCommittee
        /// </summary>
        TechnicalCommittee = 44,
        
        /// <summary>
        /// >> CouncilMembership
        /// </summary>
        CouncilMembership = 45,
        
        /// <summary>
        /// >> TechnicalCommitteeMembership
        /// </summary>
        TechnicalCommitteeMembership = 46,
        
        /// <summary>
        /// >> FellowshipCollective
        /// </summary>
        FellowshipCollective = 47,
        
        /// <summary>
        /// >> FellowshipReferenda
        /// </summary>
        FellowshipReferenda = 48,
        
        /// <summary>
        /// >> Scheduler
        /// </summary>
        Scheduler = 49,
        
        /// <summary>
        /// >> XcmpQueue
        /// </summary>
        XcmpQueue = 50,
        
        /// <summary>
        /// >> PolkadotXcm
        /// </summary>
        PolkadotXcm = 51,
        
        /// <summary>
        /// >> CumulusXcm
        /// </summary>
        CumulusXcm = 52,
        
        /// <summary>
        /// >> DmpQueue
        /// </summary>
        DmpQueue = 53,
        
        /// <summary>
        /// >> Configuration
        /// </summary>
        Configuration = 63,
        
        /// <summary>
        /// >> Common
        /// </summary>
        Common = 66,
        
        /// <summary>
        /// >> Structure
        /// </summary>
        Structure = 70,
        
        /// <summary>
        /// >> AppPromotion
        /// </summary>
        AppPromotion = 73,
        
        /// <summary>
        /// >> ForeignAssets
        /// </summary>
        ForeignAssets = 80,
        
        /// <summary>
        /// >> EVM
        /// </summary>
        EVM = 100,
        
        /// <summary>
        /// >> Ethereum
        /// </summary>
        Ethereum = 101,
        
        /// <summary>
        /// >> EvmContractHelpers
        /// </summary>
        EvmContractHelpers = 151,
        
        /// <summary>
        /// >> EvmMigration
        /// </summary>
        EvmMigration = 153,
        
        /// <summary>
        /// >> Maintenance
        /// </summary>
        Maintenance = 154,
        
        /// <summary>
        /// >> Utility
        /// </summary>
        Utility = 156,
    }
    
    /// <summary>
    /// >> 20 - Variant[unique_runtime.RuntimeEvent]
    /// </summary>
    public sealed class EnumRuntimeEvent : BaseEnumRust<RuntimeEvent>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeEvent()
        {
				AddTypeDecoder<Unique.NetApi.Generated.Model.frame_system.pallet.EnumEvent>(RuntimeEvent.System);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_state_trie_migration.pallet.EnumEvent>(RuntimeEvent.StateTrieMigration);
				AddTypeDecoder<Unique.NetApi.Generated.Model.cumulus_pallet_parachain_system.pallet.EnumEvent>(RuntimeEvent.ParachainSystem);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_balances.pallet.EnumEvent>(RuntimeEvent.Balances);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_transaction_payment.pallet.EnumEvent>(RuntimeEvent.TransactionPayment);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_treasury.pallet.EnumEvent>(RuntimeEvent.Treasury);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_sudo.pallet.EnumEvent>(RuntimeEvent.Sudo);
				AddTypeDecoder<Unique.NetApi.Generated.Model.orml_vesting.module.EnumEvent>(RuntimeEvent.Vesting);
				AddTypeDecoder<Unique.NetApi.Generated.Model.orml_xtokens.module.EnumEvent>(RuntimeEvent.XTokens);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_identity.pallet.EnumEvent>(RuntimeEvent.Identity);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_preimage.pallet.EnumEvent>(RuntimeEvent.Preimage);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_democracy.pallet.EnumEvent>(RuntimeEvent.Democracy);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_collective.pallet.EnumEvent>(RuntimeEvent.Council);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_collective.pallet.EnumEvent>(RuntimeEvent.TechnicalCommittee);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_membership.pallet.EnumEvent>(RuntimeEvent.CouncilMembership);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_membership.pallet.EnumEvent>(RuntimeEvent.TechnicalCommitteeMembership);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_ranked_collective.pallet.EnumEvent>(RuntimeEvent.FellowshipCollective);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_referenda.pallet.EnumEvent>(RuntimeEvent.FellowshipReferenda);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_scheduler.pallet.EnumEvent>(RuntimeEvent.Scheduler);
				AddTypeDecoder<Unique.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet.EnumEvent>(RuntimeEvent.XcmpQueue);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_xcm.pallet.EnumEvent>(RuntimeEvent.PolkadotXcm);
				AddTypeDecoder<Unique.NetApi.Generated.Model.cumulus_pallet_xcm.pallet.EnumEvent>(RuntimeEvent.CumulusXcm);
				AddTypeDecoder<Unique.NetApi.Generated.Model.cumulus_pallet_dmp_queue.pallet.EnumEvent>(RuntimeEvent.DmpQueue);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_configuration.pallet.EnumEvent>(RuntimeEvent.Configuration);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_common.pallet.EnumEvent>(RuntimeEvent.Common);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_structure.pallet.EnumEvent>(RuntimeEvent.Structure);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_app_promotion.pallet.EnumEvent>(RuntimeEvent.AppPromotion);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_foreign_assets.module.EnumEvent>(RuntimeEvent.ForeignAssets);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_evm.pallet.EnumEvent>(RuntimeEvent.EVM);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_ethereum.pallet.EnumEvent>(RuntimeEvent.Ethereum);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_evm_contract_helpers.pallet.EnumEvent>(RuntimeEvent.EvmContractHelpers);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_evm_migration.pallet.EnumEvent>(RuntimeEvent.EvmMigration);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_maintenance.pallet.EnumEvent>(RuntimeEvent.Maintenance);
				AddTypeDecoder<Unique.NetApi.Generated.Model.pallet_utility.pallet.EnumEvent>(RuntimeEvent.Utility);
        }
    }
}
