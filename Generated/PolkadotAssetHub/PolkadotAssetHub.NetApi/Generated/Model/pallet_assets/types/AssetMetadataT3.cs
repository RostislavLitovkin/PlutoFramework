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


namespace PolkadotAssetHub.NetApi.Generated.Model.pallet_assets.types
{
    
    
    /// <summary>
    /// >> 449 - Composite[pallet_assets.types.AssetMetadataT3]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AssetMetadataT3 : BaseType
    {
        
        /// <summary>
        /// >> deposit
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit { get; set; }
        /// <summary>
        /// >> name
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT28 Name { get; set; }
        /// <summary>
        /// >> symbol
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT28 Symbol { get; set; }
        /// <summary>
        /// >> decimals
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U8 Decimals { get; set; }
        /// <summary>
        /// >> is_frozen
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.Bool IsFrozen { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "AssetMetadataT3";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Deposit.Encode());
            result.AddRange(Name.Encode());
            result.AddRange(Symbol.Encode());
            result.AddRange(Decimals.Encode());
            result.AddRange(IsFrozen.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Name = new PolkadotAssetHub.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT28();
            Name.Decode(byteArray, ref p);
            Symbol = new PolkadotAssetHub.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT28();
            Symbol.Decode(byteArray, ref p);
            Decimals = new Substrate.NetApi.Model.Types.Primitive.U8();
            Decimals.Decode(byteArray, ref p);
            IsFrozen = new Substrate.NetApi.Model.Types.Primitive.Bool();
            IsFrozen.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
