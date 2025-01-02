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


namespace InvArch.NetApi.Generated.Model.orml_tokens
{
    
    
    /// <summary>
    /// >> 400 - Composite[orml_tokens.AccountDataT1]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AccountDataT1 : BaseType
    {
        
        /// <summary>
        /// >> free
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Free { get; set; }
        /// <summary>
        /// >> reserved
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Reserved { get; set; }
        /// <summary>
        /// >> frozen
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Frozen { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AccountDataT1";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Free.Encode());
            result.AddRange(Reserved.Encode());
            result.AddRange(Frozen.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Free = new Substrate.NetApi.Model.Types.Primitive.U128();
            Free.Decode(byteArray, ref p);
            Reserved = new Substrate.NetApi.Model.Types.Primitive.U128();
            Reserved.Decode(byteArray, ref p);
            Frozen = new Substrate.NetApi.Model.Types.Primitive.U128();
            Frozen.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
