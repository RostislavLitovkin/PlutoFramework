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
    /// >> 536 - Composite[pallet_nft_marketplace.pallet.TokenOwnerDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class TokenOwnerDetails : BaseType
    {
        
        /// <summary>
        /// >> token_amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TokenAmount { get; set; }
        /// <summary>
        /// >> paid_funds
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 PaidFunds { get; set; }
        /// <summary>
        /// >> paid_tax
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 PaidTax { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "TokenOwnerDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TokenAmount.Encode());
            result.AddRange(PaidFunds.Encode());
            result.AddRange(PaidTax.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TokenAmount = new Substrate.NetApi.Model.Types.Primitive.U32();
            TokenAmount.Decode(byteArray, ref p);
            PaidFunds = new Substrate.NetApi.Model.Types.Primitive.U128();
            PaidFunds.Decode(byteArray, ref p);
            PaidTax = new Substrate.NetApi.Model.Types.Primitive.U128();
            PaidTax.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
