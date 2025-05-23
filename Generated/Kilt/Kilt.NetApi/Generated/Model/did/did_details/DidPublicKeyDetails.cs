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
    /// >> 536 - Composite[did.did_details.DidPublicKeyDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DidPublicKeyDetails : BaseType
    {
        
        /// <summary>
        /// >> key
        /// </summary>
        public Kilt.NetApi.Generated.Model.did.did_details.EnumDidPublicKey Key { get; set; }
        /// <summary>
        /// >> block_number
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 BlockNumber { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "DidPublicKeyDetails";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Key.Encode());
            result.AddRange(BlockNumber.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Key = new Kilt.NetApi.Generated.Model.did.did_details.EnumDidPublicKey();
            Key.Decode(byteArray, ref p);
            BlockNumber = new Substrate.NetApi.Model.Types.Primitive.U64();
            BlockNumber.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
