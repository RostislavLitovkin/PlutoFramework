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


namespace Polkadot.NetApi.Generated.Model.pallet_conviction_voting.vote
{
    
    
    /// <summary>
    /// >> 629 - Composite[pallet_conviction_voting.vote.Casting]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Casting : BaseType
    {
        
        /// <summary>
        /// >> votes
        /// </summary>
        public Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT26 Votes { get; set; }
        /// <summary>
        /// >> delegations
        /// </summary>
        public Polkadot.NetApi.Generated.Model.pallet_conviction_voting.types.Delegations Delegations { get; set; }
        /// <summary>
        /// >> prior
        /// </summary>
        public Polkadot.NetApi.Generated.Model.pallet_conviction_voting.vote.PriorLock Prior { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Casting";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes.Encode());
            result.AddRange(Delegations.Encode());
            result.AddRange(Prior.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes = new Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT26();
            Votes.Decode(byteArray, ref p);
            Delegations = new Polkadot.NetApi.Generated.Model.pallet_conviction_voting.types.Delegations();
            Delegations.Decode(byteArray, ref p);
            Prior = new Polkadot.NetApi.Generated.Model.pallet_conviction_voting.vote.PriorLock();
            Prior.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
