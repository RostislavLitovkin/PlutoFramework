//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Mythos.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> ProxyStorage
    /// </summary>
    public sealed class ProxyStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> ProxyStorage Constructor
        /// </summary>
        public ProxyStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Proxy", "Proxies"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Mythos.NetApi.Generated.Model.account.AccountId20), typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT25, Substrate.NetApi.Model.Types.Primitive.U128>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Proxy", "Announcements"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Mythos.NetApi.Generated.Model.account.AccountId20), typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT26, Substrate.NetApi.Model.Types.Primitive.U128>)));
        }
        
        /// <summary>
        /// >> ProxiesParams
        ///  The set of account proxies. Maps the account which has delegated to the accounts
        ///  which are being delegated to, together with the amount held on deposit.
        /// </summary>
        public static string ProxiesParams(Mythos.NetApi.Generated.Model.account.AccountId20 key)
        {
            return RequestGenerator.GetStorage("Proxy", "Proxies", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ProxiesDefault
        /// Default value as hex string
        /// </summary>
        public static string ProxiesDefault()
        {
            return "0x0000000000000000000000000000000000";
        }
        
        /// <summary>
        /// >> Proxies
        ///  The set of account proxies. Maps the account which has delegated to the accounts
        ///  which are being delegated to, together with the amount held on deposit.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT25, Substrate.NetApi.Model.Types.Primitive.U128>> Proxies(Mythos.NetApi.Generated.Model.account.AccountId20 key, string blockhash, CancellationToken token)
        {
            string parameters = ProxyStorage.ProxiesParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT25, Substrate.NetApi.Model.Types.Primitive.U128>>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> AnnouncementsParams
        ///  The announcements made by the proxy (key).
        /// </summary>
        public static string AnnouncementsParams(Mythos.NetApi.Generated.Model.account.AccountId20 key)
        {
            return RequestGenerator.GetStorage("Proxy", "Announcements", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> AnnouncementsDefault
        /// Default value as hex string
        /// </summary>
        public static string AnnouncementsDefault()
        {
            return "0x0000000000000000000000000000000000";
        }
        
        /// <summary>
        /// >> Announcements
        ///  The announcements made by the proxy (key).
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseTuple<Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT26, Substrate.NetApi.Model.Types.Primitive.U128>> Announcements(Mythos.NetApi.Generated.Model.account.AccountId20 key, string blockhash, CancellationToken token)
        {
            string parameters = ProxyStorage.AnnouncementsParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseTuple<Mythos.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT26, Substrate.NetApi.Model.Types.Primitive.U128>>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> ProxyCalls
    /// </summary>
    public sealed class ProxyCalls
    {
        
        /// <summary>
        /// >> proxy
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Proxy(Mythos.NetApi.Generated.Model.account.AccountId20 real, Substrate.NetApi.Model.Types.Base.BaseOpt<Mythos.NetApi.Generated.Model.mainnet_runtime.EnumProxyType> force_proxy_type, Mythos.NetApi.Generated.Model.mainnet_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(force_proxy_type.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(40, "Proxy", 0, "proxy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_proxy
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method AddProxy(Mythos.NetApi.Generated.Model.account.AccountId20 @delegate, Mythos.NetApi.Generated.Model.mainnet_runtime.EnumProxyType proxy_type, Substrate.NetApi.Model.Types.Primitive.U32 delay)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(delay.Encode());
            return new Method(40, "Proxy", 1, "add_proxy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_proxy
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RemoveProxy(Mythos.NetApi.Generated.Model.account.AccountId20 @delegate, Mythos.NetApi.Generated.Model.mainnet_runtime.EnumProxyType proxy_type, Substrate.NetApi.Model.Types.Primitive.U32 delay)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(delay.Encode());
            return new Method(40, "Proxy", 2, "remove_proxy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_proxies
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RemoveProxies()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(40, "Proxy", 3, "remove_proxies", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> create_pure
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method CreatePure(Mythos.NetApi.Generated.Model.mainnet_runtime.EnumProxyType proxy_type, Substrate.NetApi.Model.Types.Primitive.U32 delay, Substrate.NetApi.Model.Types.Primitive.U16 index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(delay.Encode());
            byteArray.AddRange(index.Encode());
            return new Method(40, "Proxy", 4, "create_pure", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> kill_pure
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method KillPure(Mythos.NetApi.Generated.Model.account.AccountId20 spawner, Mythos.NetApi.Generated.Model.mainnet_runtime.EnumProxyType proxy_type, Substrate.NetApi.Model.Types.Primitive.U16 index, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> height, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> ext_index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(spawner.Encode());
            byteArray.AddRange(proxy_type.Encode());
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(height.Encode());
            byteArray.AddRange(ext_index.Encode());
            return new Method(40, "Proxy", 5, "kill_pure", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> announce
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Announce(Mythos.NetApi.Generated.Model.account.AccountId20 real, Mythos.NetApi.Generated.Model.primitive_types.H256 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(40, "Proxy", 6, "announce", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_announcement
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RemoveAnnouncement(Mythos.NetApi.Generated.Model.account.AccountId20 real, Mythos.NetApi.Generated.Model.primitive_types.H256 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(40, "Proxy", 7, "remove_announcement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> reject_announcement
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RejectAnnouncement(Mythos.NetApi.Generated.Model.account.AccountId20 @delegate, Mythos.NetApi.Generated.Model.primitive_types.H256 call_hash)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(call_hash.Encode());
            return new Method(40, "Proxy", 8, "reject_announcement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> proxy_announced
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ProxyAnnounced(Mythos.NetApi.Generated.Model.account.AccountId20 @delegate, Mythos.NetApi.Generated.Model.account.AccountId20 real, Substrate.NetApi.Model.Types.Base.BaseOpt<Mythos.NetApi.Generated.Model.mainnet_runtime.EnumProxyType> force_proxy_type, Mythos.NetApi.Generated.Model.mainnet_runtime.EnumRuntimeCall call)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(@delegate.Encode());
            byteArray.AddRange(real.Encode());
            byteArray.AddRange(force_proxy_type.Encode());
            byteArray.AddRange(call.Encode());
            return new Method(40, "Proxy", 9, "proxy_announced", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> ProxyConstants
    /// </summary>
    public sealed class ProxyConstants
    {
        
        /// <summary>
        /// >> ProxyDepositBase
        ///  The base amount of currency needed to reserve for creating a proxy.
        /// 
        ///  This is held for an additional storage item whose value size is
        ///  `sizeof(Balance)` bytes and whose key size is `sizeof(AccountId)` bytes.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ProxyDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00803C603792C6020000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> ProxyDepositFactor
        ///  The amount of currency needed per proxy added.
        /// 
        ///  This is held for adding 32 bytes plus an instance of `ProxyType` more into a
        ///  pre-existing storage value. Thus, when configuring `ProxyDepositFactor` one should take
        ///  into account `32 + proxy_type.encode().len()` bytes of data.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 ProxyDepositFactor()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00104769031E00000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxProxies
        ///  The maximum amount of proxies allowed for a single account.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxProxies()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x20000000");
            return result;
        }
        
        /// <summary>
        /// >> MaxPending
        ///  The maximum amount of time-delayed announcements that are allowed to be pending.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxPending()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x20000000");
            return result;
        }
        
        /// <summary>
        /// >> AnnouncementDepositBase
        ///  The base amount of currency needed to reserve for creating an announcement.
        /// 
        ///  This is held when a new storage item holding a `Balance` is created (typically 16
        ///  bytes).
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 AnnouncementDepositBase()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00803C603792C6020000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> AnnouncementDepositFactor
        ///  The amount of currency needed per announcement made.
        /// 
        ///  This is held for adding an `AccountId`, `Hash` and `BlockNumber` (typically 68 bytes)
        ///  into a pre-existing storage value.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 AnnouncementDepositFactor()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00208ED2063C00000000000000000000");
            return result;
        }
    }
    
    /// <summary>
    /// >> ProxyErrors
    /// </summary>
    public enum ProxyErrors
    {
        
        /// <summary>
        /// >> TooMany
        /// There are too many proxies registered or too many announcements pending.
        /// </summary>
        TooMany,
        
        /// <summary>
        /// >> NotFound
        /// Proxy registration not found.
        /// </summary>
        NotFound,
        
        /// <summary>
        /// >> NotProxy
        /// Sender is not a proxy of the account to be proxied.
        /// </summary>
        NotProxy,
        
        /// <summary>
        /// >> Unproxyable
        /// A call which is incompatible with the proxy type's filter was attempted.
        /// </summary>
        Unproxyable,
        
        /// <summary>
        /// >> Duplicate
        /// Account is already a proxy.
        /// </summary>
        Duplicate,
        
        /// <summary>
        /// >> NoPermission
        /// Call may not be made by proxy because it may escalate its privileges.
        /// </summary>
        NoPermission,
        
        /// <summary>
        /// >> Unannounced
        /// Announcement, if made at all, was made too recently.
        /// </summary>
        Unannounced,
        
        /// <summary>
        /// >> NoSelfProxy
        /// Cannot add self as proxy.
        /// </summary>
        NoSelfProxy,
    }
}
