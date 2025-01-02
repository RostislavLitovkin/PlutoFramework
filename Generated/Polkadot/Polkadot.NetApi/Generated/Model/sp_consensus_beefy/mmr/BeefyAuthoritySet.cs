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


namespace Polkadot.NetApi.Generated.Model.sp_consensus_beefy.mmr
{
    
    
    /// <summary>
    /// >> 841 - Composite[sp_consensus_beefy.mmr.BeefyAuthoritySet]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BeefyAuthoritySet : BaseType
    {
        
        /// <summary>
        /// >> id
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Id { get; set; }
        /// <summary>
        /// >> len
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Len { get; set; }
        /// <summary>
        /// >> keyset_commitment
        /// </summary>
        public Polkadot.NetApi.Generated.Model.primitive_types.H256 KeysetCommitment { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BeefyAuthoritySet";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Len.Encode());
            result.AddRange(KeysetCommitment.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Substrate.NetApi.Model.Types.Primitive.U64();
            Id.Decode(byteArray, ref p);
            Len = new Substrate.NetApi.Model.Types.Primitive.U32();
            Len.Decode(byteArray, ref p);
            KeysetCommitment = new Polkadot.NetApi.Generated.Model.primitive_types.H256();
            KeysetCommitment.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
