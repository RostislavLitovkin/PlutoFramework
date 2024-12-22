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


namespace PolkadotAssetHub.NetApi.Generated.Model.pallet_xcm.pallet
{
    
    
    /// <summary>
    /// >> 297 - Composite[pallet_xcm.pallet.RemoteLockedFungibleRecord]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RemoteLockedFungibleRecord : BaseType
    {
        
        /// <summary>
        /// >> amount
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 Amount { get; set; }
        /// <summary>
        /// >> owner
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.xcm.EnumVersionedLocation Owner { get; set; }
        /// <summary>
        /// >> locker
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.xcm.EnumVersionedLocation Locker { get; set; }
        /// <summary>
        /// >> consumers
        /// </summary>
        public PolkadotAssetHub.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT19 Consumers { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "RemoteLockedFungibleRecord";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Amount.Encode());
            result.AddRange(Owner.Encode());
            result.AddRange(Locker.Encode());
            result.AddRange(Consumers.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Amount = new Substrate.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            Owner = new PolkadotAssetHub.NetApi.Generated.Model.xcm.EnumVersionedLocation();
            Owner.Decode(byteArray, ref p);
            Locker = new PolkadotAssetHub.NetApi.Generated.Model.xcm.EnumVersionedLocation();
            Locker.Decode(byteArray, ref p);
            Consumers = new PolkadotAssetHub.NetApi.Generated.Model.bounded_collections.bounded_vec.BoundedVecT19();
            Consumers.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
