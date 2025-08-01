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
    /// >> 455 - Composite[sp_consensus_beefy.ForkVotingProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ForkVotingProof : BaseType
    {
        
        /// <summary>
        /// >> vote
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_consensus_beefy.VoteMessage Vote { get; set; }
        /// <summary>
        /// >> ancestry_proof
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_mmr_primitives.AncestryProof AncestryProof { get; set; }
        /// <summary>
        /// >> header
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_runtime.generic.header.Header Header { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ForkVotingProof";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Vote.Encode());
            result.AddRange(AncestryProof.Encode());
            result.AddRange(Header.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Vote = new Polkadot.NetApi.Generated.Model.sp_consensus_beefy.VoteMessage();
            Vote.Decode(byteArray, ref p);
            AncestryProof = new Polkadot.NetApi.Generated.Model.sp_mmr_primitives.AncestryProof();
            AncestryProof.Decode(byteArray, ref p);
            Header = new Polkadot.NetApi.Generated.Model.sp_runtime.generic.header.Header();
            Header.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
