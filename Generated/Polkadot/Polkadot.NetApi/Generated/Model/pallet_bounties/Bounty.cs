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


namespace Polkadot.NetApi.Generated.Model.pallet_bounties
{
    
    
    /// <summary>
    /// >> 661 - Composite[pallet_bounties.Bounty]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Bounty : BaseType
    {
        
        /// <summary>
        /// >> proposer
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32 Proposer { get; set; }
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Value { get; set; }
        /// <summary>
        /// >> fee
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Fee { get; set; }
        /// <summary>
        /// >> curator_deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CuratorDeposit { get; set; }
        /// <summary>
        /// >> bond
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Bond { get; set; }
        /// <summary>
        /// >> status
        /// </summary>
        public Polkadot.NetApi.Generated.Model.pallet_bounties.EnumBountyStatus Status { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Bounty";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Proposer.Encode());
            result.AddRange(Value.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(CuratorDeposit.Encode());
            result.AddRange(Bond.Encode());
            result.AddRange(Status.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Proposer = new Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Proposer.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Primitive.U128();
            Value.Decode(byteArray, ref p);
            Fee = new Substrate.NetApi.Model.Types.Primitive.U128();
            Fee.Decode(byteArray, ref p);
            CuratorDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            CuratorDeposit.Decode(byteArray, ref p);
            Bond = new Substrate.NetApi.Model.Types.Primitive.U128();
            Bond.Decode(byteArray, ref p);
            Status = new Polkadot.NetApi.Generated.Model.pallet_bounties.EnumBountyStatus();
            Status.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
