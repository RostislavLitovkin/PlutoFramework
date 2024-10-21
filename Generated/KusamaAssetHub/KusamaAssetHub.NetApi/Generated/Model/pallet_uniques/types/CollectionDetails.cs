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


namespace KusamaAssetHub.NetApi.Generated.Model.pallet_uniques.types
{
    
    
    /// <summary>
    /// >> 417 - Composite[pallet_uniques.types.CollectionDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CollectionDetails : BaseType
    {
        
        /// <summary>
        /// >> owner
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32 Owner { get; set; }
        /// <summary>
        /// >> issuer
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32 Issuer { get; set; }
        /// <summary>
        /// >> admin
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32 Admin { get; set; }
        /// <summary>
        /// >> freezer
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32 Freezer { get; set; }
        /// <summary>
        /// >> total_deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 TotalDeposit { get; set; }
        /// <summary>
        /// >> free_holding
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool FreeHolding { get; set; }
        /// <summary>
        /// >> items
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Items { get; set; }
        /// <summary>
        /// >> item_metadatas
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 ItemMetadatas { get; set; }
        /// <summary>
        /// >> attributes
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Attributes { get; set; }
        /// <summary>
        /// >> is_frozen
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool IsFrozen { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CollectionDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Owner.Encode());
            result.AddRange(Issuer.Encode());
            result.AddRange(Admin.Encode());
            result.AddRange(Freezer.Encode());
            result.AddRange(TotalDeposit.Encode());
            result.AddRange(FreeHolding.Encode());
            result.AddRange(Items.Encode());
            result.AddRange(ItemMetadatas.Encode());
            result.AddRange(Attributes.Encode());
            result.AddRange(IsFrozen.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Owner = new KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Owner.Decode(byteArray, ref p);
            Issuer = new KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Issuer.Decode(byteArray, ref p);
            Admin = new KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Admin.Decode(byteArray, ref p);
            Freezer = new KusamaAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Freezer.Decode(byteArray, ref p);
            TotalDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            TotalDeposit.Decode(byteArray, ref p);
            FreeHolding = new Substrate.NetApi.Model.Types.Primitive.Bool();
            FreeHolding.Decode(byteArray, ref p);
            Items = new Substrate.NetApi.Model.Types.Primitive.U32();
            Items.Decode(byteArray, ref p);
            ItemMetadatas = new Substrate.NetApi.Model.Types.Primitive.U32();
            ItemMetadatas.Decode(byteArray, ref p);
            Attributes = new Substrate.NetApi.Model.Types.Primitive.U32();
            Attributes.Decode(byteArray, ref p);
            IsFrozen = new Substrate.NetApi.Model.Types.Primitive.Bool();
            IsFrozen.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}