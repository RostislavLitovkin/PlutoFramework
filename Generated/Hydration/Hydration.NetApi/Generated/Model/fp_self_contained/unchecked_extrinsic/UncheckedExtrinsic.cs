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


namespace Hydration.NetApi.Generated.Model.fp_self_contained.unchecked_extrinsic
{
    
    
    /// <summary>
    /// >> 852 - Composite[fp_self_contained.unchecked_extrinsic.UncheckedExtrinsic]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class UncheckedExtrinsic : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        public Hydration.NetApi.Generated.Model.sp_runtime.generic.unchecked_extrinsic.UncheckedExtrinsic Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "UncheckedExtrinsic";
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
            Value = new Hydration.NetApi.Generated.Model.sp_runtime.generic.unchecked_extrinsic.UncheckedExtrinsic();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
