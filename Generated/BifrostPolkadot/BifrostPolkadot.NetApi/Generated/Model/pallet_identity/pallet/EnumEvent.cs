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


namespace BifrostPolkadot.NetApi.Generated.Model.pallet_identity.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> IdentitySet
        /// A name was set or reset (which will remove all judgements).
        /// </summary>
        IdentitySet = 0,
        
        /// <summary>
        /// >> IdentityCleared
        /// A name was cleared, and the given balance returned.
        /// </summary>
        IdentityCleared = 1,
        
        /// <summary>
        /// >> IdentityKilled
        /// A name was removed and the given balance slashed.
        /// </summary>
        IdentityKilled = 2,
        
        /// <summary>
        /// >> JudgementRequested
        /// A judgement was asked from a registrar.
        /// </summary>
        JudgementRequested = 3,
        
        /// <summary>
        /// >> JudgementUnrequested
        /// A judgement request was retracted.
        /// </summary>
        JudgementUnrequested = 4,
        
        /// <summary>
        /// >> JudgementGiven
        /// A judgement was given by a registrar.
        /// </summary>
        JudgementGiven = 5,
        
        /// <summary>
        /// >> RegistrarAdded
        /// A registrar was added.
        /// </summary>
        RegistrarAdded = 6,
        
        /// <summary>
        /// >> SubIdentityAdded
        /// A sub-identity was added to an identity and the deposit paid.
        /// </summary>
        SubIdentityAdded = 7,
        
        /// <summary>
        /// >> SubIdentityRemoved
        /// A sub-identity was removed from an identity and the deposit freed.
        /// </summary>
        SubIdentityRemoved = 8,
        
        /// <summary>
        /// >> SubIdentityRevoked
        /// A sub-identity was cleared, and the given deposit repatriated from the
        /// main identity account to the sub-identity account.
        /// </summary>
        SubIdentityRevoked = 9,
        
        /// <summary>
        /// >> AuthorityAdded
        /// A username authority was added.
        /// </summary>
        AuthorityAdded = 10,
        
        /// <summary>
        /// >> AuthorityRemoved
        /// A username authority was removed.
        /// </summary>
        AuthorityRemoved = 11,
        
        /// <summary>
        /// >> UsernameSet
        /// A username was set for `who`.
        /// </summary>
        UsernameSet = 12,
        
        /// <summary>
        /// >> UsernameQueued
        /// A username was queued, but `who` must accept it prior to `expiration`.
        /// </summary>
        UsernameQueued = 13,
        
        /// <summary>
        /// >> PreapprovalExpired
        /// A queued username passed its expiration without being claimed and was removed.
        /// </summary>
        PreapprovalExpired = 14,
        
        /// <summary>
        /// >> PrimaryUsernameSet
        /// A username was set as a primary and can be looked up from `who`.
        /// </summary>
        PrimaryUsernameSet = 15,
        
        /// <summary>
        /// >> DanglingUsernameRemoved
        /// A dangling username (as in, a username corresponding to an account that has removed its
        /// identity) has been removed.
        /// </summary>
        DanglingUsernameRemoved = 16,
    }
    
    /// <summary>
    /// >> 536 - Variant[pallet_identity.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.IdentitySet);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.IdentityCleared);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.IdentityKilled);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.JudgementRequested);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.JudgementUnrequested);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.JudgementGiven);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U32>(Event.RegistrarAdded);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.SubIdentityAdded);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.SubIdentityRemoved);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.SubIdentityRevoked);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.AuthorityAdded);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.AuthorityRemoved);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9>>(Event.UsernameSet);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9, Substrate.NetApi.Model.Types.Primitive.U32>>(Event.UsernameQueued);
				AddTypeDecoder<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.PreapprovalExpired);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9>>(Event.PrimaryUsernameSet);
				AddTypeDecoder<BaseTuple<BifrostPolkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, BifrostPolkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT9>>(Event.DanglingUsernameRemoved);
        }
    }
}
