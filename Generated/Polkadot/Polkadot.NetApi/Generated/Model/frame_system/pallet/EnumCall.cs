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


namespace Polkadot.NetApi.Generated.Model.frame_system.pallet
{
    
    
    /// <summary>
    /// >> Call
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public enum Call
    {
        
        /// <summary>
        /// >> remark
        /// Make some on-chain remark.
        /// 
        /// Can be executed by every `origin`.
        /// </summary>
        remark = 0,
        
        /// <summary>
        /// >> set_heap_pages
        /// Set the number of pages in the WebAssembly environment's heap.
        /// </summary>
        set_heap_pages = 1,
        
        /// <summary>
        /// >> set_code
        /// Set the new runtime code.
        /// </summary>
        set_code = 2,
        
        /// <summary>
        /// >> set_code_without_checks
        /// Set the new runtime code without doing any checks of the given `code`.
        /// 
        /// Note that runtime upgrades will not run if this is called with a not-increasing spec
        /// version!
        /// </summary>
        set_code_without_checks = 3,
        
        /// <summary>
        /// >> set_storage
        /// Set some items of storage.
        /// </summary>
        set_storage = 4,
        
        /// <summary>
        /// >> kill_storage
        /// Kill some items from storage.
        /// </summary>
        kill_storage = 5,
        
        /// <summary>
        /// >> kill_prefix
        /// Kill all storage items with a key that starts with the given prefix.
        /// 
        /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under
        /// the prefix we are removing to accurately calculate the weight of this function.
        /// </summary>
        kill_prefix = 6,
        
        /// <summary>
        /// >> remark_with_event
        /// Make some on-chain remark and emit event.
        /// </summary>
        remark_with_event = 7,
        
        /// <summary>
        /// >> authorize_upgrade
        /// Authorize an upgrade to a given `code_hash` for the runtime. The runtime can be supplied
        /// later.
        /// 
        /// This call requires Root origin.
        /// </summary>
        authorize_upgrade = 9,
        
        /// <summary>
        /// >> authorize_upgrade_without_checks
        /// Authorize an upgrade to a given `code_hash` for the runtime. The runtime can be supplied
        /// later.
        /// 
        /// WARNING: This authorizes an upgrade that will take place without any safety checks, for
        /// example that the spec name remains the same and that the version number increases. Not
        /// recommended for normal use. Use `authorize_upgrade` instead.
        /// 
        /// This call requires Root origin.
        /// </summary>
        authorize_upgrade_without_checks = 10,
        
        /// <summary>
        /// >> apply_authorized_upgrade
        /// Provide the preimage (runtime binary) `code` for an upgrade that has been authorized.
        /// 
        /// If the authorization required a version check, this call will ensure the spec name
        /// remains unchanged and that the spec version has increased.
        /// 
        /// Depending on the runtime's `OnSetCode` configuration, this function may directly apply
        /// the new `code` in the same block or attempt to schedule the upgrade.
        /// 
        /// All origins are allowed.
        /// </summary>
        apply_authorized_upgrade = 11,
    }
    
    /// <summary>
    /// >> 94 - Variant[frame_system.pallet.Call]
    /// Contains a variant per dispatchable extrinsic that this pallet has.
    /// </summary>
    public sealed class EnumCall : BaseEnumRust<Call>
    {
        
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public EnumCall()
        {
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(Call.remark);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Primitive.U64>(Call.set_heap_pages);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(Call.set_code);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(Call.set_code_without_checks);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>>(Call.set_storage);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>(Call.kill_storage);
				AddTypeDecoder<BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Primitive.U32>>(Call.kill_prefix);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(Call.remark_with_event);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.primitive_types.H256>(Call.authorize_upgrade);
				AddTypeDecoder<Polkadot.NetApi.Generated.Model.primitive_types.H256>(Call.authorize_upgrade_without_checks);
				AddTypeDecoder<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(Call.apply_authorized_upgrade);
        }
    }
}
