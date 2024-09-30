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


namespace KusamaAssetHub.NetApi.Generated.Model.pallet_message_queue
{
    
    
    /// <summary>
    /// >> 341 - Composite[pallet_message_queue.BookState]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BookState : BaseType
    {
        
        /// <summary>
        /// >> begin
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Begin { get; set; }
        /// <summary>
        /// >> end
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 End { get; set; }
        /// <summary>
        /// >> count
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Count { get; set; }
        /// <summary>
        /// >> ready_neighbours
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseOpt<KusamaAssetHub.NetApi.Generated.Model.pallet_message_queue.Neighbours> ReadyNeighbours { get; set; }
        /// <summary>
        /// >> message_count
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 MessageCount { get; set; }
        /// <summary>
        /// >> size
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U64 Size { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "BookState";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Begin.Encode());
            result.AddRange(End.Encode());
            result.AddRange(Count.Encode());
            result.AddRange(ReadyNeighbours.Encode());
            result.AddRange(MessageCount.Encode());
            result.AddRange(Size.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Begin = new Substrate.NetApi.Model.Types.Primitive.U32();
            Begin.Decode(byteArray, ref p);
            End = new Substrate.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            Count = new Substrate.NetApi.Model.Types.Primitive.U32();
            Count.Decode(byteArray, ref p);
            ReadyNeighbours = new Substrate.NetApi.Model.Types.Base.BaseOpt<KusamaAssetHub.NetApi.Generated.Model.pallet_message_queue.Neighbours>();
            ReadyNeighbours.Decode(byteArray, ref p);
            MessageCount = new Substrate.NetApi.Model.Types.Primitive.U64();
            MessageCount.Decode(byteArray, ref p);
            Size = new Substrate.NetApi.Model.Types.Primitive.U64();
            Size.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
