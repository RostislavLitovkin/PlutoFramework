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


namespace Kilt.NetApi.Generated.Model.attestation.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> add
        /// See [`Pallet::add`].
        /// </summary>
        add = 0,
        
        /// <summary>
        /// >> revoke
        /// See [`Pallet::revoke`].
        /// </summary>
        revoke = 1,
        
        /// <summary>
        /// >> remove
        /// See [`Pallet::remove`].
        /// </summary>
        remove = 2,
        
        /// <summary>
        /// >> reclaim_deposit
        /// See [`Pallet::reclaim_deposit`].
        /// </summary>
        reclaim_deposit = 3,
        
        /// <summary>
        /// >> change_deposit_owner
        /// See [`Pallet::change_deposit_owner`].
        /// </summary>
        change_deposit_owner = 4,
        
        /// <summary>
        /// >> update_deposit
        /// See [`Pallet::update_deposit`].
        /// </summary>
        update_deposit = 5,
    }
    
    /// <summary>
    /// >> 336 - Variant[attestation.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.primitive_types.H256, Kilt.NetApi.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumPalletAuthorize>>>(Call.add);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumPalletAuthorize>>>(Call.revoke);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumPalletAuthorize>>>(Call.remove);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.primitive_types.H256>(Call.reclaim_deposit);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.primitive_types.H256>(Call.change_deposit_owner);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.primitive_types.H256>(Call.update_deposit);
        }
    }
}
