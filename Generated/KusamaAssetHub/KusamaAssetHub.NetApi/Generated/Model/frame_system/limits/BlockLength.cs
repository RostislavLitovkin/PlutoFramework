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


namespace KusamaAssetHub.NetApi.Generated.Model.frame_system.limits
{
    
    
    /// <summary>
    /// >> 168 - Composite[frame_system.limits.BlockLength]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BlockLength : BaseType
    {
        
        /// <summary>
        /// >> max
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.frame_support.dispatch.PerDispatchClassT3 Max { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BlockLength";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Max.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Max = new KusamaAssetHub.NetApi.Generated.Model.frame_support.dispatch.PerDispatchClassT3();
            Max.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
