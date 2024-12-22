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


namespace PolkadotAssetHub.NetApi.Generated.Model.pallet_asset_conversion.types
{
    
    
    /// <summary>
    /// >> 452 - Composite[pallet_asset_conversion.types.PoolInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PoolInfo : BaseType
    {
        
        /// <summary>
        /// >> lp_token
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 LpToken { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "PoolInfo";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(LpToken.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            LpToken = new Substrate.NetApi.Model.Types.Primitive.U32();
            LpToken.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
