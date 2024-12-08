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


namespace Polkadot.NetApi.Generated.Model.sp_runtime
{
    
    
    /// <summary>
    /// >> 27 - Composite[sp_runtime.ModuleError]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ModuleError : BaseType
    {
        
        /// <summary>
        /// >> index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U8 Index { get; set; }
        /// <summary>
        /// >> error
        /// </summary>
        public Polkadot.NetApi.Generated.Types.Base.Arr4U8 Error { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ModuleError";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Error.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Substrate.NetApi.Model.Types.Primitive.U8();
            Index.Decode(byteArray, ref p);
            Error = new Polkadot.NetApi.Generated.Types.Base.Arr4U8();
            Error.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
