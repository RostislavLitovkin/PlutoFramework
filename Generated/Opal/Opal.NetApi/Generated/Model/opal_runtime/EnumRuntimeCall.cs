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


namespace Opal.NetApi.Generated.Model.opal_runtime
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
        /// >> StateTrieMigration
        /// </summary>
        StateTrieMigration = 1,
        
        /// <summary>
        /// >> ParachainSystem
        /// </summary>
        ParachainSystem = 20,
        
        /// <summary>
        /// >> ParachainInfo
        /// </summary>
        ParachainInfo = 21,
        
        /// <summary>
        /// >> CollatorSelection
        /// </summary>
        CollatorSelection = 23,
        
        /// <summary>
        /// >> Session
        /// </summary>
        Session = 24,
        
        /// <summary>
        /// >> Balances
        /// </summary>
        Balances = 30,
        
        /// <summary>
        /// >> Timestamp
        /// </summary>
        Timestamp = 32,
        
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
        /// >> FinancialCouncil
        /// </summary>
        FinancialCouncil = 97,
        
        /// <summary>
        /// >> FinancialCouncilMembership
        /// </summary>
        FinancialCouncilMembership = 98,
        
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
        /// >> MessageQueue
        /// </summary>
        MessageQueue = 54,
        
        /// <summary>
        /// >> Inflation
        /// </summary>
        Inflation = 60,
        
        /// <summary>
        /// >> Unique
        /// </summary>
        Unique = 61,
        
        /// <summary>
        /// >> Configuration
        /// </summary>
        Configuration = 63,
        
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
        
        /// <summary>
        /// >> TestUtils
        /// </summary>
        TestUtils = 255,
    }
    
    /// <summary>
    /// >> 93 - Variant[opal_runtime.RuntimeCall]
    /// </summary>
    public sealed class EnumRuntimeCall : BaseEnumRust<RuntimeCall>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeCall()
        {
				AddTypeDecoder<Opal.NetApi.Generated.Model.frame_system.pallet.EnumCall>(RuntimeCall.System);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_state_trie_migration.pallet.EnumCall>(RuntimeCall.StateTrieMigration);
				AddTypeDecoder<Opal.NetApi.Generated.Model.cumulus_pallet_parachain_system.pallet.EnumCall>(RuntimeCall.ParachainSystem);
				AddTypeDecoder<Opal.NetApi.Generated.Model.staging_parachain_info.pallet.EnumCall>(RuntimeCall.ParachainInfo);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_collator_selection.pallet.EnumCall>(RuntimeCall.CollatorSelection);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_session.pallet.EnumCall>(RuntimeCall.Session);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_balances.pallet.EnumCall>(RuntimeCall.Balances);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_timestamp.pallet.EnumCall>(RuntimeCall.Timestamp);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_treasury.pallet.EnumCall>(RuntimeCall.Treasury);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_sudo.pallet.EnumCall>(RuntimeCall.Sudo);
				AddTypeDecoder<Opal.NetApi.Generated.Model.orml_vesting.module.EnumCall>(RuntimeCall.Vesting);
				AddTypeDecoder<Opal.NetApi.Generated.Model.orml_xtokens.module.EnumCall>(RuntimeCall.XTokens);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_identity.pallet.EnumCall>(RuntimeCall.Identity);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_preimage.pallet.EnumCall>(RuntimeCall.Preimage);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_democracy.pallet.EnumCall>(RuntimeCall.Democracy);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_collective.pallet.EnumCall>(RuntimeCall.Council);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_collective.pallet.EnumCall>(RuntimeCall.TechnicalCommittee);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_membership.pallet.EnumCall>(RuntimeCall.CouncilMembership);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_membership.pallet.EnumCall>(RuntimeCall.TechnicalCommitteeMembership);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_ranked_collective.pallet.EnumCall>(RuntimeCall.FellowshipCollective);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_referenda.pallet.EnumCall>(RuntimeCall.FellowshipReferenda);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_scheduler.pallet.EnumCall>(RuntimeCall.Scheduler);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_collective.pallet.EnumCall>(RuntimeCall.FinancialCouncil);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_membership.pallet.EnumCall>(RuntimeCall.FinancialCouncilMembership);
				AddTypeDecoder<Opal.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet.EnumCall>(RuntimeCall.XcmpQueue);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_xcm.pallet.EnumCall>(RuntimeCall.PolkadotXcm);
				AddTypeDecoder<Opal.NetApi.Generated.Model.cumulus_pallet_xcm.pallet.EnumCall>(RuntimeCall.CumulusXcm);
				AddTypeDecoder<Opal.NetApi.Generated.Model.cumulus_pallet_dmp_queue.pallet.EnumCall>(RuntimeCall.DmpQueue);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_message_queue.pallet.EnumCall>(RuntimeCall.MessageQueue);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_inflation.pallet.EnumCall>(RuntimeCall.Inflation);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_unique.pallet.EnumCall>(RuntimeCall.Unique);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_configuration.pallet.EnumCall>(RuntimeCall.Configuration);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_structure.pallet.EnumCall>(RuntimeCall.Structure);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_app_promotion.pallet.EnumCall>(RuntimeCall.AppPromotion);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_foreign_assets.module.EnumCall>(RuntimeCall.ForeignAssets);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_evm.pallet.EnumCall>(RuntimeCall.EVM);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_ethereum.pallet.EnumCall>(RuntimeCall.Ethereum);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_evm_contract_helpers.pallet.EnumCall>(RuntimeCall.EvmContractHelpers);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_evm_migration.pallet.EnumCall>(RuntimeCall.EvmMigration);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_maintenance.pallet.EnumCall>(RuntimeCall.Maintenance);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_utility.pallet.EnumCall>(RuntimeCall.Utility);
				AddTypeDecoder<Opal.NetApi.Generated.Model.pallet_test_utils.pallet.EnumCall>(RuntimeCall.TestUtils);
        }
    }
}
