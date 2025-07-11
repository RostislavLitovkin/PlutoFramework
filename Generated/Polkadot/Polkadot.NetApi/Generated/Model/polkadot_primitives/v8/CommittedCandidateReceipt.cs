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


namespace Polkadot.NetApi.Generated.Model.polkadot_primitives.v8
{
    
    
    /// <summary>
    /// >> 287 - Composite[polkadot_primitives.v8.CommittedCandidateReceipt]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CommittedCandidateReceipt : BaseType
    {
        
        /// <summary>
        /// >> descriptor
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CandidateDescriptor Descriptor { get; set; }
        /// <summary>
        /// >> commitments
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CandidateCommitments Commitments { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CommittedCandidateReceipt";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Descriptor.Encode());
            result.AddRange(Commitments.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Descriptor = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CandidateDescriptor();
            Descriptor.Decode(byteArray, ref p);
            Commitments = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CandidateCommitments();
            Commitments.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
