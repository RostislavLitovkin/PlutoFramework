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
    /// >> AuthoritiesNotingStorage
    /// </summary>
    public sealed class AuthoritiesNotingStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> AuthoritiesNotingStorage Constructor
        /// </summary>
        public AuthoritiesNotingStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AuthoritiesNoting", "OrchestratorParaId"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(XcavatePaseo.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AuthoritiesNoting", "Authorities"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Base.BaseVec<XcavatePaseo.NetApi.Generated.Model.nimbus_primitives.nimbus_crypto.Public>)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AuthoritiesNoting", "DidSetOrchestratorAuthorityData"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.Bool)));
        }
        
        /// <summary>
        /// >> OrchestratorParaIdParams
        /// </summary>
        public static string OrchestratorParaIdParams()
        {
            return RequestGenerator.GetStorage("AuthoritiesNoting", "OrchestratorParaId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> OrchestratorParaIdDefault
        /// Default value as hex string
        /// </summary>
        public static string OrchestratorParaIdDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> OrchestratorParaId
        /// </summary>
        public async Task<XcavatePaseo.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id> OrchestratorParaId(string blockhash, CancellationToken token)
        {
            string parameters = AuthoritiesNotingStorage.OrchestratorParaIdParams();
            var result = await _client.GetStorageAsync<XcavatePaseo.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> AuthoritiesParams
        /// </summary>
        public static string AuthoritiesParams()
        {
            return RequestGenerator.GetStorage("AuthoritiesNoting", "Authorities", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> AuthoritiesDefault
        /// Default value as hex string
        /// </summary>
        public static string AuthoritiesDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> Authorities
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<XcavatePaseo.NetApi.Generated.Model.nimbus_primitives.nimbus_crypto.Public>> Authorities(string blockhash, CancellationToken token)
        {
            string parameters = AuthoritiesNotingStorage.AuthoritiesParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<XcavatePaseo.NetApi.Generated.Model.nimbus_primitives.nimbus_crypto.Public>>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> DidSetOrchestratorAuthorityDataParams
        ///  Was the containerAuthorData set?
        /// </summary>
        public static string DidSetOrchestratorAuthorityDataParams()
        {
            return RequestGenerator.GetStorage("AuthoritiesNoting", "DidSetOrchestratorAuthorityData", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> DidSetOrchestratorAuthorityDataDefault
        /// Default value as hex string
        /// </summary>
        public static string DidSetOrchestratorAuthorityDataDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> DidSetOrchestratorAuthorityData
        ///  Was the containerAuthorData set?
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> DidSetOrchestratorAuthorityData(string blockhash, CancellationToken token)
        {
            string parameters = AuthoritiesNotingStorage.DidSetOrchestratorAuthorityDataParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> AuthoritiesNotingCalls
    /// </summary>
    public sealed class AuthoritiesNotingCalls
    {
        
        /// <summary>
        /// >> set_latest_authorities_data
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SetLatestAuthoritiesData(XcavatePaseo.NetApi.Generated.Model.ccp_authorities_noting_inherent.ContainerChainAuthoritiesInherentData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(data.Encode());
            return new Method(50, "AuthoritiesNoting", 0, "set_latest_authorities_data", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_authorities
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SetAuthorities(Substrate.NetApi.Model.Types.Base.BaseVec<XcavatePaseo.NetApi.Generated.Model.nimbus_primitives.nimbus_crypto.Public> authorities)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(authorities.Encode());
            return new Method(50, "AuthoritiesNoting", 1, "set_authorities", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_orchestrator_para_id
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method SetOrchestratorParaId(XcavatePaseo.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id new_para_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(new_para_id.Encode());
            return new Method(50, "AuthoritiesNoting", 2, "set_orchestrator_para_id", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> AuthoritiesNotingConstants
    /// </summary>
    public sealed class AuthoritiesNotingConstants
    {
    }
    
    /// <summary>
    /// >> AuthoritiesNotingErrors
    /// </summary>
    public enum AuthoritiesNotingErrors
    {
        
        /// <summary>
        /// >> FailedReading
        /// The new value for a configuration parameter is invalid.
        /// </summary>
        FailedReading,
        
        /// <summary>
        /// >> FailedDecodingHeader
        /// </summary>
        FailedDecodingHeader,
        
        /// <summary>
        /// >> NoAuthoritiesFound
        /// </summary>
        NoAuthoritiesFound,
    }
}
