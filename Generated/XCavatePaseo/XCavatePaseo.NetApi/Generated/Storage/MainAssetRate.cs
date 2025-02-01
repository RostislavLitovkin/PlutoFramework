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
    /// >> AssetRateStorage
    /// </summary>
    public sealed class AssetRateStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> AssetRateStorage Constructor
        /// </summary>
        public AssetRateStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("AssetRate", "ConversionRateToNative"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substrate.NetApi.Model.Types.Primitive.U16), typeof(XCavatePaseo.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128)));
        }
        
        /// <summary>
        /// >> ConversionRateToNativeParams
        ///  Maps an asset to its fixed point representation in the native balance.
        /// 
        ///  E.g. `native_amount = asset_amount * ConversionRateToNative::<T>::get(asset_kind)`
        /// </summary>
        public static string ConversionRateToNativeParams(Substrate.NetApi.Model.Types.Primitive.U16 key)
        {
            return RequestGenerator.GetStorage("AssetRate", "ConversionRateToNative", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> ConversionRateToNativeDefault
        /// Default value as hex string
        /// </summary>
        public static string ConversionRateToNativeDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> ConversionRateToNative
        ///  Maps an asset to its fixed point representation in the native balance.
        /// 
        ///  E.g. `native_amount = asset_amount * ConversionRateToNative::<T>::get(asset_kind)`
        /// </summary>
        public async Task<XCavatePaseo.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128> ConversionRateToNative(Substrate.NetApi.Model.Types.Primitive.U16 key, string blockhash, CancellationToken token)
        {
            string parameters = AssetRateStorage.ConversionRateToNativeParams(key);
            var result = await _client.GetStorageAsync<XCavatePaseo.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> AssetRateCalls
    /// </summary>
    public sealed class AssetRateCalls
    {
        
        /// <summary>
        /// >> create
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Create(Substrate.NetApi.Model.Types.Primitive.U16 asset_kind, XCavatePaseo.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128 rate)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(asset_kind.Encode());
            byteArray.AddRange(rate.Encode());
            return new Method(77, "AssetRate", 0, "create", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> update
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Update(Substrate.NetApi.Model.Types.Primitive.U16 asset_kind, XCavatePaseo.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128 rate)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(asset_kind.Encode());
            byteArray.AddRange(rate.Encode());
            return new Method(77, "AssetRate", 1, "update", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Remove(Substrate.NetApi.Model.Types.Primitive.U16 asset_kind)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(asset_kind.Encode());
            return new Method(77, "AssetRate", 2, "remove", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> AssetRateConstants
    /// </summary>
    public sealed class AssetRateConstants
    {
    }
    
    /// <summary>
    /// >> AssetRateErrors
    /// </summary>
    public enum AssetRateErrors
    {
        
        /// <summary>
        /// >> UnknownAssetKind
        /// The given asset ID is unknown.
        /// </summary>
        UnknownAssetKind,
        
        /// <summary>
        /// >> AlreadyExists
        /// The given asset ID already has an assigned conversion rate and cannot be re-created.
        /// </summary>
        AlreadyExists,
        
        /// <summary>
        /// >> Overflow
        /// Overflow ocurred when calculating the inverse rate.
        /// </summary>
        Overflow,
    }
}
