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


namespace KusamaAssetHub.NetApi.Generated.Model.pallet_nfts.types
{
    
    
    /// <summary>
    /// >> 381 - Composite[pallet_nfts.types.PreSignedAttributes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PreSignedAttributes : BaseType
    {
        
        /// <summary>
        /// >> collection
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Collection { get; set; }
        /// <summary>
        /// >> item
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Item { get; set; }
        /// <summary>
        /// >> attributes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>> Attributes { get; set; }
        /// <summary>
        /// >> namespace
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.pallet_nfts.types.EnumAttributeNamespace Namespace { get; set; }
        /// <summary>
        /// >> deadline
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Deadline { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PreSignedAttributes";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Collection.Encode());
            result.AddRange(Item.Encode());
            result.AddRange(Attributes.Encode());
            result.AddRange(Namespace.Encode());
            result.AddRange(Deadline.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Collection = new Substrate.NetApi.Model.Types.Primitive.U32();
            Collection.Decode(byteArray, ref p);
            Item = new Substrate.NetApi.Model.Types.Primitive.U32();
            Item.Decode(byteArray, ref p);
            Attributes = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>>();
            Attributes.Decode(byteArray, ref p);
            Namespace = new KusamaAssetHub.NetApi.Generated.Model.pallet_nfts.types.EnumAttributeNamespace();
            Namespace.Decode(byteArray, ref p);
            Deadline = new Substrate.NetApi.Model.Types.Primitive.U32();
            Deadline.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
