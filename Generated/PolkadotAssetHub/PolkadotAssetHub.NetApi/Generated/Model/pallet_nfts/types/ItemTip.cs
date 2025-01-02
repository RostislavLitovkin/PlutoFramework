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


namespace PolkadotAssetHub.NetApi.Generated.Model.pallet_nfts.types
{
    
    
    /// <summary>
    /// >> 372 - Composite[pallet_nfts.types.ItemTip]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ItemTip : BaseType
    {
        
        /// <summary>
        /// >> collection
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Collection { get; set; }
        /// <summary>
        /// >> item
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Item { get; set; }
        /// <summary>
        /// >> receiver
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32 Receiver { get; set; }
        /// <summary>
        /// >> amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Amount { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ItemTip";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Collection.Encode());
            result.AddRange(Item.Encode());
            result.AddRange(Receiver.Encode());
            result.AddRange(Amount.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Collection = new Substrate.NetApi.Model.Types.Primitive.U32();
            Collection.Decode(byteArray, ref p);
            Item = new Substrate.NetApi.Model.Types.Primitive.U32();
            Item.Decode(byteArray, ref p);
            Receiver = new PolkadotAssetHub.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Receiver.Decode(byteArray, ref p);
            Amount = new Substrate.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
