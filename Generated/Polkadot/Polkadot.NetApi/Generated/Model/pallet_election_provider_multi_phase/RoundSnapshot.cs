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


namespace Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase
{
    
    
    /// <summary>
    /// >> 687 - Composite[pallet_election_provider_multi_phase.RoundSnapshot]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RoundSnapshot : BaseType
    {
        
        /// <summary>
        /// >> voters
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U64, Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT24>> Voters { get; set; }
        /// <summary>
        /// >> targets
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32> Targets { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "RoundSnapshot";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Voters.Encode());
            result.AddRange(Targets.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Voters = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U64, Polkadot.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT24>>();
            Voters.Decode(byteArray, ref p);
            Targets = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32>();
            Targets.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
