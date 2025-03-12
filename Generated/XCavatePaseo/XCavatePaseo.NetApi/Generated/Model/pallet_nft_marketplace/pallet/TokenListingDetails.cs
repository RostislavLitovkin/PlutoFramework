//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.Base;
using System.Collections.Generic;


namespace XcavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.pallet
{
    
    
    /// <summary>
    /// >> 493 - Composite[pallet_nft_marketplace.pallet.TokenListingDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class TokenListingDetails : BaseType
    {
        
        /// <summary>
        /// >> seller
        /// </summary>
        public XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 Seller { get; set; }
        /// <summary>
        /// >> token_price
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TokenPrice { get; set; }
        /// <summary>
        /// >> asset_id
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 AssetId { get; set; }
        /// <summary>
        /// >> item_id
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ItemId { get; set; }
        /// <summary>
        /// >> collection_id
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 CollectionId { get; set; }
        /// <summary>
        /// >> amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Amount { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "TokenListingDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Seller.Encode());
            result.AddRange(TokenPrice.Encode());
            result.AddRange(AssetId.Encode());
            result.AddRange(ItemId.Encode());
            result.AddRange(CollectionId.Encode());
            result.AddRange(Amount.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Seller = new XcavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Seller.Decode(byteArray, ref p);
            TokenPrice = new Substrate.NetApi.Model.Types.Primitive.U128();
            TokenPrice.Decode(byteArray, ref p);
            AssetId = new Substrate.NetApi.Model.Types.Primitive.U32();
            AssetId.Decode(byteArray, ref p);
            ItemId = new Substrate.NetApi.Model.Types.Primitive.U32();
            ItemId.Decode(byteArray, ref p);
            CollectionId = new Substrate.NetApi.Model.Types.Primitive.U32();
            CollectionId.Decode(byteArray, ref p);
            Amount = new Substrate.NetApi.Model.Types.Primitive.U32();
            Amount.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
