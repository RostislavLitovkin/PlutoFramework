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


namespace Mythos.NetApi.Generated.Model.pallet_dmarket.types
{
    
    
    /// <summary>
    /// >> 354 - Composite[pallet_dmarket.types.TradeParams]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class TradeParams : BaseType
    {
        
        /// <summary>
        /// >> price
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Price { get; set; }
        /// <summary>
        /// >> fee
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Fee { get; set; }
        /// <summary>
        /// >> item
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Item { get; set; }
        /// <summary>
        /// >> ask_expiration
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 AskExpiration { get; set; }
        /// <summary>
        /// >> bid_expiration
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 BidExpiration { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "TradeParams";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Price.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(Item.Encode());
            result.AddRange(AskExpiration.Encode());
            result.AddRange(BidExpiration.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Price = new Substrate.NetApi.Model.Types.Primitive.U128();
            Price.Decode(byteArray, ref p);
            Fee = new Substrate.NetApi.Model.Types.Primitive.U128();
            Fee.Decode(byteArray, ref p);
            Item = new Substrate.NetApi.Model.Types.Primitive.U128();
            Item.Decode(byteArray, ref p);
            AskExpiration = new Substrate.NetApi.Model.Types.Primitive.U64();
            AskExpiration.Decode(byteArray, ref p);
            BidExpiration = new Substrate.NetApi.Model.Types.Primitive.U64();
            BidExpiration.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
