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


namespace Opal.NetApi.Generated.Model.up_data_structs
{
    
    
    /// <summary>
    /// >> 676 - Composite[up_data_structs.PropertiesMapT2]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PropertiesMapT2 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        public Opal.NetApi.Generated.Model.bounded_collections.bounded_btree_map.BoundedBTreeMapT3 Value { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PropertiesMapT2";
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
            Value = new Opal.NetApi.Generated.Model.bounded_collections.bounded_btree_map.BoundedBTreeMapT3();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
