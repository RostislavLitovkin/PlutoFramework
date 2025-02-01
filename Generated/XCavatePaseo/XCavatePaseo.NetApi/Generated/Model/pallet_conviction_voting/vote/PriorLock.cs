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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_conviction_voting.vote
{
    
    
    /// <summary>
    /// >> 422 - Composite[pallet_conviction_voting.vote.PriorLock]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PriorLock : BaseType
    {
        
        /// <summary>
        /// >> BlockNumber
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 BlockNumber { get; set; }
        /// <summary>
        /// >> Balance
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Balance { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PriorLock";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BlockNumber.Encode());
            result.AddRange(Balance.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BlockNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            BlockNumber.Decode(byteArray, ref p);
            Balance = new Substrate.NetApi.Model.Types.Primitive.U128();
            Balance.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
