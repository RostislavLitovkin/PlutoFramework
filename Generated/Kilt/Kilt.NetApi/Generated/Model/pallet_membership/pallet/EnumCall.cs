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


namespace Kilt.NetApi.Generated.Model.pallet_membership.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> add_member
        /// See [`Pallet::add_member`].
        /// </summary>
        add_member = 0,
        
        /// <summary>
        /// >> remove_member
        /// See [`Pallet::remove_member`].
        /// </summary>
        remove_member = 1,
        
        /// <summary>
        /// >> swap_member
        /// See [`Pallet::swap_member`].
        /// </summary>
        swap_member = 2,
        
        /// <summary>
        /// >> reset_members
        /// See [`Pallet::reset_members`].
        /// </summary>
        reset_members = 3,
        
        /// <summary>
        /// >> change_key
        /// See [`Pallet::change_key`].
        /// </summary>
        change_key = 4,
        
        /// <summary>
        /// >> set_prime
        /// See [`Pallet::set_prime`].
        /// </summary>
        set_prime = 5,
        
        /// <summary>
        /// >> clear_prime
        /// See [`Pallet::clear_prime`].
        /// </summary>
        clear_prime = 6,
    }
    
    /// <summary>
    /// >> 329 - Variant[pallet_membership.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>(Call.add_member);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>(Call.remove_member);
				AddTypeDecoder<BaseTuple<Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>>(Call.swap_member);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Call.reset_members);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>(Call.change_key);
				AddTypeDecoder<Kilt.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress>(Call.set_prime);
				AddTypeDecoder<BaseVoid>(Call.clear_prime);
        }
    }
}
