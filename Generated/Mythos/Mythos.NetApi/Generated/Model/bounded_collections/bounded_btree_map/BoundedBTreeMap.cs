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


namespace Mythos.NetApi.Generated.Model.bounded_collections.bounded_btree_map
{
    
    
    /// <summary>
    /// >> 355 - Composite[bounded_collections.bounded_btree_map.BoundedBTreeMap]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BoundedBTreeMap : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        public Mythos.NetApi.Generated.Types.Base.BTreeMapT4 Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BoundedBTreeMap";
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
            Value = new Mythos.NetApi.Generated.Types.Base.BTreeMapT4();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
