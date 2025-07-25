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
    /// >> 355 - Composite[pallet_dmarket.types.TradeSignatures]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class TradeSignatures : BaseType
    {
        
        /// <summary>
        /// >> ask_signature
        /// </summary>
        public Mythos.NetApi.Generated.Model.account.EthereumSignature AskSignature { get; set; }
        /// <summary>
        /// >> bid_signature
        /// </summary>
        public Mythos.NetApi.Generated.Model.account.EthereumSignature BidSignature { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "TradeSignatures";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(AskSignature.Encode());
            result.AddRange(BidSignature.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            AskSignature = new Mythos.NetApi.Generated.Model.account.EthereumSignature();
            AskSignature.Decode(byteArray, ref p);
            BidSignature = new Mythos.NetApi.Generated.Model.account.EthereumSignature();
            BidSignature.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
