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


namespace Hydration.NetApi.Generated.Model.bounded_collections.bounded_btree_set
{
    
    
    /// <summary>
    /// >> 718 - Composite[bounded_collections.bounded_btree_set.BoundedBTreeSetT1]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BoundedBTreeSetT1 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        public Hydration.NetApi.Generated.Types.Base.BTreeSetT2 Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BoundedBTreeSetT1";
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
            Value = new Hydration.NetApi.Generated.Types.Base.BTreeSetT2();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
