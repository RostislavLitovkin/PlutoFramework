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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_multisig
{
    
    
    /// <summary>
    /// >> 40 - Composite[pallet_multisig.Timepoint]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Timepoint : BaseType
    {
        
        /// <summary>
        /// >> height
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Height { get; set; }
        /// <summary>
        /// >> index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Index { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Timepoint";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Height.Encode());
            result.AddRange(Index.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Height = new Substrate.NetApi.Model.Types.Primitive.U32();
            Height.Decode(byteArray, ref p);
            Index = new Substrate.NetApi.Model.Types.Primitive.U32();
            Index.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
