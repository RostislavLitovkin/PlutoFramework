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


namespace Polkadot.NetApi.Generated.Model.frame_metadata_hash_extension
{
    
    
    /// <summary>
    /// >> 854 - Composite[frame_metadata_hash_extension.CheckMetadataHash]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CheckMetadataHash : BaseType
    {
        
        /// <summary>
        /// >> mode
        /// </summary>
        public Polkadot.NetApi.Generated.Model.frame_metadata_hash_extension.EnumMode Mode { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "CheckMetadataHash";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Mode.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Mode = new Polkadot.NetApi.Generated.Model.frame_metadata_hash_extension.EnumMode();
            Mode.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
