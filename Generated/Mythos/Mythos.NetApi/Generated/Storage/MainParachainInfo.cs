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
    /// >> ParachainInfoStorage
    /// </summary>
    public sealed class ParachainInfoStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> ParachainInfoStorage Constructor
        /// </summary>
        public ParachainInfoStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("ParachainInfo", "ParachainId"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Mythos.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id)));
        }
        
        /// <summary>
        /// >> ParachainIdParams
        /// </summary>
        public static string ParachainIdParams()
        {
            return RequestGenerator.GetStorage("ParachainInfo", "ParachainId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ParachainIdDefault
        /// Default value as hex string
        /// </summary>
        public static string ParachainIdDefault()
        {
            return "0x64000000";
        }
        
        /// <summary>
        /// >> ParachainId
        /// </summary>
        public async Task<Mythos.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id> ParachainId(string blockhash, CancellationToken token)
        {
            string parameters = ParachainInfoStorage.ParachainIdParams();
            var result = await _client.GetStorageAsync<Mythos.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> ParachainInfoCalls
    /// </summary>
    public sealed class ParachainInfoCalls
    {
    }
    
    /// <summary>
    /// >> ParachainInfoConstants
    /// </summary>
    public sealed class ParachainInfoConstants
    {
    }
}
