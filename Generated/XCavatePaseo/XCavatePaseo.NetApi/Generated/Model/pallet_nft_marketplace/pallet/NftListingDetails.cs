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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_nft_marketplace.pallet
{
    
    
    /// <summary>
    /// >> 534 - Composite[pallet_nft_marketplace.pallet.NftListingDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class NftListingDetails : BaseType
    {
        
        /// <summary>
        /// >> real_estate_developer
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32 RealEstateDeveloper { get; set; }
        /// <summary>
        /// >> token_price
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TokenPrice { get; set; }
        /// <summary>
        /// >> collected_funds
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CollectedFunds { get; set; }
        /// <summary>
        /// >> collected_tax
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CollectedTax { get; set; }
        /// <summary>
        /// >> collected_fees
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CollectedFees { get; set; }
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
        /// >> token_amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TokenAmount { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "NftListingDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RealEstateDeveloper.Encode());
            result.AddRange(TokenPrice.Encode());
            result.AddRange(CollectedFunds.Encode());
            result.AddRange(CollectedTax.Encode());
            result.AddRange(CollectedFees.Encode());
            result.AddRange(AssetId.Encode());
            result.AddRange(ItemId.Encode());
            result.AddRange(CollectionId.Encode());
            result.AddRange(TokenAmount.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            RealEstateDeveloper = new XCavatePaseo.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            RealEstateDeveloper.Decode(byteArray, ref p);
            TokenPrice = new Substrate.NetApi.Model.Types.Primitive.U128();
            TokenPrice.Decode(byteArray, ref p);
            CollectedFunds = new Substrate.NetApi.Model.Types.Primitive.U128();
            CollectedFunds.Decode(byteArray, ref p);
            CollectedTax = new Substrate.NetApi.Model.Types.Primitive.U128();
            CollectedTax.Decode(byteArray, ref p);
            CollectedFees = new Substrate.NetApi.Model.Types.Primitive.U128();
            CollectedFees.Decode(byteArray, ref p);
            AssetId = new Substrate.NetApi.Model.Types.Primitive.U32();
            AssetId.Decode(byteArray, ref p);
            ItemId = new Substrate.NetApi.Model.Types.Primitive.U32();
            ItemId.Decode(byteArray, ref p);
            CollectionId = new Substrate.NetApi.Model.Types.Primitive.U32();
            CollectionId.Decode(byteArray, ref p);
            TokenAmount = new Substrate.NetApi.Model.Types.Primitive.U32();
            TokenAmount.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
