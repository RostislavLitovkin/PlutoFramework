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


namespace Hydration.NetApi.Generated.Model.pallet_elections_phragmen
{
    
    
    /// <summary>
    /// >> 577 - Composite[pallet_elections_phragmen.Voter]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Voter : BaseType
    {
        
        /// <summary>
        /// >> votes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32> Votes { get; set; }
        /// <summary>
        /// >> stake
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Stake { get; set; }
        /// <summary>
        /// >> deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Voter";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes.Encode());
            result.AddRange(Stake.Encode());
            result.AddRange(Deposit.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes = new Substrate.NetApi.Model.Types.Base.BaseVec<Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32>();
            Votes.Decode(byteArray, ref p);
            Stake = new Substrate.NetApi.Model.Types.Primitive.U128();
            Stake.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
