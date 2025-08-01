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


namespace BifrostPolkadot.NetApi.Generated.Storage
{
    
    
    /// <summary>
    /// >> AssetRegistryStorage
    /// </summary>
    public sealed class AssetRegistryStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> AssetRegistryStorage Constructor
        /// </summary>
        public AssetRegistryStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRegistry", "NextForeignAssetId"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U32)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRegistry", "NextTokenId"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(null, null, typeof(Substrate.NetApi.Model.Types.Primitive.U8)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRegistry", "CurrencyIdToLocations"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId), typeof(BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRegistry", "LocationToCurrencyIds"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location), typeof(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRegistry", "CurrencyIdToWeights"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId), typeof(BifrostPolkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRegistry", "AssetMetadatas"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumAssetIds), typeof(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.AssetMetadata)));
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRegistry", "CurrencyMetadatas"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, typeof(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId), typeof(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.AssetMetadata)));
        }
        
        /// <summary>
        /// >> NextForeignAssetIdParams
        ///  Next available Foreign AssetId ID.
        /// 
        ///  NextForeignAssetId: ForeignAssetId
        /// </summary>
        public static string NextForeignAssetIdParams()
        {
            return RequestGenerator.GetStorage("AssetRegistry", "NextForeignAssetId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NextForeignAssetIdDefault
        /// Default value as hex string
        /// </summary>
        public static string NextForeignAssetIdDefault()
        {
            return "0x00000000";
        }
        
        /// <summary>
        /// >> NextForeignAssetId
        ///  Next available Foreign AssetId ID.
        /// 
        ///  NextForeignAssetId: ForeignAssetId
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> NextForeignAssetId(string blockhash, CancellationToken token)
        {
            string parameters = AssetRegistryStorage.NextForeignAssetIdParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> NextTokenIdParams
        ///  Next available TokenId ID.
        /// 
        ///  NextTokenId: TokenId
        /// </summary>
        public static string NextTokenIdParams()
        {
            return RequestGenerator.GetStorage("AssetRegistry", "NextTokenId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> NextTokenIdDefault
        /// Default value as hex string
        /// </summary>
        public static string NextTokenIdDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> NextTokenId
        ///  Next available TokenId ID.
        /// 
        ///  NextTokenId: TokenId
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U8> NextTokenId(string blockhash, CancellationToken token)
        {
            string parameters = AssetRegistryStorage.NextTokenIdParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U8>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> CurrencyIdToLocationsParams
        ///  The storages for Locations.
        /// 
        ///  CurrencyIdToLocations: map CurrencyId => Option<Location>
        /// </summary>
        public static string CurrencyIdToLocationsParams(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId key)
        {
            return RequestGenerator.GetStorage("AssetRegistry", "CurrencyIdToLocations", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> CurrencyIdToLocationsDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrencyIdToLocationsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> CurrencyIdToLocations
        ///  The storages for Locations.
        /// 
        ///  CurrencyIdToLocations: map CurrencyId => Option<Location>
        /// </summary>
        public async Task<BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location> CurrencyIdToLocations(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId key, string blockhash, CancellationToken token)
        {
            string parameters = AssetRegistryStorage.CurrencyIdToLocationsParams(key);
            var result = await _client.GetStorageAsync<BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> LocationToCurrencyIdsParams
        ///  The storages for CurrencyIds.
        /// 
        ///  LocationToCurrencyIds: map Location => Option<CurrencyId>
        /// </summary>
        public static string LocationToCurrencyIdsParams(BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location key)
        {
            return RequestGenerator.GetStorage("AssetRegistry", "LocationToCurrencyIds", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> LocationToCurrencyIdsDefault
        /// Default value as hex string
        /// </summary>
        public static string LocationToCurrencyIdsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> LocationToCurrencyIds
        ///  The storages for CurrencyIds.
        /// 
        ///  LocationToCurrencyIds: map Location => Option<CurrencyId>
        /// </summary>
        public async Task<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId> LocationToCurrencyIds(BifrostPolkadot.NetApi.Generated.Model.staging_xcm.v4.location.Location key, string blockhash, CancellationToken token)
        {
            string parameters = AssetRegistryStorage.LocationToCurrencyIdsParams(key);
            var result = await _client.GetStorageAsync<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> CurrencyIdToWeightsParams
        /// </summary>
        public static string CurrencyIdToWeightsParams(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId key)
        {
            return RequestGenerator.GetStorage("AssetRegistry", "CurrencyIdToWeights", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> CurrencyIdToWeightsDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrencyIdToWeightsDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> CurrencyIdToWeights
        /// </summary>
        public async Task<BifrostPolkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight> CurrencyIdToWeights(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId key, string blockhash, CancellationToken token)
        {
            string parameters = AssetRegistryStorage.CurrencyIdToWeightsParams(key);
            var result = await _client.GetStorageAsync<BifrostPolkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> AssetMetadatasParams
        ///  The storages for AssetMetadatas.
        /// 
        ///  AssetMetadatas: map AssetIds => Option<AssetMetadata>
        /// </summary>
        public static string AssetMetadatasParams(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumAssetIds key)
        {
            return RequestGenerator.GetStorage("AssetRegistry", "AssetMetadatas", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> AssetMetadatasDefault
        /// Default value as hex string
        /// </summary>
        public static string AssetMetadatasDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> AssetMetadatas
        ///  The storages for AssetMetadatas.
        /// 
        ///  AssetMetadatas: map AssetIds => Option<AssetMetadata>
        /// </summary>
        public async Task<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.AssetMetadata> AssetMetadatas(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumAssetIds key, string blockhash, CancellationToken token)
        {
            string parameters = AssetRegistryStorage.AssetMetadatasParams(key);
            var result = await _client.GetStorageAsync<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.AssetMetadata>(parameters, blockhash, token);
            return result;
        }
        
        /// <summary>
        /// >> CurrencyMetadatasParams
        ///  The storages for AssetMetadata.
        /// 
        ///  CurrencyMetadatas: map CurrencyId => Option<AssetMetadata>
        /// </summary>
        public static string CurrencyMetadatasParams(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId key)
        {
            return RequestGenerator.GetStorage("AssetRegistry", "CurrencyMetadatas", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> CurrencyMetadatasDefault
        /// Default value as hex string
        /// </summary>
        public static string CurrencyMetadatasDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> CurrencyMetadatas
        ///  The storages for AssetMetadata.
        /// 
        ///  CurrencyMetadatas: map CurrencyId => Option<AssetMetadata>
        /// </summary>
        public async Task<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.AssetMetadata> CurrencyMetadatas(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId key, string blockhash, CancellationToken token)
        {
            string parameters = AssetRegistryStorage.CurrencyMetadatasParams(key);
            var result = await _client.GetStorageAsync<BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.AssetMetadata>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> AssetRegistryCalls
    /// </summary>
    public sealed class AssetRegistryCalls
    {
        
        /// <summary>
        /// >> register_token_metadata
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RegisterTokenMetadata(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.AssetMetadata metadata)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(metadata.Encode());
            return new Method(114, "AssetRegistry", 2, "register_token_metadata", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> register_vtoken_metadata
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RegisterVtokenMetadata(Substrate.NetApi.Model.Types.Primitive.U8 token_id)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(token_id.Encode());
            return new Method(114, "AssetRegistry", 3, "register_vtoken_metadata", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> register_location
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method RegisterLocation(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId currency_id, BifrostPolkadot.NetApi.Generated.Model.xcm.EnumVersionedLocation location, BifrostPolkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight weight)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(currency_id.Encode());
            byteArray.AddRange(location.Encode());
            byteArray.AddRange(weight.Encode());
            return new Method(114, "AssetRegistry", 6, "register_location", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_set_location
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method ForceSetLocation(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId currency_id, BifrostPolkadot.NetApi.Generated.Model.xcm.EnumVersionedLocation location, BifrostPolkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight weight)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(currency_id.Encode());
            byteArray.AddRange(location.Encode());
            byteArray.AddRange(weight.Encode());
            return new Method(114, "AssetRegistry", 7, "force_set_location", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update_currency_metadata
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method UpdateCurrencyMetadata(BifrostPolkadot.NetApi.Generated.Model.bifrost_primitives.currency.EnumCurrencyId currency_id, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> asset_name, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> asset_symbol, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U8> asset_decimals, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U128> asset_minimal_balance)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(currency_id.Encode());
            byteArray.AddRange(asset_name.Encode());
            byteArray.AddRange(asset_symbol.Encode());
            byteArray.AddRange(asset_decimals.Encode());
            byteArray.AddRange(asset_minimal_balance.Encode());
            return new Method(114, "AssetRegistry", 8, "update_currency_metadata", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> AssetRegistryConstants
    /// </summary>
    public sealed class AssetRegistryConstants
    {
    }
    
    /// <summary>
    /// >> AssetRegistryErrors
    /// </summary>
    public enum AssetRegistryErrors
    {
        
        /// <summary>
        /// >> BadLocation
        /// The given location could not be used (e.g. because it cannot be expressed in the
        /// desired version of XCM).
        /// </summary>
        BadLocation,
        
        /// <summary>
        /// >> LocationExisted
        /// Location existed
        /// </summary>
        LocationExisted,
        
        /// <summary>
        /// >> AssetIdNotExists
        /// AssetId not exists
        /// </summary>
        AssetIdNotExists,
        
        /// <summary>
        /// >> AssetIdExisted
        /// AssetId exists
        /// </summary>
        AssetIdExisted,
        
        /// <summary>
        /// >> CurrencyIdNotExists
        /// CurrencyId not exists
        /// </summary>
        CurrencyIdNotExists,
        
        /// <summary>
        /// >> CurrencyIdExisted
        /// CurrencyId exists
        /// </summary>
        CurrencyIdExisted,
    }
}
