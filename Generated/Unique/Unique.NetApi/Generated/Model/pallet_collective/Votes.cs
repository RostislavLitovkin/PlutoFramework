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


namespace Unique.NetApi.Generated.Model.pallet_collective
{
    
    
    /// <summary>
    /// >> 492 - Composite[pallet_collective.Votes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Votes : BaseType
    {
        
        /// <summary>
        /// >> index
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Index { get; set; }
        /// <summary>
        /// >> threshold
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Threshold { get; set; }
        /// <summary>
        /// >> ayes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Unique.NetApi.Generated.Model.sp_core.crypto.AccountId32> Ayes { get; set; }
        /// <summary>
        /// >> nays
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Unique.NetApi.Generated.Model.sp_core.crypto.AccountId32> Nays { get; set; }
        /// <summary>
        /// >> end
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 End { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "Votes";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Threshold.Encode());
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(End.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Substrate.NetApi.Model.Types.Primitive.U32();
            Index.Decode(byteArray, ref p);
            Threshold = new Substrate.NetApi.Model.Types.Primitive.U32();
            Threshold.Decode(byteArray, ref p);
            Ayes = new Substrate.NetApi.Model.Types.Base.BaseVec<Unique.NetApi.Generated.Model.sp_core.crypto.AccountId32>();
            Ayes.Decode(byteArray, ref p);
            Nays = new Substrate.NetApi.Model.Types.Base.BaseVec<Unique.NetApi.Generated.Model.sp_core.crypto.AccountId32>();
            Nays.Decode(byteArray, ref p);
            End = new Substrate.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
