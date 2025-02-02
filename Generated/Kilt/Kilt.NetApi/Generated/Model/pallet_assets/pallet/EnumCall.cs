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


namespace Kilt.NetApi.Generated.Model.pallet_assets.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> create
        /// See [`Pallet::create`].
        /// </summary>
        create = 0,
        
        /// <summary>
        /// >> force_create
        /// See [`Pallet::force_create`].
        /// </summary>
        force_create = 1,
        
        /// <summary>
        /// >> start_destroy
        /// See [`Pallet::start_destroy`].
        /// </summary>
        start_destroy = 2,
        
        /// <summary>
        /// >> destroy_accounts
        /// See [`Pallet::destroy_accounts`].
        /// </summary>
        destroy_accounts = 3,
        
        /// <summary>
        /// >> destroy_approvals
        /// See [`Pallet::destroy_approvals`].
        /// </summary>
        destroy_approvals = 4,
        
        /// <summary>
        /// >> finish_destroy
        /// See [`Pallet::finish_destroy`].
        /// </summary>
        finish_destroy = 5,
        
        /// <summary>
        /// >> mint
        /// See [`Pallet::mint`].
        /// </summary>
        mint = 6,
        
        /// <summary>
        /// >> burn
        /// See [`Pallet::burn`].
        /// </summary>
        burn = 7,
        
        /// <summary>
        /// >> transfer
        /// See [`Pallet::transfer`].
        /// </summary>
        transfer = 8,
        
        /// <summary>
        /// >> transfer_keep_alive
        /// See [`Pallet::transfer_keep_alive`].
        /// </summary>
        transfer_keep_alive = 9,
        
        /// <summary>
        /// >> force_transfer
        /// See [`Pallet::force_transfer`].
        /// </summary>
        force_transfer = 10,
        
        /// <summary>
        /// >> freeze
        /// See [`Pallet::freeze`].
        /// </summary>
        freeze = 11,
        
        /// <summary>
        /// >> thaw
        /// See [`Pallet::thaw`].
        /// </summary>
        thaw = 12,
        
        /// <summary>
        /// >> freeze_asset
        /// See [`Pallet::freeze_asset`].
        /// </summary>
        freeze_asset = 13,
        
        /// <summary>
        /// >> thaw_asset
        /// See [`Pallet::thaw_asset`].
        /// </summary>
        thaw_asset = 14,
        
        /// <summary>
        /// >> transfer_ownership
        /// See [`Pallet::transfer_ownership`].
        /// </summary>
        transfer_ownership = 15,
        
        /// <summary>
        /// >> set_team
        /// See [`Pallet::set_team`].
        /// </summary>
        set_team = 16,
        
        /// <summary>
        /// >> set_metadata
        /// See [`Pallet::set_metadata`].
        /// </summary>
        set_metadata = 17,
        
        /// <summary>
        /// >> clear_metadata
        /// See [`Pallet::clear_metadata`].
        /// </summary>
        clear_metadata = 18,
        
        /// <summary>
        /// >> force_set_metadata
        /// See [`Pallet::force_set_metadata`].
        /// </summary>
        force_set_metadata = 19,
        
        /// <summary>
        /// >> force_clear_metadata
        /// See [`Pallet::force_clear_metadata`].
        /// </summary>
        force_clear_metadata = 20,
        
        /// <summary>
        /// >> force_asset_status
        /// See [`Pallet::force_asset_status`].
        /// </summary>
        force_asset_status = 21,
        
        /// <summary>
        /// >> approve_transfer
        /// See [`Pallet::approve_transfer`].
        /// </summary>
        approve_transfer = 22,
        
        /// <summary>
        /// >> cancel_approval
        /// See [`Pallet::cancel_approval`].
        /// </summary>
        cancel_approval = 23,
        
        /// <summary>
        /// >> force_cancel_approval
        /// See [`Pallet::force_cancel_approval`].
        /// </summary>
        force_cancel_approval = 24,
        
        /// <summary>
        /// >> transfer_approved
        /// See [`Pallet::transfer_approved`].
        /// </summary>
        transfer_approved = 25,
        
        /// <summary>
        /// >> touch
        /// See [`Pallet::touch`].
        /// </summary>
        touch = 26,
        
        /// <summary>
        /// >> refund
        /// See [`Pallet::refund`].
        /// </summary>
        refund = 27,
        
        /// <summary>
        /// >> set_min_balance
        /// See [`Pallet::set_min_balance`].
        /// </summary>
        set_min_balance = 28,
        
        /// <summary>
        /// >> touch_other
        /// See [`Pallet::touch_other`].
        /// </summary>
        touch_other = 29,
        
        /// <summary>
        /// >> refund_other
        /// See [`Pallet::refund_other`].
        /// </summary>
        refund_other = 30,
        
        /// <summary>
        /// >> block
        /// See [`Pallet::block`].
        /// </summary>
        block = 31,
    }
    
    /// <summary>
    /// >> 334 - Variant[pallet_assets.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.create);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Primitive.Bool, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.force_create);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.start_destroy);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.destroy_accounts);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.destroy_approvals);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.finish_destroy);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.mint);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.burn);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.transfer);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.transfer_keep_alive);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.force_transfer);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.freeze);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.thaw);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.freeze_asset);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.thaw_asset);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.transfer_ownership);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.set_team);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Primitive.U8>>(Call.set_metadata);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.clear_metadata);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Primitive.U8, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.force_set_metadata);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.force_clear_metadata);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>, Substrate.NetApi.Model.Types.Primitive.Bool, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.force_asset_status);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.approve_transfer);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.cancel_approval);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.force_cancel_approval);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>>>(Call.transfer_approved);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location>(Call.touch);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Substrate.NetApi.Model.Types.Primitive.Bool>>(Call.refund);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Substrate.NetApi.Model.Types.Primitive.U128>>(Call.set_min_balance);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.touch_other);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.refund_other);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.staging_xcm.v4.location.Location, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.block);
        }
    }
}
