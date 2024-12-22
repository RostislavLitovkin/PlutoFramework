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


namespace InvArch.NetApi.Generated.Model.pallet_xcm.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> send
        /// </summary>
        send = 0,
        
        /// <summary>
        /// >> teleport_assets
        /// Teleport some assets from the local chain to some destination chain.
        /// 
        /// **This function is deprecated: Use `limited_teleport_assets` instead.**
        /// 
        /// Fee payment on the destination side is made from the asset in the `assets` vector of
        /// index `fee_asset_item`. The weight limit for fees is not provided and thus is unlimited,
        /// with all fees taken as needed from the asset.
        /// 
        /// - `origin`: Must be capable of withdrawing the `assets` and executing XCM.
        /// - `dest`: Destination context for the assets. Will typically be `[Parent,
        ///   Parachain(..)]` to send from parachain to parachain, or `[Parachain(..)]` to send from
        ///   relay to parachain.
        /// - `beneficiary`: A beneficiary location for the assets in the context of `dest`. Will
        ///   generally be an `AccountId32` value.
        /// - `assets`: The assets to be withdrawn. This should include the assets used to pay the
        ///   fee on the `dest` chain.
        /// - `fee_asset_item`: The index into `assets` of the item which should be used to pay
        ///   fees.
        /// </summary>
        teleport_assets = 1,
        
        /// <summary>
        /// >> reserve_transfer_assets
        /// Transfer some assets from the local chain to the destination chain through their local,
        /// destination or remote reserve.
        /// 
        /// `assets` must have same reserve location and may not be teleportable to `dest`.
        ///  - `assets` have local reserve: transfer assets to sovereign account of destination
        ///    chain and forward a notification XCM to `dest` to mint and deposit reserve-based
        ///    assets to `beneficiary`.
        ///  - `assets` have destination reserve: burn local assets and forward a notification to
        ///    `dest` chain to withdraw the reserve assets from this chain's sovereign account and
        ///    deposit them to `beneficiary`.
        ///  - `assets` have remote reserve: burn local assets, forward XCM to reserve chain to move
        ///    reserves from this chain's SA to `dest` chain's SA, and forward another XCM to `dest`
        ///    to mint and deposit reserve-based assets to `beneficiary`.
        /// 
        /// **This function is deprecated: Use `limited_reserve_transfer_assets` instead.**
        /// 
        /// Fee payment on the destination side is made from the asset in the `assets` vector of
        /// index `fee_asset_item`. The weight limit for fees is not provided and thus is unlimited,
        /// with all fees taken as needed from the asset.
        /// 
        /// - `origin`: Must be capable of withdrawing the `assets` and executing XCM.
        /// - `dest`: Destination context for the assets. Will typically be `[Parent,
        ///   Parachain(..)]` to send from parachain to parachain, or `[Parachain(..)]` to send from
        ///   relay to parachain.
        /// - `beneficiary`: A beneficiary location for the assets in the context of `dest`. Will
        ///   generally be an `AccountId32` value.
        /// - `assets`: The assets to be withdrawn. This should include the assets used to pay the
        ///   fee on the `dest` (and possibly reserve) chains.
        /// - `fee_asset_item`: The index into `assets` of the item which should be used to pay
        ///   fees.
        /// </summary>
        reserve_transfer_assets = 2,
        
        /// <summary>
        /// >> execute
        /// Execute an XCM message from a local, signed, origin.
        /// 
        /// An event is deposited indicating whether `msg` could be executed completely or only
        /// partially.
        /// 
        /// No more than `max_weight` will be used in its attempted execution. If this is less than
        /// the maximum amount of weight that the message could take to be executed, then no
        /// execution attempt will be made.
        /// </summary>
        execute = 3,
        
        /// <summary>
        /// >> force_xcm_version
        /// Extoll that a particular destination can be communicated with through a particular
        /// version of XCM.
        /// 
        /// - `origin`: Must be an origin specified by AdminOrigin.
        /// - `location`: The destination that is being described.
        /// - `xcm_version`: The latest version of XCM that `location` supports.
        /// </summary>
        force_xcm_version = 4,
        
        /// <summary>
        /// >> force_default_xcm_version
        /// Set a safe XCM version (the version that XCM should be encoded with if the most recent
        /// version a destination can accept is unknown).
        /// 
        /// - `origin`: Must be an origin specified by AdminOrigin.
        /// - `maybe_xcm_version`: The default XCM encoding version, or `None` to disable.
        /// </summary>
        force_default_xcm_version = 5,
        
        /// <summary>
        /// >> force_subscribe_version_notify
        /// Ask a location to notify us regarding their XCM version and any changes to it.
        /// 
        /// - `origin`: Must be an origin specified by AdminOrigin.
        /// - `location`: The location to which we should subscribe for XCM version notifications.
        /// </summary>
        force_subscribe_version_notify = 6,
        
        /// <summary>
        /// >> force_unsubscribe_version_notify
        /// Require that a particular destination should no longer notify us regarding any XCM
        /// version changes.
        /// 
        /// - `origin`: Must be an origin specified by AdminOrigin.
        /// - `location`: The location to which we are currently subscribed for XCM version
        ///   notifications which we no longer desire.
        /// </summary>
        force_unsubscribe_version_notify = 7,
        
        /// <summary>
        /// >> limited_reserve_transfer_assets
        /// Transfer some assets from the local chain to the destination chain through their local,
        /// destination or remote reserve.
        /// 
        /// `assets` must have same reserve location and may not be teleportable to `dest`.
        ///  - `assets` have local reserve: transfer assets to sovereign account of destination
        ///    chain and forward a notification XCM to `dest` to mint and deposit reserve-based
        ///    assets to `beneficiary`.
        ///  - `assets` have destination reserve: burn local assets and forward a notification to
        ///    `dest` chain to withdraw the reserve assets from this chain's sovereign account and
        ///    deposit them to `beneficiary`.
        ///  - `assets` have remote reserve: burn local assets, forward XCM to reserve chain to move
        ///    reserves from this chain's SA to `dest` chain's SA, and forward another XCM to `dest`
        ///    to mint and deposit reserve-based assets to `beneficiary`.
        /// 
        /// Fee payment on the destination side is made from the asset in the `assets` vector of
        /// index `fee_asset_item`, up to enough to pay for `weight_limit` of weight. If more weight
        /// is needed than `weight_limit`, then the operation will fail and the sent assets may be
        /// at risk.
        /// 
        /// - `origin`: Must be capable of withdrawing the `assets` and executing XCM.
        /// - `dest`: Destination context for the assets. Will typically be `[Parent,
        ///   Parachain(..)]` to send from parachain to parachain, or `[Parachain(..)]` to send from
        ///   relay to parachain.
        /// - `beneficiary`: A beneficiary location for the assets in the context of `dest`. Will
        ///   generally be an `AccountId32` value.
        /// - `assets`: The assets to be withdrawn. This should include the assets used to pay the
        ///   fee on the `dest` (and possibly reserve) chains.
        /// - `fee_asset_item`: The index into `assets` of the item which should be used to pay
        ///   fees.
        /// - `weight_limit`: The remote-side weight limit, if any, for the XCM fee purchase.
        /// </summary>
        limited_reserve_transfer_assets = 8,
        
        /// <summary>
        /// >> limited_teleport_assets
        /// Teleport some assets from the local chain to some destination chain.
        /// 
        /// Fee payment on the destination side is made from the asset in the `assets` vector of
        /// index `fee_asset_item`, up to enough to pay for `weight_limit` of weight. If more weight
        /// is needed than `weight_limit`, then the operation will fail and the sent assets may be
        /// at risk.
        /// 
        /// - `origin`: Must be capable of withdrawing the `assets` and executing XCM.
        /// - `dest`: Destination context for the assets. Will typically be `[Parent,
        ///   Parachain(..)]` to send from parachain to parachain, or `[Parachain(..)]` to send from
        ///   relay to parachain.
        /// - `beneficiary`: A beneficiary location for the assets in the context of `dest`. Will
        ///   generally be an `AccountId32` value.
        /// - `assets`: The assets to be withdrawn. This should include the assets used to pay the
        ///   fee on the `dest` chain.
        /// - `fee_asset_item`: The index into `assets` of the item which should be used to pay
        ///   fees.
        /// - `weight_limit`: The remote-side weight limit, if any, for the XCM fee purchase.
        /// </summary>
        limited_teleport_assets = 9,
        
        /// <summary>
        /// >> force_suspension
        /// Set or unset the global suspension state of the XCM executor.
        /// 
        /// - `origin`: Must be an origin specified by AdminOrigin.
        /// - `suspended`: `true` to suspend, `false` to resume.
        /// </summary>
        force_suspension = 10,
        
        /// <summary>
        /// >> transfer_assets
        /// Transfer some assets from the local chain to the destination chain through their local,
        /// destination or remote reserve, or through teleports.
        /// 
        /// Fee payment on the destination side is made from the asset in the `assets` vector of
        /// index `fee_asset_item` (hence referred to as `fees`), up to enough to pay for
        /// `weight_limit` of weight. If more weight is needed than `weight_limit`, then the
        /// operation will fail and the sent assets may be at risk.
        /// 
        /// `assets` (excluding `fees`) must have same reserve location or otherwise be teleportable
        /// to `dest`, no limitations imposed on `fees`.
        ///  - for local reserve: transfer assets to sovereign account of destination chain and
        ///    forward a notification XCM to `dest` to mint and deposit reserve-based assets to
        ///    `beneficiary`.
        ///  - for destination reserve: burn local assets and forward a notification to `dest` chain
        ///    to withdraw the reserve assets from this chain's sovereign account and deposit them
        ///    to `beneficiary`.
        ///  - for remote reserve: burn local assets, forward XCM to reserve chain to move reserves
        ///    from this chain's SA to `dest` chain's SA, and forward another XCM to `dest` to mint
        ///    and deposit reserve-based assets to `beneficiary`.
        ///  - for teleports: burn local assets and forward XCM to `dest` chain to mint/teleport
        ///    assets and deposit them to `beneficiary`.
        /// 
        /// - `origin`: Must be capable of withdrawing the `assets` and executing XCM.
        /// - `dest`: Destination context for the assets. Will typically be `X2(Parent,
        ///   Parachain(..))` to send from parachain to parachain, or `X1(Parachain(..))` to send
        ///   from relay to parachain.
        /// - `beneficiary`: A beneficiary location for the assets in the context of `dest`. Will
        ///   generally be an `AccountId32` value.
        /// - `assets`: The assets to be withdrawn. This should include the assets used to pay the
        ///   fee on the `dest` (and possibly reserve) chains.
        /// - `fee_asset_item`: The index into `assets` of the item which should be used to pay
        ///   fees.
        /// - `weight_limit`: The remote-side weight limit, if any, for the XCM fee purchase.
        /// </summary>
        transfer_assets = 11,
        
        /// <summary>
        /// >> claim_assets
        /// Claims assets trapped on this pallet because of leftover assets during XCM execution.
        /// 
        /// - `origin`: Anyone can call this extrinsic.
        /// - `assets`: The exact assets that were trapped. Use the version to specify what version
        /// was the latest when they were trapped.
        /// - `beneficiary`: The location/account where the claimed assets will be deposited.
        /// </summary>
        claim_assets = 12,
        
        /// <summary>
        /// >> transfer_assets_using_type_and_then
        /// Transfer assets from the local chain to the destination chain using explicit transfer
        /// types for assets and fees.
        /// 
        /// `assets` must have same reserve location or may be teleportable to `dest`. Caller must
        /// provide the `assets_transfer_type` to be used for `assets`:
        ///  - `TransferType::LocalReserve`: transfer assets to sovereign account of destination
        ///    chain and forward a notification XCM to `dest` to mint and deposit reserve-based
        ///    assets to `beneficiary`.
        ///  - `TransferType::DestinationReserve`: burn local assets and forward a notification to
        ///    `dest` chain to withdraw the reserve assets from this chain's sovereign account and
        ///    deposit them to `beneficiary`.
        ///  - `TransferType::RemoteReserve(reserve)`: burn local assets, forward XCM to `reserve`
        ///    chain to move reserves from this chain's SA to `dest` chain's SA, and forward another
        ///    XCM to `dest` to mint and deposit reserve-based assets to `beneficiary`. Typically
        ///    the remote `reserve` is Asset Hub.
        ///  - `TransferType::Teleport`: burn local assets and forward XCM to `dest` chain to
        ///    mint/teleport assets and deposit them to `beneficiary`.
        /// 
        /// On the destination chain, as well as any intermediary hops, `BuyExecution` is used to
        /// buy execution using transferred `assets` identified by `remote_fees_id`.
        /// Make sure enough of the specified `remote_fees_id` asset is included in the given list
        /// of `assets`. `remote_fees_id` should be enough to pay for `weight_limit`. If more weight
        /// is needed than `weight_limit`, then the operation will fail and the sent assets may be
        /// at risk.
        /// 
        /// `remote_fees_id` may use different transfer type than rest of `assets` and can be
        /// specified through `fees_transfer_type`.
        /// 
        /// The caller needs to specify what should happen to the transferred assets once they reach
        /// the `dest` chain. This is done through the `custom_xcm_on_dest` parameter, which
        /// contains the instructions to execute on `dest` as a final step.
        ///   This is usually as simple as:
        ///   `Xcm(vec![DepositAsset { assets: Wild(AllCounted(assets.len())), beneficiary }])`,
        ///   but could be something more exotic like sending the `assets` even further.
        /// 
        /// - `origin`: Must be capable of withdrawing the `assets` and executing XCM.
        /// - `dest`: Destination context for the assets. Will typically be `[Parent,
        ///   Parachain(..)]` to send from parachain to parachain, or `[Parachain(..)]` to send from
        ///   relay to parachain, or `(parents: 2, (GlobalConsensus(..), ..))` to send from
        ///   parachain across a bridge to another ecosystem destination.
        /// - `assets`: The assets to be withdrawn. This should include the assets used to pay the
        ///   fee on the `dest` (and possibly reserve) chains.
        /// - `assets_transfer_type`: The XCM `TransferType` used to transfer the `assets`.
        /// - `remote_fees_id`: One of the included `assets` to be used to pay fees.
        /// - `fees_transfer_type`: The XCM `TransferType` used to transfer the `fees` assets.
        /// - `custom_xcm_on_dest`: The XCM to be executed on `dest` chain as the last step of the
        ///   transfer, which also determines what happens to the assets on the destination chain.
        /// - `weight_limit`: The remote-side weight limit, if any, for the XCM fee purchase.
        /// </summary>
        transfer_assets_using_type_and_then = 13,
    }
    
    /// <summary>
    /// >> 217 - Variant[pallet_xcm.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedXcm>>(Call.send);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssets, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.teleport_assets);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssets, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.reserve_transfer_assets);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedXcm, InvArch.NetApi.Generated.Model.sp_weights.weight_v2.Weight>>(Call.execute);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.staging_xcm.v4.location.Location, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.force_xcm_version);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>>(Call.force_default_xcm_version);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation>(Call.force_subscribe_version_notify);
				AddTypeDecoder<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation>(Call.force_unsubscribe_version_notify);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssets, Substrate.NetApi.Model.Types.Primitive.U32, InvArch.NetApi.Generated.Model.xcm.v3.EnumWeightLimit>>(Call.limited_reserve_transfer_assets);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssets, Substrate.NetApi.Model.Types.Primitive.U32, InvArch.NetApi.Generated.Model.xcm.v3.EnumWeightLimit>>(Call.limited_teleport_assets);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.Bool>(Call.force_suspension);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssets, Substrate.NetApi.Model.Types.Primitive.U32, InvArch.NetApi.Generated.Model.xcm.v3.EnumWeightLimit>>(Call.transfer_assets);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssets, InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation>>(Call.claim_assets);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.xcm.EnumVersionedLocation, InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssets, InvArch.NetApi.Generated.Model.staging_xcm_executor.traits.asset_transfer.EnumTransferType, InvArch.NetApi.Generated.Model.xcm.EnumVersionedAssetId, InvArch.NetApi.Generated.Model.staging_xcm_executor.traits.asset_transfer.EnumTransferType, InvArch.NetApi.Generated.Model.xcm.EnumVersionedXcm, InvArch.NetApi.Generated.Model.xcm.v3.EnumWeightLimit>>(Call.transfer_assets_using_type_and_then);
        }
    }
}
