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


namespace Unique.NetApi.Generated.Types.Base
{
    
    
    /// <summary>
    /// >> 101 - Composite[BTreeMapT1]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BTreeMapT1 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Unique.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Substrate.NetApi.Model.Types.Base.BaseVec<Unique.NetApi.Generated.Model.polkadot_core_primitives.InboundHrmpMessage>>> Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BTreeMapT1";
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
            Value = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Unique.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, Substrate.NetApi.Model.Types.Base.BaseVec<Unique.NetApi.Generated.Model.polkadot_core_primitives.InboundHrmpMessage>>>();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
