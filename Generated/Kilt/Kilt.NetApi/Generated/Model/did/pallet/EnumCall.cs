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


namespace Kilt.NetApi.Generated.Model.did.pallet
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
        /// >> set_authentication_key
        /// See [`Pallet::set_authentication_key`].
        /// </summary>
        set_authentication_key = 1,
        
        /// <summary>
        /// >> set_delegation_key
        /// See [`Pallet::set_delegation_key`].
        /// </summary>
        set_delegation_key = 2,
        
        /// <summary>
        /// >> remove_delegation_key
        /// See [`Pallet::remove_delegation_key`].
        /// </summary>
        remove_delegation_key = 3,
        
        /// <summary>
        /// >> set_attestation_key
        /// See [`Pallet::set_attestation_key`].
        /// </summary>
        set_attestation_key = 4,
        
        /// <summary>
        /// >> remove_attestation_key
        /// See [`Pallet::remove_attestation_key`].
        /// </summary>
        remove_attestation_key = 5,
        
        /// <summary>
        /// >> add_key_agreement_key
        /// See [`Pallet::add_key_agreement_key`].
        /// </summary>
        add_key_agreement_key = 6,
        
        /// <summary>
        /// >> remove_key_agreement_key
        /// See [`Pallet::remove_key_agreement_key`].
        /// </summary>
        remove_key_agreement_key = 7,
        
        /// <summary>
        /// >> add_service_endpoint
        /// See [`Pallet::add_service_endpoint`].
        /// </summary>
        add_service_endpoint = 8,
        
        /// <summary>
        /// >> remove_service_endpoint
        /// See [`Pallet::remove_service_endpoint`].
        /// </summary>
        remove_service_endpoint = 9,
        
        /// <summary>
        /// >> delete
        /// See [`Pallet::delete`].
        /// </summary>
        delete = 10,
        
        /// <summary>
        /// >> reclaim_deposit
        /// See [`Pallet::reclaim_deposit`].
        /// </summary>
        reclaim_deposit = 11,
        
        /// <summary>
        /// >> submit_did_call
        /// See [`Pallet::submit_did_call`].
        /// </summary>
        submit_did_call = 12,
        
        /// <summary>
        /// >> change_deposit_owner
        /// See [`Pallet::change_deposit_owner`].
        /// </summary>
        change_deposit_owner = 13,
        
        /// <summary>
        /// >> update_deposit
        /// See [`Pallet::update_deposit`].
        /// </summary>
        update_deposit = 14,
        
        /// <summary>
        /// >> dispatch_as
        /// See [`Pallet::dispatch_as`].
        /// </summary>
        dispatch_as = 15,
        
        /// <summary>
        /// >> create_from_account
        /// See [`Pallet::create_from_account`].
        /// </summary>
        create_from_account = 16,
    }
    
    /// <summary>
    /// >> 347 - Variant[did.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.did.did_details.DidCreationDetails, Kilt.NetApi.Generated.Model.did.did_details.EnumDidSignature>>(Call.create);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.did_details.EnumDidVerificationKey>(Call.set_authentication_key);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.did_details.EnumDidVerificationKey>(Call.set_delegation_key);
				AddTypeDecoder<BaseVoid>(Call.remove_delegation_key);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.did_details.EnumDidVerificationKey>(Call.set_attestation_key);
				AddTypeDecoder<BaseVoid>(Call.remove_attestation_key);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.did_details.EnumDidEncryptionKey>(Call.add_key_agreement_key);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.primitive_types.H256>(Call.remove_key_agreement_key);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.service_endpoints.DidEndpoint>(Call.add_service_endpoint);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT22>(Call.remove_service_endpoint);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Call.delete);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.reclaim_deposit);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.did.did_details.DidAuthorizedCallOperation, Kilt.NetApi.Generated.Model.did.did_details.EnumDidSignature>>(Call.submit_did_call);
				AddTypeDecoder<BaseVoid>(Call.change_deposit_owner);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Call.update_deposit);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32, Kilt.NetApi.Generated.Model.spiritnet_runtime.EnumRuntimeCall>>(Call.dispatch_as);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.did.did_details.EnumDidVerificationKey>(Call.create_from_account);
        }
    }
}
