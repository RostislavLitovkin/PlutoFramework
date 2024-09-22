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
        /// >> Balances
        /// </summary>
        Balances = 10,
        
        /// <summary>
        /// >> TransactionPayment
        /// </summary>
        TransactionPayment = 11,
        
        /// <summary>
        /// >> AssetTxPayment
        /// </summary>
        AssetTxPayment = 13,
        
        /// <summary>
        /// >> Vesting
        /// </summary>
        Vesting = 14,
        
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
        MessageQueue = 35,
        
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
        /// >> Assets
        /// </summary>
        Assets = 50,
        
        /// <summary>
        /// >> Uniques
        /// </summary>
        Uniques = 51,
        
        /// <summary>
        /// >> Nfts
        /// </summary>
        Nfts = 52,
        
        /// <summary>
        /// >> ForeignAssets
        /// </summary>
        ForeignAssets = 53,
        
        /// <summary>
        /// >> NftFractionalization
        /// </summary>
        NftFractionalization = 54,
        
        /// <summary>
        /// >> PoolAssets
        /// </summary>
        PoolAssets = 55,
        
        /// <summary>
        /// >> AssetConversion
        /// </summary>
        AssetConversion = 56,
    }
    
    /// <summary>
    /// >> 21 - Variant[asset_hub_kusama_runtime.RuntimeEvent]
    /// </summary>
    public sealed class EnumRuntimeEvent : BaseEnumRust<RuntimeEvent>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumRuntimeEvent()
        {
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.frame_system.pallet.EnumEvent>(RuntimeEvent.System);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.cumulus_pallet_parachain_system.pallet.EnumEvent>(RuntimeEvent.ParachainSystem);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_balances.pallet.EnumEvent>(RuntimeEvent.Balances);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_transaction_payment.pallet.EnumEvent>(RuntimeEvent.TransactionPayment);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_asset_conversion_tx_payment.pallet.EnumEvent>(RuntimeEvent.AssetTxPayment);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_vesting.pallet.EnumEvent>(RuntimeEvent.Vesting);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_collator_selection.pallet.EnumEvent>(RuntimeEvent.CollatorSelection);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_session.pallet.EnumEvent>(RuntimeEvent.Session);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.cumulus_pallet_xcmp_queue.pallet.EnumEvent>(RuntimeEvent.XcmpQueue);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_xcm.pallet.EnumEvent>(RuntimeEvent.PolkadotXcm);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.cumulus_pallet_xcm.pallet.EnumEvent>(RuntimeEvent.CumulusXcm);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_message_queue.pallet.EnumEvent>(RuntimeEvent.MessageQueue);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_utility.pallet.EnumEvent>(RuntimeEvent.Utility);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_multisig.pallet.EnumEvent>(RuntimeEvent.Multisig);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_proxy.pallet.EnumEvent>(RuntimeEvent.Proxy);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_assets.pallet.EnumEvent>(RuntimeEvent.Assets);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_uniques.pallet.EnumEvent>(RuntimeEvent.Uniques);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_nfts.pallet.EnumEvent>(RuntimeEvent.Nfts);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_assets.pallet.EnumEvent>(RuntimeEvent.ForeignAssets);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_nft_fractionalization.pallet.EnumEvent>(RuntimeEvent.NftFractionalization);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_assets.pallet.EnumEvent>(RuntimeEvent.PoolAssets);
				AddTypeDecoder<KusamaAssetHub.NetApi.Generated.Model.pallet_asset_conversion.pallet.EnumEvent>(RuntimeEvent.AssetConversion);
        }
    }
}
