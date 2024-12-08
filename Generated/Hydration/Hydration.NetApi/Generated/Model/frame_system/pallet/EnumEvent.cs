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


namespace Hydration.NetApi.Generated.Model.frame_system.pallet
{
    
    
    /// <summary>
    /// >> Event
    /// Event for the System pallet.
    /// </summary>
    public enum Event
    {
        
        /// <summary>
        /// >> ExtrinsicSuccess
        /// An extrinsic completed successfully.
        /// </summary>
        ExtrinsicSuccess = 0,
        
        /// <summary>
        /// >> ExtrinsicFailed
        /// An extrinsic failed.
        /// </summary>
        ExtrinsicFailed = 1,
        
        /// <summary>
        /// >> CodeUpdated
        /// `:code` was updated.
        /// </summary>
        CodeUpdated = 2,
        
        /// <summary>
        /// >> NewAccount
        /// A new account was created.
        /// </summary>
        NewAccount = 3,
        
        /// <summary>
        /// >> KilledAccount
        /// An account was reaped.
        /// </summary>
        KilledAccount = 4,
        
        /// <summary>
        /// >> Remarked
        /// On on-chain remark happened.
        /// </summary>
        Remarked = 5,
        
        /// <summary>
        /// >> UpgradeAuthorized
        /// An upgrade was authorized.
        /// </summary>
        UpgradeAuthorized = 6,
    }
    
    /// <summary>
    /// >> 22 - Variant[frame_system.pallet.Event]
    /// Event for the System pallet.
    /// </summary>
    public sealed class EnumEvent : BaseEnumRust<Event>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumEvent()
        {
				AddTypeDecoder<Hydration.NetApi.Generated.Model.frame_support.dispatch.DispatchInfo>(Event.ExtrinsicSuccess);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.sp_runtime.EnumDispatchError, Hydration.NetApi.Generated.Model.frame_support.dispatch.DispatchInfo>>(Event.ExtrinsicFailed);
				AddTypeDecoder<BaseVoid>(Event.CodeUpdated);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.NewAccount);
				AddTypeDecoder<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32>(Event.KilledAccount);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32, Hydration.NetApi.Generated.Model.primitive_types.H256>>(Event.Remarked);
				AddTypeDecoder<BaseTuple<Hydration.NetApi.Generated.Model.primitive_types.H256, Substrate.NetApi.Model.Types.Primitive.Bool>>(Event.UpgradeAuthorized);
        }
    }
}
