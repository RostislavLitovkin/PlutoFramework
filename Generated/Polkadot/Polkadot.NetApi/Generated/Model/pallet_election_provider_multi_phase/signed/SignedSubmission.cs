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


namespace Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase.signed
{
    
    
    /// <summary>
    /// >> 676 - Composite[pallet_election_provider_multi_phase.signed.SignedSubmission]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SignedSubmission : BaseType
    {
        
        /// <summary>
        /// >> who
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32 Who { get; set; }
        /// <summary>
        /// >> deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit { get; set; }
        /// <summary>
        /// >> raw_solution
        /// </summary>
        public Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase.RawSolution RawSolution { get; set; }
        /// <summary>
        /// >> call_fee
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 CallFee { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "SignedSubmission";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(RawSolution.Encode());
            result.AddRange(CallFee.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new Polkadot.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            RawSolution = new Polkadot.NetApi.Generated.Model.pallet_election_provider_multi_phase.RawSolution();
            RawSolution.Decode(byteArray, ref p);
            CallFee = new Substrate.NetApi.Model.Types.Primitive.U128();
            CallFee.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
