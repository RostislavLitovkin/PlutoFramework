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


namespace Kilt.NetApi.Generated.Model.pallet_did_lookup.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> associate_account
        /// See [`Pallet::associate_account`].
        /// </summary>
        associate_account = 0,
        
        /// <summary>
        /// >> associate_sender
        /// See [`Pallet::associate_sender`].
        /// </summary>
        associate_sender = 1,
        
        /// <summary>
        /// >> remove_sender_association
        /// See [`Pallet::remove_sender_association`].
        /// </summary>
        remove_sender_association = 2,
        
        /// <summary>
        /// >> remove_account_association
        /// See [`Pallet::remove_account_association`].
        /// </summary>
        remove_account_association = 3,
        
        /// <summary>
        /// >> reclaim_deposit
        /// See [`Pallet::reclaim_deposit`].
        /// </summary>
        reclaim_deposit = 4,
        
        /// <summary>
        /// >> change_deposit_owner
        /// See [`Pallet::change_deposit_owner`].
        /// </summary>
        change_deposit_owner = 5,
        
        /// <summary>
        /// >> update_deposit
        /// See [`Pallet::update_deposit`].
        /// </summary>
        update_deposit = 6,
    }
    
    /// <summary>
    /// >> 369 - Variant[pallet_did_lookup.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.pallet_did_lookup.associate_account_request.EnumAssociateAccountRequest, Substrate.NetApi.Model.Types.Primitive.U64>>(Call.associate_account);
				AddTypeDecoder<BaseVoid>(Call.associate_sender);
				AddTypeDecoder<BaseVoid>(Call.remove_sender_association);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_did_lookup.linkable_account.EnumLinkableAccountId>(Call.remove_account_association);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_did_lookup.linkable_account.EnumLinkableAccountId>(Call.reclaim_deposit);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_did_lookup.linkable_account.EnumLinkableAccountId>(Call.change_deposit_owner);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.pallet_did_lookup.linkable_account.EnumLinkableAccountId>(Call.update_deposit);
        }
    }
}
