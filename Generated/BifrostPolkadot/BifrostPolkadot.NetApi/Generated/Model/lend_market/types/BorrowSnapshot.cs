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


namespace BifrostPolkadot.NetApi.Generated.Model.lend_market.types
{
    
    
    /// <summary>
    /// >> 1005 - Composite[lend_market.types.BorrowSnapshot]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BorrowSnapshot : BaseType
    {
        
        /// <summary>
        /// >> principal
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Principal { get; set; }
        /// <summary>
        /// >> borrow_index
        /// </summary>
        public BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128 BorrowIndex { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BorrowSnapshot";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Principal.Encode());
            result.AddRange(BorrowIndex.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Principal = new Substrate.NetApi.Model.Types.Primitive.U128();
            Principal.Decode(byteArray, ref p);
            BorrowIndex = new BifrostPolkadot.NetApi.Generated.Model.sp_arithmetic.fixed_point.FixedU128();
            BorrowIndex.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
