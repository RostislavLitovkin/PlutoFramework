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


namespace XcavatePaseo.NetApi.Generated.Model.polkadot_primitives.v8.async_backing
{
    
    
    /// <summary>
    /// >> 238 - Composite[polkadot_primitives.v8.async_backing.AsyncBackingParams]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AsyncBackingParams : BaseType
    {
        
        /// <summary>
        /// >> max_candidate_depth
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MaxCandidateDepth { get; set; }
        /// <summary>
        /// >> allowed_ancestry_len
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 AllowedAncestryLen { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AsyncBackingParams";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaxCandidateDepth.Encode());
            result.AddRange(AllowedAncestryLen.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaxCandidateDepth = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxCandidateDepth.Decode(byteArray, ref p);
            AllowedAncestryLen = new Substrate.NetApi.Model.Types.Primitive.U32();
            AllowedAncestryLen.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
