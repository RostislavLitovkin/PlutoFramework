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


namespace Kilt.NetApi.Generated.Model.pallet_did_lookup.account
{
    
    
    /// <summary>
    /// >> 120 - Composite[pallet_did_lookup.account.AccountId20]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AccountId20 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        public Kilt.NetApi.Generated.Types.Base.Arr20U8 Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AccountId20";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Kilt.NetApi.Generated.Types.Base.Arr20U8();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
