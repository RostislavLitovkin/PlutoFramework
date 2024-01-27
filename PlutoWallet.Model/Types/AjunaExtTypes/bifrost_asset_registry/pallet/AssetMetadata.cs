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
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Substrate.NetApi.Generated.Model.bifrost_asset_registry.pallet
{
    
    
    /// <summary>
    /// >> 276 - Composite[bifrost_asset_registry.pallet.AssetMetadata]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AssetMetadata : BaseType
    {
        
        /// <summary>
        /// >> name
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> Name { get; set; }
        /// <summary>
        /// >> symbol
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> Symbol { get; set; }
        /// <summary>
        /// >> decimals
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U8 Decimals { get; set; }
        /// <summary>
        /// >> minimal_balance
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 MinimalBalance { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AssetMetadata";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Name.Encode());
            result.AddRange(Symbol.Encode());
            result.AddRange(Decimals.Encode());
            result.AddRange(MinimalBalance.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Name = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Name.Decode(byteArray, ref p);
            Symbol = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Symbol.Decode(byteArray, ref p);
            Decimals = new Substrate.NetApi.Model.Types.Primitive.U8();
            Decimals.Decode(byteArray, ref p);
            MinimalBalance = new Substrate.NetApi.Model.Types.Primitive.U128();
            MinimalBalance.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}