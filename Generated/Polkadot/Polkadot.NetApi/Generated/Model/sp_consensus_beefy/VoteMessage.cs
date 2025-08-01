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


namespace Polkadot.NetApi.Generated.Model.sp_consensus_beefy
{
    
    
    /// <summary>
    /// >> 449 - Composite[sp_consensus_beefy.VoteMessage]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class VoteMessage : BaseType
    {
        
        /// <summary>
        /// >> commitment
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_consensus_beefy.commitment.Commitment Commitment { get; set; }
        /// <summary>
        /// >> id
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_consensus_beefy.ecdsa_crypto.Public Id { get; set; }
        /// <summary>
        /// >> signature
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_consensus_beefy.ecdsa_crypto.Signature Signature { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "VoteMessage";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Commitment.Encode());
            result.AddRange(Id.Encode());
            result.AddRange(Signature.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Commitment = new Polkadot.NetApi.Generated.Model.sp_consensus_beefy.commitment.Commitment();
            Commitment.Decode(byteArray, ref p);
            Id = new Polkadot.NetApi.Generated.Model.sp_consensus_beefy.ecdsa_crypto.Public();
            Id.Decode(byteArray, ref p);
            Signature = new Polkadot.NetApi.Generated.Model.sp_consensus_beefy.ecdsa_crypto.Signature();
            Signature.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
