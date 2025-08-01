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


namespace Polkadot.NetApi.Generated.Model.polkadot_primitives.vstaging
{
    
    
    /// <summary>
    /// >> 485 - Composite[polkadot_primitives.vstaging.CandidateReceiptV2]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CandidateReceiptV2 : BaseType
    {
        
        /// <summary>
        /// >> descriptor
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.vstaging.CandidateDescriptorV2 Descriptor { get; set; }
        /// <summary>
        /// >> commitments_hash
        /// </summary>
        public Polkadot.NetApi.Generated.Model.primitive_types.H256 CommitmentsHash { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CandidateReceiptV2";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Descriptor.Encode());
            result.AddRange(CommitmentsHash.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Descriptor = new Polkadot.NetApi.Generated.Model.polkadot_primitives.vstaging.CandidateDescriptorV2();
            Descriptor.Decode(byteArray, ref p);
            CommitmentsHash = new Polkadot.NetApi.Generated.Model.primitive_types.H256();
            CommitmentsHash.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
