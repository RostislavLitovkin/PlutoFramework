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


namespace Polkadot.NetApi.Generated.Model.frame_system.limits
{
    
    
    /// <summary>
    /// >> 502 - Composite[frame_system.limits.BlockWeights]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BlockWeights : BaseType
    {
        
        /// <summary>
        /// >> base_block
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight BaseBlock { get; set; }
        /// <summary>
        /// >> max_block
        /// </summary>
        public Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight MaxBlock { get; set; }
        /// <summary>
        /// >> per_class
        /// </summary>
        public Polkadot.NetApi.Generated.Model.frame_support.dispatch.PerDispatchClassT2 PerClass { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BlockWeights";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BaseBlock.Encode());
            result.AddRange(MaxBlock.Encode());
            result.AddRange(PerClass.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BaseBlock = new Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight();
            BaseBlock.Decode(byteArray, ref p);
            MaxBlock = new Polkadot.NetApi.Generated.Model.sp_weights.weight_v2.Weight();
            MaxBlock.Decode(byteArray, ref p);
            PerClass = new Polkadot.NetApi.Generated.Model.frame_support.dispatch.PerDispatchClassT2();
            PerClass.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
