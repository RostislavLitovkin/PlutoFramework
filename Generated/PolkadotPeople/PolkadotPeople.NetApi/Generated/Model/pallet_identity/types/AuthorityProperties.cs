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
    /// >> 423 - Composite[pallet_identity.types.AuthorityProperties]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AuthorityProperties : BaseType
    {
        
        /// <summary>
        /// >> account_id
        /// </summary>
        public PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32 AccountId { get; set; }
        /// <summary>
        /// >> allocation
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Allocation { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AuthorityProperties";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(AccountId.Encode());
            result.AddRange(Allocation.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            AccountId = new PolkadotPeople.NetApi.Generated.Model.sp_core.crypto.AccountId32();
            AccountId.Decode(byteArray, ref p);
            Allocation = new Substrate.NetApi.Model.Types.Primitive.U32();
            Allocation.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
