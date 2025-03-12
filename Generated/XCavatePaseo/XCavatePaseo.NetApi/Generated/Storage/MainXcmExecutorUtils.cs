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


namespace XcavatePaseo.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> XcmExecutorUtilsStorage
    /// </summary>
    public sealed class XcmExecutorUtilsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> XcmExecutorUtilsStorage Constructor
        /// </summary>
        public XcmExecutorUtilsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmExecutorUtils", "ReservePolicy"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location), typeof(XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("XcmExecutorUtils", "TeleportPolicy"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location), typeof(XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy)));
        }
        
        /// <summary>
        /// >> ReservePolicyParams
        /// </summary>
        public static string ReservePolicyParams(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location key)
        {
            return RequestGenerator.GetStorage("XcmExecutorUtils", "ReservePolicy", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ReservePolicyDefault
        /// Default value as hex string
        /// </summary>
        public static string ReservePolicyDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ReservePolicy
        /// </summary>
        public async Task<XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy> ReservePolicy(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location key, string blockhash, CancellationToken token)
        {
            string parameters = XcmExecutorUtilsStorage.ReservePolicyParams(key);
            var result = await _client.GetStorageAsync<XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> TeleportPolicyParams
        /// </summary>
        public static string TeleportPolicyParams(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location key)
        {
            return RequestGenerator.GetStorage("XcmExecutorUtils", "TeleportPolicy", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> TeleportPolicyDefault
        /// Default value as hex string
        /// </summary>
        public static string TeleportPolicyDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> TeleportPolicy
        /// </summary>
        public async Task<XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy> TeleportPolicy(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location key, string blockhash, CancellationToken token)
        {
            string parameters = XcmExecutorUtilsStorage.TeleportPolicyParams(key);
            var result = await _client.GetStorageAsync<XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> XcmExecutorUtilsCalls
    /// </summary>
    public sealed class XcmExecutorUtilsCalls
    {
        
        /// <summary>
        /// >> set_reserve_policy
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SetReservePolicy(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location origin_location, XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy policy)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(origin_location.Encode());
            byteArray.AddRange(policy.Encode());
            return new Method(78, "XcmExecutorUtils", 0, "set_reserve_policy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_reserve_policy
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RemoveReservePolicy(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location origin_location)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(origin_location.Encode());
            return new Method(78, "XcmExecutorUtils", 1, "remove_reserve_policy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_teleport_policy
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SetTeleportPolicy(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location origin_location, XcavatePaseo.NetApi.Generated.Model.pallet_xcm_executor_utils.pallet.EnumTrustPolicy policy)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(origin_location.Encode());
            byteArray.AddRange(policy.Encode());
            return new Method(78, "XcmExecutorUtils", 2, "set_teleport_policy", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_teleport_policy
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RemoveTeleportPolicy(XcavatePaseo.NetApi.Generated.Model.staging_xcm.v4.location.Location origin_location)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(origin_location.Encode());
            return new Method(78, "XcmExecutorUtils", 3, "remove_teleport_policy", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> XcmExecutorUtilsConstants
    /// </summary>
    public sealed class XcmExecutorUtilsConstants
    {
    }
    
    /// <summary>
    /// >> XcmExecutorUtilsErrors
    /// </summary>
    public enum XcmExecutorUtilsErrors
    {
        
        /// <summary>
        /// >> NotValidOrigin
        /// </summary>
        NotValidOrigin,
    }
}
