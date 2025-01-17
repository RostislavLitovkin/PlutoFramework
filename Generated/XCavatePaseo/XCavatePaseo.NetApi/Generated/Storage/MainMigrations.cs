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


namespace XCavatePaseo.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> MigrationsStorage
    /// </summary>
    public sealed class MigrationsStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> MigrationsStorage Constructor
        /// </summary>
        public MigrationsStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Migrations", "FullyUpgraded"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.Bool)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Migrations", "MigrationState"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>), typeof(Substrate.NetApi.Model.Types.Primitive.Bool)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("Migrations", "ShouldPauseXcm"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.Bool)));
        }
        
        /// <summary>
        /// >> FullyUpgradedParams
        ///  True if all required migrations have completed
        /// </summary>
        public static string FullyUpgradedParams()
        {
            return RequestGenerator.GetStorage("Migrations", "FullyUpgraded", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> FullyUpgradedDefault
        /// Default value as hex string
        /// </summary>
        public static string FullyUpgradedDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> FullyUpgraded
        ///  True if all required migrations have completed
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> FullyUpgraded(string blockhash, CancellationToken token)
        {
            string parameters = MigrationsStorage.FullyUpgradedParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> MigrationStateParams
        ///  MigrationState tracks the progress of a migration.
        ///  Maps name (Vec<u8>) -> whether or not migration has been completed (bool)
        /// </summary>
        public static string MigrationStateParams(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> key)
        {
            return RequestGenerator.GetStorage("Migrations", "MigrationState", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> MigrationStateDefault
        /// Default value as hex string
        /// </summary>
        public static string MigrationStateDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> MigrationState
        ///  MigrationState tracks the progress of a migration.
        ///  Maps name (Vec<u8>) -> whether or not migration has been completed (bool)
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> MigrationState(Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> key, string blockhash, CancellationToken token)
        {
            string parameters = MigrationsStorage.MigrationStateParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> ShouldPauseXcmParams
        ///  Temporary value that is set to true at the beginning of the block during which the execution
        ///  of xcm messages must be paused.
        /// </summary>
        public static string ShouldPauseXcmParams()
        {
            return RequestGenerator.GetStorage("Migrations", "ShouldPauseXcm", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> ShouldPauseXcmDefault
        /// Default value as hex string
        /// </summary>
        public static string ShouldPauseXcmDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ShouldPauseXcm
        ///  Temporary value that is set to true at the beginning of the block during which the execution
        ///  of xcm messages must be paused.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.Bool> ShouldPauseXcm(string blockhash, CancellationToken token)
        {
            string parameters = MigrationsStorage.ShouldPauseXcmParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.Bool>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> MigrationsCalls
    /// </summary>
    public sealed class MigrationsCalls
    {
    }
    
    /// <summary>
    /// >> MigrationsConstants
    /// </summary>
    public sealed class MigrationsConstants
    {
    }
    
    /// <summary>
    /// >> MigrationsErrors
    /// </summary>
    public enum MigrationsErrors
    {
        
        /// <summary>
        /// >> PreimageMissing
        /// Missing preimage in original democracy storage
        /// </summary>
        PreimageMissing,
        
        /// <summary>
        /// >> WrongUpperBound
        /// Provided upper bound is too low.
        /// </summary>
        WrongUpperBound,
        
        /// <summary>
        /// >> PreimageIsTooBig
        /// Preimage is larger than the new max size.
        /// </summary>
        PreimageIsTooBig,
        
        /// <summary>
        /// >> PreimageAlreadyExists
        /// Preimage already exists in the new storage.
        /// </summary>
        PreimageAlreadyExists,
    }
}
