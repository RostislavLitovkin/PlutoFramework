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


namespace XCavatePaseo.NetApi.Generated.Model.pallet_nfts.types
{
    
    
    /// <summary>
    /// >> 243 - Composite[pallet_nfts.types.ItemConfig]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ItemConfig : BaseType
    {
        
        /// <summary>
        /// >> settings
        /// </summary>
        public XCavatePaseo.NetApi.Generated.Model.pallet_nfts.types.BitFlagsT2 Settings { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "ItemConfig";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Settings.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Settings = new XCavatePaseo.NetApi.Generated.Model.pallet_nfts.types.BitFlagsT2();
            Settings.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
