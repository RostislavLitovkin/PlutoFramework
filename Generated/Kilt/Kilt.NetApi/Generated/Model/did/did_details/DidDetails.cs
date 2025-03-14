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


namespace Kilt.NetApi.Generated.Model.did.did_details
{
    
    
    /// <summary>
    /// >> 533 - Composite[did.did_details.DidDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DidDetails : BaseType
    {
        
        /// <summary>
        /// >> authentication_key
        /// </summary>
        public Kilt.NetApi.Generated.Model.primitive_types.H256 AuthenticationKey { get; set; }
        /// <summary>
        /// >> key_agreement_keys
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_btree_set.BoundedBTreeSetT3 KeyAgreementKeys { get; set; }
        /// <summary>
        /// >> delegation_key
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.primitive_types.H256> DelegationKey { get; set; }
        /// <summary>
        /// >> attestation_key
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.primitive_types.H256> AttestationKey { get; set; }
        /// <summary>
        /// >> public_keys
        /// </summary>
        public Kilt.NetApi.Generated.Model.bounded_collections.bounded_btree_map.BoundedBTreeMapT2 PublicKeys { get; set; }
        /// <summary>
        /// >> last_tx_counter
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 LastTxCounter { get; set; }
        /// <summary>
        /// >> deposit
        /// </summary>
        public Kilt.NetApi.Generated.Model.kilt_support.deposit.Deposit Deposit { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "DidDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(AuthenticationKey.Encode());
            result.AddRange(KeyAgreementKeys.Encode());
            result.AddRange(DelegationKey.Encode());
            result.AddRange(AttestationKey.Encode());
            result.AddRange(PublicKeys.Encode());
            result.AddRange(LastTxCounter.Encode());
            result.AddRange(Deposit.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            AuthenticationKey = new Kilt.NetApi.Generated.Model.primitive_types.H256();
            AuthenticationKey.Decode(byteArray, ref p);
            KeyAgreementKeys = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_btree_set.BoundedBTreeSetT3();
            KeyAgreementKeys.Decode(byteArray, ref p);
            DelegationKey = new Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.primitive_types.H256>();
            DelegationKey.Decode(byteArray, ref p);
            AttestationKey = new Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.primitive_types.H256>();
            AttestationKey.Decode(byteArray, ref p);
            PublicKeys = new Kilt.NetApi.Generated.Model.bounded_collections.bounded_btree_map.BoundedBTreeMapT2();
            PublicKeys.Decode(byteArray, ref p);
            LastTxCounter = new Substrate.NetApi.Model.Types.Primitive.U64();
            LastTxCounter.Decode(byteArray, ref p);
            Deposit = new Kilt.NetApi.Generated.Model.kilt_support.deposit.Deposit();
            Deposit.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
