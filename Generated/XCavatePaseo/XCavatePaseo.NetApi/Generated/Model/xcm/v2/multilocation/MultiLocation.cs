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


namespace XCavatePaseo.NetApi.Generated.Model.xcm.v2.multilocation
{
    
    
    /// <summary>
    /// >> 77 - Composite[xcm.v2.multilocation.MultiLocation]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class MultiLocation : BaseType
    {
        
        /// <summary>
        /// >> parents
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U8 Parents { get; set; }
        /// <summary>
        /// >> interior
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.xcm.v2.multilocation.EnumJunctions Interior { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "MultiLocation";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Parents.Encode());
            result.AddRange(Interior.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Parents = new Substrate.NetApi.Model.Types.Primitive.U8();
            Parents.Decode(byteArray, ref p);
            Interior = new XCavatePaseo.NetApi.Generated.Model.xcm.v2.multilocation.EnumJunctions();
            Interior.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
