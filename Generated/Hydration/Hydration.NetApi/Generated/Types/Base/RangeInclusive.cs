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


namespace Hydration.NetApi.Generated.Types.Base
{
    
    
    /// <summary>
    /// >> 610 - Composite[RangeInclusive]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RangeInclusive : BaseType
    {
        
        /// <summary>
        /// >> start
        /// </summary>
        public Hydration.NetApi.Generated.Types.Base.NonZeroU16 Start { get; set; }
        /// <summary>
        /// >> end
        /// </summary>
        public Hydration.NetApi.Generated.Types.Base.NonZeroU16 End { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "RangeInclusive";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Start.Encode());
            result.AddRange(End.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Start = new Hydration.NetApi.Generated.Types.Base.NonZeroU16();
            Start.Decode(byteArray, ref p);
            End = new Hydration.NetApi.Generated.Types.Base.NonZeroU16();
            End.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
