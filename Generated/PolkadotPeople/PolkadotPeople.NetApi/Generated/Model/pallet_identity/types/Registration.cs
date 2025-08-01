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


namespace PolkadotPeople.NetApi.Generated.Model.pallet_identity.types
{
    
    
    /// <summary>
    /// >> 413 - Composite[pallet_identity.types.Registration]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Registration : BaseType
    {
        
        /// <summary>
        /// >> judgements
        /// </summary>
        public PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT27 Judgements { get; set; }
        /// <summary>
        /// >> deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit { get; set; }
        /// <summary>
        /// >> info
        /// </summary>
        public PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime.people.IdentityInfo Info { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Registration";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Judgements.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Info.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Judgements = new PolkadotPeople.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT27();
            Judgements.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Info = new PolkadotPeople.NetApi.Generated.Model.people_polkadot_runtime.people.IdentityInfo();
            Info.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
