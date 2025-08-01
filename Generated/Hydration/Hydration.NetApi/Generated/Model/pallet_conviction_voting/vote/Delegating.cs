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


namespace Hydration.NetApi.Generated.Model.pallet_conviction_voting.vote
{
    
    
    /// <summary>
    /// >> 617 - Composite[pallet_conviction_voting.vote.Delegating]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Delegating : BaseType
    {
        
        /// <summary>
        /// >> balance
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Balance { get; set; }
        /// <summary>
        /// >> target
        /// </summary>
        public Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32 Target { get; set; }
        /// <summary>
        /// >> conviction
        /// </summary>
        public Hydration.NetApi.Generated.Model.pallet_conviction_voting.conviction.EnumConviction Conviction { get; set; }
        /// <summary>
        /// >> delegations
        /// </summary>
        public Hydration.NetApi.Generated.Model.pallet_conviction_voting.types.Delegations Delegations { get; set; }
        /// <summary>
        /// >> prior
        /// </summary>
        public Hydration.NetApi.Generated.Model.pallet_conviction_voting.vote.PriorLock Prior { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Delegating";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Balance.Encode());
            result.AddRange(Target.Encode());
            result.AddRange(Conviction.Encode());
            result.AddRange(Delegations.Encode());
            result.AddRange(Prior.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Balance = new Substrate.NetApi.Model.Types.Primitive.U128();
            Balance.Decode(byteArray, ref p);
            Target = new Hydration.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Target.Decode(byteArray, ref p);
            Conviction = new Hydration.NetApi.Generated.Model.pallet_conviction_voting.conviction.EnumConviction();
            Conviction.Decode(byteArray, ref p);
            Delegations = new Hydration.NetApi.Generated.Model.pallet_conviction_voting.types.Delegations();
            Delegations.Decode(byteArray, ref p);
            Prior = new Hydration.NetApi.Generated.Model.pallet_conviction_voting.vote.PriorLock();
            Prior.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
