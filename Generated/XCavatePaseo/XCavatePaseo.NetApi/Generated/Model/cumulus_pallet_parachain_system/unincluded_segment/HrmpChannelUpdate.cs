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


namespace XcavatePaseo.NetApi.Generated.Model.cumulus_pallet_parachain_system.unincluded_segment
{
    
    
    /// <summary>
    /// >> 196 - Composite[cumulus_pallet_parachain_system.unincluded_segment.HrmpChannelUpdate]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class HrmpChannelUpdate : BaseType
    {
        
        /// <summary>
        /// >> msg_count
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MsgCount { get; set; }
        /// <summary>
        /// >> total_bytes
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 TotalBytes { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "HrmpChannelUpdate";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MsgCount.Encode());
            result.AddRange(TotalBytes.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MsgCount = new Substrate.NetApi.Model.Types.Primitive.U32();
            MsgCount.Decode(byteArray, ref p);
            TotalBytes = new Substrate.NetApi.Model.Types.Primitive.U32();
            TotalBytes.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
