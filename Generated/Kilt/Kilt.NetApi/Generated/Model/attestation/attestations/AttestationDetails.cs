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


namespace Kilt.NetApi.Generated.Model.attestation.attestations
{
    
    
    /// <summary>
    /// >> 523 - Composite[attestation.attestations.AttestationDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AttestationDetails : BaseType
    {
        
        /// <summary>
        /// >> ctype_hash
        /// </summary>
        public Kilt.NetApi.Generated.Model.primitive_types.H256 CtypeHash { get; set; }
        /// <summary>
        /// >> attester
        /// </summary>
        public Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32 Attester { get; set; }
        /// <summary>
        /// >> authorization_id
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumAuthorizationId> AuthorizationId { get; set; }
        /// <summary>
        /// >> revoked
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool Revoked { get; set; }
        /// <summary>
        /// >> deposit
        /// </summary>
        public Kilt.NetApi.Generated.Model.kilt_support.deposit.Deposit Deposit { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AttestationDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(CtypeHash.Encode());
            result.AddRange(Attester.Encode());
            result.AddRange(AuthorizationId.Encode());
            result.AddRange(Revoked.Encode());
            result.AddRange(Deposit.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            CtypeHash = new Kilt.NetApi.Generated.Model.primitive_types.H256();
            CtypeHash.Decode(byteArray, ref p);
            Attester = new Kilt.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            Attester.Decode(byteArray, ref p);
            AuthorizationId = new Substrate.NetApi.Model.Types.Base.BaseOpt<Kilt.NetApi.Generated.Model.runtime_common.authorization.EnumAuthorizationId>();
            AuthorizationId.Decode(byteArray, ref p);
            Revoked = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Revoked.Decode(byteArray, ref p);
            Deposit = new Kilt.NetApi.Generated.Model.kilt_support.deposit.Deposit();
            Deposit.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
