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


namespace KusamaAssetHub.NetApi.Generated.Model.cumulus_pallet_parachain_system.relay_state_snapshot
{
    
    
    /// <summary>
    /// >> 193 - Composite[cumulus_pallet_parachain_system.relay_state_snapshot.MessagingStateSnapshot]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class MessagingStateSnapshot : BaseType
    {
        
        /// <summary>
        /// >> dmq_mqc_head
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.primitive_types.H256 DmqMqcHead { get; set; }
        /// <summary>
        /// >> relay_dispatch_queue_remaining_capacity
        /// </summary>
        public KusamaAssetHub.NetApi.Generated.Model.cumulus_pallet_parachain_system.relay_state_snapshot.RelayDispatchQueueRemainingCapacity RelayDispatchQueueRemainingCapacity { get; set; }
        /// <summary>
        /// >> ingress_channels
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<KusamaAssetHub.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, KusamaAssetHub.NetApi.Generated.Model.polkadot_primitives.v7.AbridgedHrmpChannel>> IngressChannels { get; set; }
        /// <summary>
        /// >> egress_channels
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<KusamaAssetHub.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, KusamaAssetHub.NetApi.Generated.Model.polkadot_primitives.v7.AbridgedHrmpChannel>> EgressChannels { get; set; }
        
        /// <inheritdoc/>
        public override string TypeName()
        {
            return "MessagingStateSnapshot";
        }
        
        /// <inheritdoc/>
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(DmqMqcHead.Encode());
            result.AddRange(RelayDispatchQueueRemainingCapacity.Encode());
            result.AddRange(IngressChannels.Encode());
            result.AddRange(EgressChannels.Encode());
            return result.ToArray();
        }
        
        /// <inheritdoc/>
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            DmqMqcHead = new KusamaAssetHub.NetApi.Generated.Model.primitive_types.H256();
            DmqMqcHead.Decode(byteArray, ref p);
            RelayDispatchQueueRemainingCapacity = new KusamaAssetHub.NetApi.Generated.Model.cumulus_pallet_parachain_system.relay_state_snapshot.RelayDispatchQueueRemainingCapacity();
            RelayDispatchQueueRemainingCapacity.Decode(byteArray, ref p);
            IngressChannels = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<KusamaAssetHub.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, KusamaAssetHub.NetApi.Generated.Model.polkadot_primitives.v7.AbridgedHrmpChannel>>();
            IngressChannels.Decode(byteArray, ref p);
            EgressChannels = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<KusamaAssetHub.NetApi.Generated.Model.polkadot_parachain_primitives.primitives.Id, KusamaAssetHub.NetApi.Generated.Model.polkadot_primitives.v7.AbridgedHrmpChannel>>();
            EgressChannels.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            global::System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
