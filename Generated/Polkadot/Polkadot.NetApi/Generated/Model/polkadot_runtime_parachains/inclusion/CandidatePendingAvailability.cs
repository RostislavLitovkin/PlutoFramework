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


namespace Polkadot.NetApi.Generated.Model.polkadot_runtime_parachains.inclusion
{
    
    
    /// <summary>
    /// >> 742 - Composite[polkadot_runtime_parachains.inclusion.CandidatePendingAvailability]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CandidatePendingAvailability : BaseType
    {
        
        /// <summary>
        /// >> core
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CoreIndex Core { get; set; }
        /// <summary>
        /// >> hash
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_core_primitives.CandidateHash Hash { get; set; }
        /// <summary>
        /// >> descriptor
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.vstaging.CandidateDescriptorV2 Descriptor { get; set; }
        /// <summary>
        /// >> commitments
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CandidateCommitments Commitments { get; set; }
        /// <summary>
        /// >> availability_votes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkadot.NetApi.Generated.Model.bitvec.order.Lsb0> AvailabilityVotes { get; set; }
        /// <summary>
        /// >> backers
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkadot.NetApi.Generated.Model.bitvec.order.Lsb0> Backers { get; set; }
        /// <summary>
        /// >> relay_parent_number
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 RelayParentNumber { get; set; }
        /// <summary>
        /// >> backed_in_number
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 BackedInNumber { get; set; }
        /// <summary>
        /// >> backing_group
        /// </summary>
        public Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.GroupIndex BackingGroup { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CandidatePendingAvailability";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Core.Encode());
            result.AddRange(Hash.Encode());
            result.AddRange(Descriptor.Encode());
            result.AddRange(Commitments.Encode());
            result.AddRange(AvailabilityVotes.Encode());
            result.AddRange(Backers.Encode());
            result.AddRange(RelayParentNumber.Encode());
            result.AddRange(BackedInNumber.Encode());
            result.AddRange(BackingGroup.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Core = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CoreIndex();
            Core.Decode(byteArray, ref p);
            Hash = new Polkadot.NetApi.Generated.Model.polkadot_core_primitives.CandidateHash();
            Hash.Decode(byteArray, ref p);
            Descriptor = new Polkadot.NetApi.Generated.Model.polkadot_primitives.vstaging.CandidateDescriptorV2();
            Descriptor.Decode(byteArray, ref p);
            Commitments = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.CandidateCommitments();
            Commitments.Decode(byteArray, ref p);
            AvailabilityVotes = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkadot.NetApi.Generated.Model.bitvec.order.Lsb0>();
            AvailabilityVotes.Decode(byteArray, ref p);
            Backers = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkadot.NetApi.Generated.Model.bitvec.order.Lsb0>();
            Backers.Decode(byteArray, ref p);
            RelayParentNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            RelayParentNumber.Decode(byteArray, ref p);
            BackedInNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            BackedInNumber.Decode(byteArray, ref p);
            BackingGroup = new Polkadot.NetApi.Generated.Model.polkadot_primitives.v8.GroupIndex();
            BackingGroup.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
