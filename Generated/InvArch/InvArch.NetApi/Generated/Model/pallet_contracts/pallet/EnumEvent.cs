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


namespace InvArch.NetApi.Generated.Model.pallet_contracts.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// The `Event` enum of this pallet
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> Instantiated
        /// Contract deployed by address at the specified address.
        /// </summary>
        Instantiated = 0,
        
        /// <summary>
        /// >> Terminated
        /// Contract has been removed.
        /// 
        /// # Note
        /// 
        /// The only way for a contract to be removed and emitting this event is by calling
        /// `seal_terminate`.
        /// </summary>
        Terminated = 1,
        
        /// <summary>
        /// >> CodeStored
        /// Code with the specified hash has been stored.
        /// </summary>
        CodeStored = 2,
        
        /// <summary>
        /// >> ContractEmitted
        /// A custom event emitted by the contract.
        /// </summary>
        ContractEmitted = 3,
        
        /// <summary>
        /// >> CodeRemoved
        /// A code with the specified hash was removed.
        /// </summary>
        CodeRemoved = 4,
        
        /// <summary>
        /// >> ContractCodeUpdated
        /// A contract's code was updated.
        /// </summary>
        ContractCodeUpdated = 5,
        
        /// <summary>
        /// >> Called
        /// A contract was called either by a plain account or another contract.
        /// 
        /// # Note
        /// 
        /// Please keep in mind that like all events this is only emitted for successful
        /// calls. This is because on failure all storage changes including events are
        /// rolled back.
        /// </summary>
        Called = 6,
        
        /// <summary>
        /// >> DelegateCalled
        /// A contract delegate called a code hash.
        /// 
        /// # Note
        /// 
        /// Please keep in mind that like all events this is only emitted for successful
        /// calls. This is because on failure all storage changes including events are
        /// rolled back.
        /// </summary>
        DelegateCalled = 7,
        
        /// <summary>
        /// >> StorageDepositTransferredAndHeld
        /// Some funds have been transferred and held as storage deposit.
        /// </summary>
        StorageDepositTransferredAndHeld = 8,
        
        /// <summary>
        /// >> StorageDepositTransferredAndReleased
        /// Some storage deposit funds have been transferred and released.
        /// </summary>
        StorageDepositTransferredAndReleased = 9,
    }
    
    /// <summary>
    /// >> 142 - Variant[pallet_contracts.pallet.Event]
    /// The `Event` enum of this pallet
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.Instantiated);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.Terminated);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U128, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.CodeStored);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>(Event.ContractEmitted);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.U128, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.CodeRemoved);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, InvArch.NetApi.Generated.Model.primitive_types.H256, InvArch.NetApi.Generated.Model.primitive_types.H256>>(Event.ContractCodeUpdated);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.pallet_contracts.EnumOrigin, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32>>(Event.Called);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, InvArch.NetApi.Generated.Model.primitive_types.H256>>(Event.DelegateCalled);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.StorageDepositTransferredAndHeld);
				AddTypeDecoder<BaseTuple<InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, InvArch.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U128>>(Event.StorageDepositTransferredAndReleased);
        }
    }
}
