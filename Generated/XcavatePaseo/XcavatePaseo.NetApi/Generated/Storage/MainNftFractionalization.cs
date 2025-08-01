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
    /// >> NftFractionalizationStorage
    /// </summary>
    public sealed class NftFractionalizationStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateClientExt _client;
        
        /// <summary>
        /// >> NftFractionalizationStorage Constructor
        /// </summary>
        public NftFractionalizationStorage(SubstrateClientExt client)
        {
            this._client = client;
            _client.StorageKeyDict.Add(new System.Tuple<string, string>("NftFractionalization", "NftToAsset"), new System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>(new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                            Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, typeof(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>), typeof(XcavatePaseo.NetApi.Generated.Model.pallet_nft_fractionalization.types.Details)));
        }
        
        /// <summary>
        /// >> NftToAssetParams
        ///  Keeps track of the corresponding NFT ID, asset ID and amount minted.
        /// </summary>
        public static string NftToAssetParams(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> key)
        {
            return RequestGenerator.GetStorage("NftFractionalization", "NftToAsset", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] {
                        Substrate.NetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new Substrate.NetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> NftToAssetDefault
        /// Default value as hex string
        /// </summary>
        public static string NftToAssetDefault()
        {
            return "0x00";
        }
        
        /// <summary>
        /// >> NftToAsset
        ///  Keeps track of the corresponding NFT ID, asset ID and amount minted.
        /// </summary>
        public async Task<XcavatePaseo.NetApi.Generated.Model.pallet_nft_fractionalization.types.Details> NftToAsset(Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32> key, string blockhash, CancellationToken token)
        {
            string parameters = NftFractionalizationStorage.NftToAssetParams(key);
            var result = await _client.GetStorageAsync<XcavatePaseo.NetApi.Generated.Model.pallet_nft_fractionalization.types.Details>(parameters, blockhash, token);
            return result;
        }
    }
    
    /// <summary>
    /// >> NftFractionalizationCalls
    /// </summary>
    public sealed class NftFractionalizationCalls
    {
        
        /// <summary>
        /// >> fractionalize
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Fractionalize(Substrate.NetApi.Model.Types.Primitive.U32 nft_collection_id, Substrate.NetApi.Model.Types.Primitive.U32 nft_id, Substrate.NetApi.Model.Types.Primitive.U32 asset_id, XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress beneficiary, Substrate.NetApi.Model.Types.Primitive.U128 fractions)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(nft_collection_id.Encode());
            byteArray.AddRange(nft_id.Encode());
            byteArray.AddRange(asset_id.Encode());
            byteArray.AddRange(beneficiary.Encode());
            byteArray.AddRange(fractions.Encode());
            return new Method(19, "NftFractionalization", 0, "fractionalize", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> unify
        /// Contains a variant per dispatchable extrinsic that this pallet has.
        /// </summary>
        public static Method Unify(Substrate.NetApi.Model.Types.Primitive.U32 nft_collection_id, Substrate.NetApi.Model.Types.Primitive.U32 nft_id, Substrate.NetApi.Model.Types.Primitive.U32 asset_id, XcavatePaseo.NetApi.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress beneficiary)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(nft_collection_id.Encode());
            byteArray.AddRange(nft_id.Encode());
            byteArray.AddRange(asset_id.Encode());
            byteArray.AddRange(beneficiary.Encode());
            return new Method(19, "NftFractionalization", 1, "unify", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> NftFractionalizationConstants
    /// </summary>
    public sealed class NftFractionalizationConstants
    {
        
        /// <summary>
        /// >> Deposit
        ///  The deposit paid by the user locking an NFT. The deposit is returned to the original NFT
        ///  owner when the asset is unified and the NFT is unlocked.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x0010A5D4E80000000000000000000000");
            return result;
        }
        
        /// <summary>
        /// >> PalletId
        ///  The pallet's id, used for deriving its sovereign account ID.
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.frame_support.PalletId PalletId()
        {
            var result = new XcavatePaseo.NetApi.Generated.Model.frame_support.PalletId();
            result.Create("0x6672616374696F6E");
            return result;
        }
        
        /// <summary>
        /// >> NewAssetSymbol
        ///  The newly created asset's symbol.
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT2 NewAssetSymbol()
        {
            var result = new XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT2();
            result.Create("0x1042524958");
            return result;
        }
        
        /// <summary>
        /// >> NewAssetName
        ///  The newly created asset's name.
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT2 NewAssetName()
        {
            var result = new XcavatePaseo.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT2();
            result.Create("0x1042726978");
            return result;
        }
        
        /// <summary>
        /// >> StringLimit
        ///  The maximum length of a name or symbol stored on-chain.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 StringLimit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x88130000");
            return result;
        }
    }
    
    /// <summary>
    /// >> NftFractionalizationErrors
    /// </summary>
    public enum NftFractionalizationErrors
    {
        
        /// <summary>
        /// >> IncorrectAssetId
        /// Asset ID does not correspond to locked NFT.
        /// </summary>
        IncorrectAssetId,
        
        /// <summary>
        /// >> NoPermission
        /// The signing account has no permission to do the operation.
        /// </summary>
        NoPermission,
        
        /// <summary>
        /// >> NftNotFound
        /// NFT doesn't exist.
        /// </summary>
        NftNotFound,
        
        /// <summary>
        /// >> NftNotFractionalized
        /// NFT has not yet been fractionalised.
        /// </summary>
        NftNotFractionalized,
    }
}
